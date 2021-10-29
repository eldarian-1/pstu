#include "CicleTask.h"

#include <QLabel>
#include <QBitArray>
#include <QLineEdit>
#include <QTextEdit>
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

    connect(leSource, SIGNAL(textChanged(QString)), SLOT(sourceChanged(QString)));
    connect(teEncoded, SIGNAL(textChanged()), SLOT(encodedChanged()));
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
    QBitArray s(7, 0);
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
        QBitArray result(size, 0);
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
        s[i] = summod(a, b, d, i);
    }
    return s;
}

QBitArray CicleTask::bit7to4(const QBitArray &s) {
    QBitArray result(4, 0);
    QBitArray r0(7, 0), r1(7, 0), r2(7, 0), a(7, 0);
    r0[0] = s[6];
    for(int i = 1; i < 7; ++i) {
        r2[i] = r1[i - 1];
        a[i] = r2[i - 1];
        r0[i] = (a[i] + s[6 - i]) % 2;
        r1[i] = (a[i] + r0[i - 1]) % 2;
        if(i >= 3) {
            result[6 - i] = a[i];
        }
    }
    return plus(result, code(r0[6], r1[6], r2[6]));
}

QBitArray CicleTask::plus(const QBitArray &left, const QBitArray &right) {
    int n = left.size();
    QBitArray result(left);
    for(int i = 0; i < n; ++i) {
        result[i] = (result[i] + right[i]) % 2;
    }
    return result;
}

QBitArray CicleTask::code(bool r0, bool r1, bool r2) {
    int p = e({r0, r1, r2});
    switch(p) {
        case 6: // 4
            return c({1, 0, 0, 0});
        case 3: // 5
            return c({0, 1, 0, 0});
        case 7: // 6
            return c({1, 0, 1, 0});
        case 5: // 7
            return c({1, 1, 0, 1});
        default: // с 1 по 3
            return c({0, 0, 0, 0});
    }
}

QBitArray CicleTask::c(std::initializer_list<int> vector) {
    int size = vector.size();
    QBitArray result(size);
    for(int i = 0; i < size; ++i) {
        result[i] = *(vector.begin() + i);
    }
    return result;
}

int CicleTask::e(std::initializer_list<int> vector) {
    int result = 0;
    for(int i = 0, n = vector.size(); i < n; ++i) {
        result *= 2;
        result += *(vector.begin() + i);
    }
    return result;
}