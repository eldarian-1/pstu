#pragma once

#include <iostream>
#include <sstream>

#include <QWidget>
#include <QLabel>
#include <QLineEdit>
#include <QPushButton>
#include <QVBoxLayout>
#include <QHBoxLayout>
#include <QErrorMessage>

#include "Task.h"

class Code {
private:
    static QString alphabet;

    static ushort get(int i) {
        return alphabet[i].unicode();
    }

    static bool check(const QChar &c, const QCharRef &a, const QCharRef &z) {
        ushort uc = c.unicode();
        return a.unicode() <= uc && uc <= z.unicode();
    }

    static bool check(const QChar &c) {
        return check(c, alphabet[0], alphabet[25]) ||
               check(c, alphabet[26], alphabet[51]) ||
               check(c, alphabet[52], alphabet[83]) ||
               check(c, alphabet[84], alphabet[115]);
    }

    static void index(int &i, const QChar &c, int begin, int end) {
        if(c >= get(begin) && c <= get(end)) {
            i = c.unicode() - get(begin) + begin;
        }
    }

    static QChar cry(const QChar &c, const int &term, bool decrypt = false) {
        int i;
        index(i, c, 0, 25);
        index(i, c, 26, 51);
        index(i, c, 52, 83);
        index(i, c, 84, 115);
        int temp = i + (decrypt ? -1 : 1) * term;
        int size = alphabet.size();
        temp = temp < 0 ? temp + size : (temp >= size ? temp - size : temp);
        return alphabet.constData()[temp];
    }

    std::vector<int> _code;

public:
    static QString alph() { return  alphabet; }

    explicit Code(const QString &code) {
        for(auto i : code) {
            if(i >= QChar('0') && i <= QChar('9')) {
                _code.push_back(i.unicode() - QChar('0').unicode());
            }
        }
    }

    QString crypt(const QString &str, bool decrypt = false) {
        QString result;
        for(int i = 0, j = 0; i < str.size(); ++i) {
            result.append(check(str[i]) ? cry(str[i], _code[j], decrypt) : str[i]);
            ++j == _code.size() ? j = 0 : j;
        }
        return result;
    }

    QString decrypt(const QString &str) {
        return crypt(str, true);
    }
};

class GronsfeldTask: public QObject, public Task {
    Q_OBJECT
private:
    QVBoxLayout *lytV;
    QHBoxLayout *lytH;
    QLabel *lblNumber;
    QLabel *lblIn;
    QLabel *lblOut;
    QLineEdit *txtNumber;
    QLineEdit *txtIn;
    QLineEdit *txtOut;
    QPushButton *btnCrypt;
    QPushButton *btnDecrypt;

public slots:
    void crypt() {
        QString number = txtNumber->text();
        QString in = txtIn->text();
        QString out = Code(number).crypt(in);
        txtOut->setText(out);
    }

    void decrypt() {
        QString number = txtNumber->text();
        QString out = txtOut->text();
        QString in = Code(number).decrypt(out);
        txtIn->setText(in);
    }

public:
    GronsfeldTask(): Task("Шифр Гронсфельда") { }

    void initWidget(QWidget *wgt) override {
        lytV = new QVBoxLayout();
        lytH = new QHBoxLayout();
        lblNumber = new QLabel("Ключ шифрования");
        lblIn = new QLabel("Расшифрованная часть");
        lblOut = new QLabel("Зашифрованная часть");
        txtNumber = new QLineEdit();
        txtIn = new QLineEdit();
        txtOut = new QLineEdit();
        btnCrypt = new QPushButton("Зашифровать");
        btnDecrypt = new QPushButton("Расшифровать");
        wgt->setLayout(lytV);
        lytV->setSpacing(10);
        lytV->setAlignment(Qt::Alignment::enum_type::AlignTop);
        lytV->addWidget(lblNumber);
        lytV->addWidget(txtNumber);
        lytV->addWidget(lblIn);
        lytV->addWidget(txtIn);
        lytV->addWidget(lblOut);
        lytV->addWidget(txtOut);
        lytV->addLayout(lytH);
        lytH->addWidget(btnCrypt);
        lytH->addWidget(btnDecrypt);
        connect(btnCrypt, SIGNAL(released()), this, SLOT(crypt()));
        connect(btnDecrypt, SIGNAL(released()), this, SLOT(decrypt()));
    }

    void run() const override {
        /*QErrorMessage message = QErrorMessage();
        message.showMessage(Code::alph());
        message.exec();*/
    }

};