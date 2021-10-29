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
    teSource = new QTextEdit;
    lblEncoded = new QLabel("Закодированный бинарный текст");
    teEncoded = new QTextEdit;
    lblDecoded = new QLabel("Декодированный текст");
    teDecoded = new QTextEdit;
    leDecoded = new QLineEdit;
    btnCorrect = new QPushButton("Исправить ошибки");

    teSource->setDisabled(true);
    teDecoded->setDisabled(true);
    leDecoded->setDisabled(true);

    wgt->setLayout(lytMain);
    wgt->setFixedHeight(400);
    lytMain->setAlignment(Qt::AlignTop);
    lytMain->addWidget(lblName);
    lytMain->addWidget(lblSource);
    lytMain->addWidget(leSource);
    lytMain->addWidget(teSource);
    lytMain->addWidget(lblEncoded);
    lytMain->addWidget(teEncoded);
    lytMain->addWidget(lblDecoded);
    lytMain->addWidget(leDecoded);
    lytMain->addWidget(teDecoded);
    lytMain->addWidget(btnCorrect);

    connect(leSource, SIGNAL(textChanged(QString)), SLOT(sourceChanged(QString)));
    connect(teEncoded, SIGNAL(textChanged()), SLOT(encodedChanged()));
    connect(btnCorrect, SIGNAL(released()), SLOT(correctReleased()));
}

void CicleTask::sourceChanged(const QString &text) {
    QBitArray bits = stringToBits(text);
    QBitArray encoded = encode(bits);
    teSource->setText(bitsAsString(bits));
    teEncoded->setText(bitsAsString(encoded));
}

void CicleTask::encodedChanged() {
    QBitArray bits = stringAsBits(teEncoded->toPlainText());
    QBitArray decoded = decode(bits);
    teDecoded->setText(bitsAsString(decoded));
    leDecoded->setText(bitsToString(decoded));
}

void CicleTask::correctReleased() {
    teEncoded->setText(bitsAsString(correct(stringAsBits(teSource->toPlainText()))));
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

QString CicleTask::bitsAsString(const QBitArray &bits) {
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

QBitArray CicleTask::correct(const QBitArray &bits) {
    QBitArray result(bits);
    result[0] = 1;
    return result;
}

QBitArray CicleTask::encode(const QBitArray &bits) {
    QVector<QBitArray> devs = divide(bits, 4);
    for(int i = 0, n = devs.size(); i < n; ++i) {
        devs[i] = bit4to7(devs[i]);
    }
    return sum(devs, 7);
}

QBitArray CicleTask::decode(const QBitArray &bits) {
    QVector<QBitArray> devs = divide(bits, 7);
    for(int i = 0, n = devs.size(); i < n; ++i) {
        devs[i] = bit7to4(devs[i]);
    }
    return sum(devs, 4);
}

QVector<QBitArray> CicleTask::divide(const QBitArray &bits, int denominator) {
    int size = bits.size() / denominator;
    QVector<QBitArray> result(size, QBitArray(denominator));
    for(int i = 0; i < size; ++i) {
        for(int j = 0; j < denominator; ++j) {
            result[i][j] = bits[i * denominator + j];
        }
    }
    return result;
}

QBitArray CicleTask::sum(const QVector<QBitArray> &bits, int denominator) {
    int size = bits.size();
    QBitArray result(size * denominator);
    for(int i = 0; i < size; ++i) {
        for(int j = 0; j < denominator; ++j) {
            result[i * denominator + j] = bits[i][j];
        }
    }
    return result;
}

QBitArray CicleTask::bit4to7(const QBitArray &bits) {
    QBitArray result(7, 0);
    auto sdvig = [](const QBitArray& in) -> QBitArray {
        int size = in.size();
        QBitArray result(size, 0);
        for(int i = 1; i < size; ++i) {
            result[i] = in[i - 1];
        }
        return result;
    };
    auto summod = [](const QBitArray& a, const QBitArray& b, const QBitArray& d, int i) -> int {
        return (a[i] + b[i] + d[i]) % 2;
    };
    auto bitArray = [](const QBitArray& a, int size) -> QBitArray {
        QBitArray result(size);
        for(int i = 0, n = a.size(); i < n; ++i) {
            result[i] = a[i];
        }
        return result;
    };
    auto a = bitArray(bits, 7);
    auto b = sdvig(a);
    auto c = sdvig(b);
    auto d = sdvig(c);
    for(int i = 0; i < 7; ++i) {
        result[i] = summod(a, b, d, i);
    }
    return result;
}

QBitArray CicleTask::bit7to4(const QBitArray &bits) {
    QBitArray result(4, 0);
    for(int i = 0; i < 4; ++i) {
        result[i] = bits[i];
    }
    return result;
}
