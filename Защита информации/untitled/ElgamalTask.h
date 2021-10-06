#pragma once

#include <QWidget>
#include <QLabel>

#include "Task.h"

class ElgamalTask: public Task {
private:
    QVBoxLayout *lytMain;
    QHBoxLayout *lytPair;

    QLabel *lblName;
    QLabel *lblPrivate;
    QLabel *lblPublic;
    QLabel *lblSession;
    QLabel *lblMessage;
    QLabel *lblR;
    QLabel *lblS;
    QLabel *lblVerdict;

    QLineEdit *leMessage;
    QLineEdit *leR;
    QLineEdit *leS;

    QPushButton *btnGenerate;
    QPushButton *btnCrypt;
    QPushButton *btnCheck;


public:
    ElgamalTask(): Task("Метод Эль-Гамаля") {

    }

    void initWidget(QWidget *wgt) override {
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
    }

    void run() const override { }

};