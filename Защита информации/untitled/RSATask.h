#pragma once

#include <QWidget>
#include <QLabel>
#include <utility>
//#include <QErrorMessage>

#include "Task.h"
#include "BigInt.h"

class RsaClient {
private:
    BigInt e, n;

    BigInt crypt(const BigInt& c) {
        return BigInt::pow(c, e) % n;
    }

    ushort crypt(ushort c) {
        return std::stoi(BigInt::to_string(crypt(BigInt((int)c))));
    }

public:
    RsaClient(const BigInt& e, const BigInt& n) : e(e), n(n) { }

    QString crypt(const QString &in) {
        QString result;
        for(QChar c : in) {
            result.append(QChar(crypt(c.unicode())));
        }
        return result;
    }

    const BigInt& E() {
        return e;
    }

    const BigInt& N() {
        return n;
    }
};

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

public:
    RSA(const BigInt& p, const BigInt& q) {
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

    RsaClient *alice() {
        return new RsaClient(d, n);
    }

    RsaClient *bob() {
        return new RsaClient(e, n);
    }
};

class RSATask: public QObject, public Task {
Q_OBJECT
private:
    QHBoxLayout *lytMain;
    QVBoxLayout *lytAlice;
    QVBoxLayout *lytBob;
    QHBoxLayout *lytPQ;
    QHBoxLayout *lytABtns;
    QHBoxLayout *lytEN;
    QHBoxLayout *lytBBtns;

    QLabel *lblAlice;
    QLabel *lblBob;
    QLabel *lblP;
    QLabel *lblQ;
    QLabel *lblE;
    QLabel *lblN;
    QLabel *lblPrivate;
    QLabel *lblPublic;
    QLabel *lblAIn;
    QLabel *lblAOut;
    QLabel *lblBIn;
    QLabel *lblBOut;

    QLineEdit *txtP;
    QLineEdit *txtQ;
    QLineEdit *txtE;
    QLineEdit *txtN;
    QLineEdit *txtAIn;
    QLineEdit *txtAOut;
    QLineEdit *txtBIn;
    QLineEdit *txtBOut;

    QPushButton *btnACrypt;
    QPushButton *btnADecrypt;
    QPushButton *btnBCrypt;
    QPushButton *btnBDecrypt;

    RsaClient *alice = nullptr;
    RsaClient *bob = nullptr;

public slots:
    void aCrypt() {
        if(alice) {
            delete alice;
            delete bob;
            alice = nullptr;
            bob = nullptr;
        }
        const QString &p = txtP->text();
        const QString &q = txtQ->text();
        RSA rsa(p, q);
        alice = rsa.alice();
        bob = rsa.bob();
        lblPrivate->setText(("Закрытый: d - " + BigInt::to_string(alice->E()) + ", n - "  + BigInt::to_string(alice->E())).c_str());
        lblPublic->setText(("Открытый: e - " + BigInt::to_string(bob->E()) + ", n - " + BigInt::to_string(bob->N())).c_str());
        txtE->setText(BigInt::to_string(bob->E()).c_str());
        txtN->setText(BigInt::to_string(bob->N()).c_str());
        const QString &in = txtAIn->text();
        const QString &out = alice->crypt(in);
        txtBOut->setText(out);
    }

    void aDecrypt() {
        const QString &in = txtAOut->text();
        const QString &out = alice->crypt(in);
        txtAIn->setText(out);
    }

    void bCrypt() {
        const QString &in = txtBIn->text();
        const QString &out = bob->crypt(in);
        txtAOut->setText(out);
    }

    void bDecrypt() {
        const QString &in = txtBOut->text();
        const QString &out = bob->crypt(in);
        txtBIn->setText(out);
    }

public:
    RSATask(): Task("Алгоритм RSA") {

    }

    void initWidget(QWidget *wgt) override {
        lytMain = new QHBoxLayout();
        lytAlice = new QVBoxLayout();
        lytBob = new QVBoxLayout();
        lytPQ = new QHBoxLayout();
        lytABtns = new QHBoxLayout();
        lytEN = new QHBoxLayout();
        lytBBtns = new QHBoxLayout();

        lytAlice->setAlignment(Qt::Alignment::enum_type::AlignTop);
        lytBob->setAlignment(Qt::Alignment::enum_type::AlignTop);

        lblAlice = new QLabel("Alice");
        lblBob = new QLabel("Bob");
        lblP = new QLabel("p");
        lblQ = new QLabel("q");
        lblE = new QLabel("e");
        lblN = new QLabel("n");
        lblPrivate = new QLabel("Закрытый: d - ..., n - ...");
        lblPublic = new QLabel("Открытый: e - ..., n - ...");
        lblAIn = new QLabel("Открытый текст");
        lblAOut = new QLabel("Шифротекст");
        lblBIn = new QLabel("Открытый текст");
        lblBOut = new QLabel("Шифротекст");

        txtP = new QLineEdit();
        txtQ = new QLineEdit();
        txtE = new QLineEdit();
        txtN = new QLineEdit();
        txtAIn = new QLineEdit();
        txtAOut = new QLineEdit();
        txtBIn = new QLineEdit();
        txtBOut = new QLineEdit();

        btnACrypt = new QPushButton("Отправить");
        btnADecrypt = new QPushButton("Расшифровать");
        btnBCrypt = new QPushButton("Отправить");
        btnBDecrypt = new QPushButton("Расшифровать");

        wgt->setLayout(lytMain);
        lytMain->addLayout(lytAlice);
        lytAlice->addWidget(lblAlice);
        lytAlice->addLayout(lytPQ);
        lytPQ->addWidget(lblP);
        lytPQ->addWidget(txtP);
        lytPQ->addWidget(lblQ);
        lytPQ->addWidget(txtQ);
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

        connect(btnACrypt, SIGNAL(released()), this, SLOT(aCrypt()));
        connect(btnADecrypt, SIGNAL(released()), this, SLOT(aDecrypt()));
        connect(btnBCrypt, SIGNAL(released()), this, SLOT(bCrypt()));
        connect(btnBDecrypt, SIGNAL(released()), this, SLOT(bDecrypt()));
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