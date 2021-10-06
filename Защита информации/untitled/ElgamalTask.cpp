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

void ElgamalTask::setElgamal(const BigInt &p, const BigInt &g, const BigInt &x, const BigInt &y, const BigInt &k) {
    if(client) {
        delete client;
    }
    client = new ElgamalClient(p, g, x, y, k);
    lblPrivate->setText(("Закрытый ключ x: " + BigInt::to_string(x)).c_str());
    lblPublic->setText(("Открытый ключ: p - " + BigInt::to_string(p) +
            ", g - " + BigInt::to_string(g) +
            ", y - " + BigInt::to_string(y)).c_str());
    lblSession->setText(("Сессионный ключ k: " + BigInt::to_string(k)).c_str());
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
        (client->check(r, s) ? "подпись подтверждена" : "подпись ложна"));
}

void ElgamalLoader::done(QJsonObject& json) {
    BigInt p(json["p"].toString().toStdString());
    BigInt g(json["g"].toString().toStdString());
    BigInt x(json["x"].toString().toStdString());
    BigInt y(json["y"].toString().toStdString());
    BigInt k(json["k"].toString().toStdString());
    task->setElgamal(p, g, x, y, k);
}

void ElgamalClient::generate(QString m, BigInt &r, BigInt &s) {
    r = BigInt(13);
    s = BigInt(6);
}

bool ElgamalClient::check(BigInt r, BigInt s) {
    return true;
}
