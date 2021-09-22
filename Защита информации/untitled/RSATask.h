#pragma once

#include <QWidget>
#include <QLabel>
//#include <QErrorMessage>

#include "Task.h"
#include "BigInt.h"

class RSA {
private:
    static std::tuple<BigInt, BigInt, BigInt> gcf(BigInt a, BigInt b) {
        if(b == 0) {
            return {1, 0, a};
        } else {
            BigInt x, y, g;
            std::tie(x, y, g) = gcf(b, a % b);
            return {y, x - (a / b) * y, g};
        }
    }

    BigInt e, n, d;

public:
    RSA(BigInt p, BigInt q) {
        n = p * q;
        e = -1;
        BigInt t = (p - 1) * (q - 1);
        for(BigInt i = n; i > 1; --i) {
            BigInt t0 = BigInt::gcd(i, t);
            if(t0 == 1) {
                e = i;
                break;
            }
        }
        if(e == -1) throw -1;
        std::tuple<BigInt, BigInt, BigInt> d = gcf(e, t);
    }

    RSA(const QString &p, const QString &q)
        : RSA(BigInt(p.toStdString()), BigInt(q.toStdString())) {

    }

    QString crypt(const QString &in) {
        return "Hello, World!";
    }

    QString decrypt(const QString &out) {
        return "Привет, Мир!";
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