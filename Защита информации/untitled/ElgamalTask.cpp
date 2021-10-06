#include "ElgamalTask.h"
#include "BigInt.h"

#include <QVBoxLayout>
#include <QHBoxLayout>
#include <QLabel>
#include <QLineEdit>
#include <QPushButton>
#include <QJsonObject>

void ElgamalTask::initWidget(QWidget *wgt) {
    lytMain = new QVBoxLayout;
    lytPair = new QHBoxLayout;

    lblName = new QLabel("Цифровая подпись методом Эль-Гамаля");
    lblPrivate = new QLabel("Закрытый ключ x: ...");
    lblPublic = new QLabel("Открытый ключ: p - ..., g - ..., y - ...");
    lblSession = new QLabel("Сессионный ключ k: ...");
    lblMessage = new QLabel("Сообщение");
    lblR = new QLabel("r");
    lblS = new QLabel("s");
    lblVerdict = new QLabel("Вердикт: ...");

    leMessage = new QLineEdit;
    leR = new QLineEdit;
    leS = new QLineEdit;

    btnGenerate = new QPushButton("Сгенерировать ключи");
    btnCrypt = new QPushButton("Сгенерировать подпись");
    btnCheck = new QPushButton("Проверка подписи");

    wgt->setLayout(lytMain);
    lytMain->addWidget(lblName);
    lytMain->addWidget(lblPrivate);
    lytMain->addWidget(lblPublic);
    lytMain->addWidget(lblSession);
    lytMain->addWidget(btnGenerate);
    lytMain->addWidget(lblMessage);
    lytMain->addWidget(leMessage);
    lytMain->addWidget(btnCrypt);
    lytMain->addLayout(lytPair);
    lytPair->addWidget(lblR);
    lytPair->addWidget(leR);
    lytPair->addWidget(lblS);
    lytPair->addWidget(leS);
    lytMain->addWidget(btnCheck);
    lytMain->addWidget(lblVerdict);
    lytMain->setAlignment(Qt::Alignment::enum_type::AlignTop);

    connect(btnGenerate, SIGNAL(released()), this, SLOT(getElgamal()));
    connect(btnCrypt, SIGNAL(released()), this, SLOT(crypt()));
    connect(btnCheck, SIGNAL(released()), this, SLOT(check()));
}

void ElgamalTask::setElgamal(const BigInt &p, const BigInt &g, const BigInt &x, const BigInt &y, const BigInt &k, const BigInt &k_1) {
    if(client) {
        delete client;
    }
    client = new ElgamalClient(p, g, x, y, k, k_1);
    lblPrivate->setText(("Закрытый ключ x: " + BigInt::to_string(x)).c_str());
    lblPublic->setText(("Открытый ключ: p - " + BigInt::to_string(p) +
            ", g - " + BigInt::to_string(g) +
            ", y - " + BigInt::to_string(y)).c_str());
    lblSession->setText(("Сессионный ключ: k - " + BigInt::to_string(k) +
        ", k^(-1) - " + BigInt::to_string(k_1)).c_str());
}

void ElgamalTask::getElgamal() {
    (new ElgamalLoader(this))->run();
}

void ElgamalTask::crypt() {
    BigInt r, s;
    client->generate(leMessage->text() ,r, s);
    leR->setText(BigInt::to_string(r).c_str());
    leS->setText(BigInt::to_string(s).c_str());
}

void ElgamalTask::check() {
    BigInt r(leR->text().toStdString());
    BigInt s(leS->text().toStdString());
    lblVerdict->setText(QString("Вердикт: ") +
        (client->check(leMessage->text(), r, s) ? "подпись подтверждена" : "подпись ложна"));
}

void ElgamalLoader::done(QJsonObject& json) {
    BigInt p(json["p"].toString().toStdString());
    BigInt g(json["g"].toString().toStdString());
    BigInt x(json["x"].toString().toStdString());
    BigInt y(json["y"].toString().toStdString());
    BigInt k(json["k"].toString().toStdString());
    BigInt k_1(json["k_1"].toString().toStdString());
    task->setElgamal(p, g, x, y, k, k_1);
    //task->setElgamal(23, 5, 7, 17, 5, 9);
}

size_t hs(QString s) {
    return std::hash<std::string>{}(s.toStdString());
    //return 3;
}

void ElgamalClient::generate(const QString &m, BigInt &r, BigInt &s) {
    size_t hm = hs(m);
    r = BigInt::modPow(g, k, p);
    s = ((hm - x * r) * k_1) % (p - 1);
    _IO_FILE *f = fopen("output.txt", "a");
    fprintf(f, "r: %s k_1: %s\n", BigInt::to_string(r).c_str(), BigInt::to_string(k_1).c_str());
    fclose(f);
}

bool ElgamalClient::check(const QString &m, const BigInt &r, const BigInt &s) {
    bool result = 0 < r && r < p && 0 < s && s < (p - 1);
    if(result) {
        size_t hm = hs(m);
        BigInt left = BigInt::mod2Pow(y, r, r, s, p);
        BigInt right = BigInt::modPow(g, hm, p);
        result = left == right;
        _IO_FILE *f = fopen("output.txt", "a");
        fprintf(f, "l: %s r: %s\n", BigInt::to_string(left).c_str(),
                BigInt::to_string(right).c_str());
        //fprintf(f, "a: %s\n", BigInt::to_string(BigInt::mod2Pow(17, 20, 20, 21, 23)).c_str());
        fclose(f);
    }
    return result;
}
