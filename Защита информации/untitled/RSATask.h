#pragma once

#include <QWidget>
#include <QLabel>
//#include <QErrorMessage>

#include "Task.h"
#include "BigInt.h"

class RSA {
private:
    static int gcd(int a, int b) {
        if(a == 0 || b == 0) {
            return a + b;
        } else if(a > b) {
            return gcd(a % b, b);
        } else {
            return gcd(a, b % a);
        }
    }

    BigInt e, n, d;

    BigInt crypt(BigInt c, bool decrypt) {
        if(decrypt) {
            return BigInt::pow(c, d) % n;
        } else {
            return BigInt::pow(c, e) % n;
        }
    }

    ushort crypt(ushort c, bool decrypt) {
        return std::stoi(BigInt::to_string(crypt(BigInt((int)c), decrypt)));
    }

public:
    RSA(BigInt p, BigInt q) {
        n = p * q;
        e = -1;
        BigInt phi = (p - 1) * (q - 1);
        for(BigInt i = n; i > 1; --i) {
            if(i == phi) {
                continue;
            }
            BigInt t0 = BigInt::gcd(i, phi);
            if(t0 == 1) {
                e = i;
                break;
            }
        }
        if(e == -1) throw -1;
        for(int i = 1; ; ++i) {
            int top = (i * std::stoi(BigInt::to_string(phi)) + 1);
            int bottom = std::stoi(BigInt::to_string(e));
            if((double)bottom / gcd(top, bottom) == 1.0) {
                d = BigInt(top / bottom);
                break;
            }
        }
    }

    RSA(const QString &p, const QString &q)
        : RSA(BigInt(p.toStdString()), BigInt(q.toStdString())) {

    }

    QString crypt(const QString &in, bool decrypt = false) {
        QString result;
        for(QChar c : in) {
            result.append(QChar(crypt(c.unicode(), decrypt)));
        }
        return result;
    }

    QString decrypt(const QString &out) {
        return crypt(out, true);
    }
};

class RSATask: public QObject, public Task {
Q_OBJECT
private:
    QLabel *label;
    QVBoxLayout *lytMain;
    QHBoxLayout *lytNums;
    QHBoxLayout *lytBtns;
    QLabel *lblP;
    QLabel *lblQ;
    QLabel *lblIn;
    QLabel *lblOut;
    QLineEdit *txtP;
    QLineEdit *txtQ;
    QLineEdit *txtIn;
    QLineEdit *txtOut;
    QPushButton *btnCrypt;
    QPushButton *btnDecrypt;

public slots:
    void crypt() {
        const QString &p = txtP->text();
        const QString &q = txtQ->text();
        const QString &in = txtIn->text();
        const QString &out = RSA(p, q).crypt(in);
        txtOut->setText(out);
    }

    void decrypt() {
        const QString &p = txtP->text();
        const QString &q = txtQ->text();
        const QString &out = txtOut->text();
        const QString &in = RSA(p, q).decrypt(out);
        txtIn->setText(in);
    }

public:
    RSATask(): Task("Алгоритм RSA") {

    }

    void initWidget(QWidget *wgt) override {
        lytMain = new QVBoxLayout();
        lytNums = new QHBoxLayout();
        lytBtns = new QHBoxLayout();
        lblP = new QLabel("P");
        lblQ = new QLabel("Q");
        lblIn = new QLabel("Расшифрованная часть");
        lblOut = new QLabel("Зашифрованная часть");
        txtP = new QLineEdit();
        txtQ = new QLineEdit();
        txtIn = new QLineEdit();
        txtOut = new QLineEdit();
        btnCrypt = new QPushButton("Зашифровать");
        btnDecrypt = new QPushButton("Расшифровать");
        wgt->setLayout(lytMain);
        lytMain->addLayout(lytNums);
        lytNums->addWidget(lblP);
        lytNums->addWidget(txtP);
        lytNums->addWidget(lblQ);
        lytNums->addWidget(txtQ);
        lytMain->addWidget(lblIn);
        lytMain->addWidget(txtIn);
        lytMain->addWidget(lblOut);
        lytMain->addWidget(txtOut);
        lytMain->addLayout(lytBtns);
        lytBtns->addWidget(btnCrypt);
        lytBtns->addWidget(btnDecrypt);
        connect(btnCrypt, SIGNAL(released()), this, SLOT(crypt()));
        connect(btnDecrypt, SIGNAL(released()), this, SLOT(decrypt()));
    }

    void run() const override {
        /*QErrorMessage message = QErrorMessage();
        QString s;
        for(int i = 0; i < 32; ++i) {
            s.append(QChar(QString("а")[0].unicode() + i));
        }
        message.showMessage("RSA\n" + s);
        message.exec();*/
    }

};