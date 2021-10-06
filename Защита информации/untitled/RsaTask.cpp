#include "RsaTask.h"

#include <QLabel>
#include <QJsonObject>
#include <QJsonDocument>
#include <QHBoxLayout>
#include <QLineEdit>
#include <QPushButton>

#include "Task.h"
#include "BigInt.h"
#include "Loader.h"

RsaTask::RsaTask(): Task("Алгоритм RSA") {}

void RsaTask::getRsa() {
    (new RsaLoader(this, txtCapacity->text()))->run();
}

void RsaTask::crypt(bool isAlice, bool isCrypt) {
    this->isAlice = isAlice;
    this->isCrypt = isCrypt;
    const QString &in = (isAlice ? (isCrypt ? txtAIn : txtAOut) : (isCrypt ? txtBIn : txtBOut))->text();
    const QString &out = (isAlice ? alice : bob)->crypt(in);
    (isAlice ? (isCrypt ? txtBOut : txtAIn) : (isCrypt ? txtAOut : txtBIn))->setText(out);
}

void RsaTask::aCrypt() {
    crypt(true, true);
}

void RsaTask::aDecrypt() {
    crypt(true, false);
}

void RsaTask::bCrypt() {
    crypt(false, true);
}

void RsaTask::bDecrypt() {
    crypt(false, false);
}

void RsaTask::setRsa(const BigInt &p, const BigInt &q, const BigInt &e, const BigInt &n, const BigInt &d) {
    if(alice) {
        delete alice;
        delete bob;
        alice = nullptr;
        bob = nullptr;
    }
    alice = new RsaClient(d, n);
    bob = new RsaClient(e, n);
    lblInput->setText(("Вход: p - " + BigInt::to_string(p) + ", q - "  + BigInt::to_string(q)).c_str());
    lblPrivate->setText(("Закрытый: d - " + BigInt::to_string(d) + ", n - "  + BigInt::to_string(n)).c_str());
    lblPublic->setText(("Открытый: e - " + BigInt::to_string(e) + ", n - " + BigInt::to_string(n)).c_str());
    txtE->setText(BigInt::to_string(e).c_str());
    txtN->setText(BigInt::to_string(n).c_str());
}

void RsaTask::initWidget(QWidget *wgt) {
    lytMain = new QHBoxLayout();
    lytAlice = new QVBoxLayout();
    lytBob = new QVBoxLayout();
    lytCapacity = new QHBoxLayout();
    lytABtns = new QHBoxLayout();
    lytEN = new QHBoxLayout();
    lytBBtns = new QHBoxLayout();

    lytAlice->setAlignment(Qt::Alignment::enum_type::AlignTop);
    lytBob->setAlignment(Qt::Alignment::enum_type::AlignTop);

    lblAlice = new QLabel("Alice");
    lblBob = new QLabel("Bob");
    lblCapacity = new QLabel("Разрядность");
    lblE = new QLabel("e");
    lblN = new QLabel("n");
    lblInput = new QLabel("Вход: p - ..., q - ...");
    lblPrivate = new QLabel("Закрытый: d - ..., n - ...");
    lblPublic = new QLabel("Открытый: e - ..., n - ...");
    lblAIn = new QLabel("Открытый текст");
    lblAOut = new QLabel("Шифротекст");
    lblBIn = new QLabel("Открытый текст");
    lblBOut = new QLabel("Шифротекст");

    txtCapacity = new QLineEdit("16");
    txtE = new QLineEdit();
    txtN = new QLineEdit();
    txtAIn = new QLineEdit();
    txtAOut = new QLineEdit();
    txtBIn = new QLineEdit();
    txtBOut = new QLineEdit();

    btnLoad = new QPushButton("Сгенерировать");
    btnACrypt = new QPushButton("Отправить");
    btnADecrypt = new QPushButton("Расшифровать");
    btnBCrypt = new QPushButton("Отправить");
    btnBDecrypt = new QPushButton("Расшифровать");

    wgt->setLayout(lytMain);
    lytMain->addLayout(lytAlice);
    lytAlice->addWidget(lblAlice);
    lytAlice->addLayout(lytCapacity);
    lytCapacity->addWidget(lblCapacity);
    lytCapacity->addWidget(txtCapacity);
    lytCapacity->addWidget(btnLoad);
    lytAlice->addWidget(lblInput);
    lytAlice->addWidget(lblPrivate);
    lytAlice->addWidget(lblPublic);
    lytAlice->addWidget(lblAIn);
    lytAlice->addWidget(txtAIn);
    lytAlice->addWidget(lblAOut);
    lytAlice->addWidget(txtAOut);
    lytAlice->addLayout(lytABtns);
    lytABtns->addWidget(btnACrypt);
    lytABtns->addWidget(btnADecrypt);
    lytMain->addLayout(lytBob);
    lytBob->addWidget(lblBob);
    lytBob->addLayout(lytEN);
    lytEN->addWidget(lblE);
    lytEN->addWidget(txtE);
    lytEN->addWidget(lblN);
    lytEN->addWidget(txtN);
    lytBob->addWidget(lblBIn);
    lytBob->addWidget(txtBIn);
    lytBob->addWidget(lblBOut);
    lytBob->addWidget(txtBOut);
    lytBob->addLayout(lytBBtns);
    lytBBtns->addWidget(btnBCrypt);
    lytBBtns->addWidget(btnBDecrypt);

    connect(btnLoad, SIGNAL(released()), this, SLOT(getRsa()));
    connect(btnACrypt, SIGNAL(released()), this, SLOT(aCrypt()));
    connect(btnADecrypt, SIGNAL(released()), this, SLOT(aDecrypt()));
    connect(btnBCrypt, SIGNAL(released()), this, SLOT(bCrypt()));
    connect(btnBDecrypt, SIGNAL(released()), this, SLOT(bDecrypt()));
}

QString RsaLoader::query() {
    return ("rsa?cap=" + capacity);
}

void RsaLoader::done(QJsonObject& json) {
    BigInt p(json["p"].toString().toStdString());
    BigInt q(json["q"].toString().toStdString());
    BigInt e(json["e"].toString().toStdString());
    BigInt n(json["n"].toString().toStdString());
    BigInt d(json["d"].toString().toStdString());
    task->setRsa(p, q, e, n, d);
}

RsaClient::RsaClient(const BigInt& e, const BigInt& n) : e(e), n(n) {
    k = BigInt::log2(n);
    k > 16 ? k /= 16 : k = 1;
}

QString RsaClient::crypt(const QString &in) {
    QString result;
    BigInt multiplier(65536);
    for (int i = 0; i < in.size(); i += k) {
        BigInt symbol(0);
        for (int j = i; j < in.size() && j < i + k; ++j) {
            symbol *= multiplier;
            symbol += BigInt((int)in[j].unicode());
        }
        result.append(crypt(symbol));
    }
    return result;
}

QString RsaClient::crypt(const BigInt &c) {
    BigInt r = BigInt::modPow(c, e, n);
    BigInt nul(0);
    BigInt multiplier(65536);
    QString result;
    for(int i = 0; i < k && r != nul; ++i) {
        result = QChar(stoi(BigInt::to_string(r % multiplier))) + result;
        r /= multiplier;
    }
    return result;
}
