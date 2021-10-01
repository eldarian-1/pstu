#include "RsaTask.h"

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
    BigInt r = BigInt::pow(c, e) % n;
    BigInt nul(0);
    BigInt multiplier(65536);
    QString result;
    for(int i = 0; i < k && r != nul; ++i) {
        result = QChar(stoi(BigInt::to_string(r % multiplier))) + result;
        r /= multiplier;
    }
    return result;
}

RsaLoader::RsaLoader(RsaTask* task) {
    this->task = task;
    manager = new QNetworkAccessManager(this);
    connect(manager, SIGNAL(finished(QNetworkReply*)), SLOT(slotFinished(QNetworkReply*)));
}

void RsaLoader::download() {
    manager->get(QNetworkRequest(QUrl("http://localhost:8080/rsa")));
}

void RsaLoader::done(const QUrl& url, const QByteArray& array) {
    QJsonObject json = QJsonDocument::fromJson(array).object();
    p = BigInt(json["p"].toString().toStdString());
    q = BigInt(json["q"].toString().toStdString());
    e = BigInt(json["e"].toString().toStdString());
    n = BigInt(json["n"].toString().toStdString());
    d = BigInt(json["d"].toString().toStdString());
    task->setRsa(p, q, e, n, d);
}

void RsaLoader::slotFinished(QNetworkReply* reply) {
    if (reply->error() == QNetworkReply::NoError) {
        done(reply->url(), reply->readAll());
    }
    reply->deleteLater();
}

RsaTask::RsaTask(): Task("Алгоритм RsaLoader") {
    loader = new RsaLoader(this);
}

void RsaTask::getRsa() {
    loader->download();
}

void RsaTask::aCrypt() {
    const QString &in = txtAIn->text();
    const QString &out = alice->crypt(in);
    txtBOut->setText(out);
}

void RsaTask::aDecrypt() {
    const QString &in = txtAOut->text();
    const QString &out = alice->crypt(in);
    txtAIn->setText(out);
}

void RsaTask::bCrypt() {
    const QString &in = txtBIn->text();
    const QString &out = bob->crypt(in);
    txtAOut->setText(out);
}

void RsaTask::bDecrypt() {
    const QString &in = txtBOut->text();
    const QString &out = bob->crypt(in);
    txtBIn->setText(out);
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
    lytABtns = new QHBoxLayout();
    lytEN = new QHBoxLayout();
    lytBBtns = new QHBoxLayout();

    lytAlice->setAlignment(Qt::Alignment::enum_type::AlignTop);
    lytBob->setAlignment(Qt::Alignment::enum_type::AlignTop);

    lblAlice = new QLabel("Alice");
    lblBob = new QLabel("Bob");
    lblE = new QLabel("e");
    lblN = new QLabel("n");
    lblInput = new QLabel("Вход: p - ..., q - ...");
    lblPrivate = new QLabel("Закрытый: d - ..., n - ...");
    lblPublic = new QLabel("Открытый: e - ..., n - ...");
    lblAIn = new QLabel("Открытый текст");
    lblAOut = new QLabel("Шифротекст");
    lblBIn = new QLabel("Открытый текст");
    lblBOut = new QLabel("Шифротекст");

    txtE = new QLineEdit();
    txtN = new QLineEdit();
    txtAIn = new QLineEdit();
    txtAOut = new QLineEdit();
    txtBIn = new QLineEdit();
    txtBOut = new QLineEdit();

    btnLoad = new QPushButton("Загрузить");
    btnACrypt = new QPushButton("Отправить");
    btnADecrypt = new QPushButton("Расшифровать");
    btnBCrypt = new QPushButton("Отправить");
    btnBDecrypt = new QPushButton("Расшифровать");

    wgt->setLayout(lytMain);
    lytMain->addLayout(lytAlice);
    lytAlice->addWidget(lblAlice);
    lytAlice->addWidget(lblInput);
    lytAlice->addWidget(lblPrivate);
    lytAlice->addWidget(lblPublic);
    lytAlice->addWidget(btnLoad);
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

void RsaTask::run() const {

}