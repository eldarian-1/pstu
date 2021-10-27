#include "CicleTask.h"

#include <QLabel>
#include <QBitArray>
#include <QLineEdit>
#include <QTextEdit>
#include <QPushButton>
#include <QVBoxLayout>

void CicleTask::initWidget(QWidget *wgt) {
    lytMain = new QVBoxLayout;
    lblName = new QLabel("Метод циклических кодов");
    lblSource = new QLabel("Отправляемый текст");
    leSource = new QLineEdit;
    lblReceived = new QLabel("Полученный текст");
    teTarget = new QTextEdit;
    lblTarget = new QLabel;
    btnCorrect = new QPushButton("Исправить ошибки");

    wgt->setLayout(lytMain);
    wgt->setFixedHeight(400);
    lytMain->setAlignment(Qt::AlignTop);
    lytMain->addWidget(lblName);
    lytMain->addWidget(lblSource);
    lytMain->addWidget(leSource);
    lytMain->addWidget(lblReceived);
    lytMain->addWidget(teTarget);
    lytMain->addWidget(lblTarget);
    lytMain->addWidget(btnCorrect);

    connect(leSource, SIGNAL(textChanged(QString)), SLOT(sourceChanged(QString)));
    connect(teTarget, SIGNAL(textChanged()), SLOT(targetChanged()));
    connect(btnCorrect, SIGNAL(released()), SLOT(correctReleased()));
}

void CicleTask::sourceChanged(const QString &text) {
    teTarget->setText(bitsAsString(stringToBits(text)));
}

void CicleTask::targetChanged() {
    lblTarget->setText(bitsToString(stringAsBits(teTarget->toPlainText())));
}

void CicleTask::correctReleased() {
    teTarget->setText(bitsAsString(correct(stringToBits(leSource->text()))));
}

QBitArray CicleTask::stringToBits(const QString &text) {
    int size = text.size();
    QBitArray result(size * 16);
    for(int i = 0; i < size; ++i) {
        ushort symbol = text[i].unicode();
        for(int j = 0; j < 16; ++j) {
            result[i * 16 + 15 - j] = symbol % 2;
            symbol /= 2;
        }
    }
    return result;
}

QString CicleTask::bitsToString(const QBitArray &bits) {
    QString result;
    int size = bits.size() / 16;
    for(int i = 0; i < size; ++i) {
        ushort symbol = 0;
        for(int j = 0; j < 16; ++j) {
            symbol *= 2;
            symbol += bits[i * 16 + j];
        }
        result += QChar(symbol);
    }
    return result;
}

QString CicleTask::bitsAsString(const QBitArray &&bits) {
    QString result;
    int size = bits.size();
    for(int i = 0; i < size; ++i) {
        result += bits[i] ? "1" : "0";
    }
    return result;
}

QBitArray CicleTask::stringAsBits(const QString &text) {
    int size = text.size();
    QBitArray result(size);
    for(int i = 0; i < size; ++i) {
        result[i] = text[i] != '0';
    }
    return result;
}

QBitArray CicleTask::correct(const QBitArray &&bits) {
    QBitArray result(bits);
    result[0] = 1;
    return result;
}
