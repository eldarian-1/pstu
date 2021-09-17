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
    constexpr static const char alphabet[] = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    static const int size = sizeof(alphabet);

    std::vector<int> _code;

    bool check(const char &c) {
        return c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z';
    }

    char cry(const char &c, const int &term) {
        char index = 0;
        if(c >= 'A' && c <= 'Z') {
            index += c - 'A';
        } else if(c >= 'a' && c <= 'z') {
            index += c - 'a' + 26;
        }
        int temp = index + term;
        temp = temp < 0? temp + size : temp >= 52 ? temp - 52 : temp;
        return alphabet[temp];
    }

    char decry(const char &c, const int &term) {
        char index = 0;
        if(c >= 'A' && c <= 'Z') {
            index += c - 'A';
        } else if(c >= 'a' && c <= 'z') {
            index += c - 'a' + 26;
        }
        int temp = index - term;
        temp = temp < 0? temp + size : temp >= 52 ? temp - 52 : temp;
        return alphabet[temp];
    }

public:
    Code(const std::string &code) {
        for(int i = 0; i < code.size(); ++i) {
            if(code[i] >= '0' && code[i] <= '9') {
                _code.push_back(code[i] - '0');
            }
        }
    }

    std::string crypt(const std::string &str, bool dec = false) {
        std::stringstream result;
        for(int i = 0, j = 0; i < str.size(); ++i) {
            result << (check(str[i]) ? (dec ? &decry : &cry)(str[i], _code[j]) : str[i]);
            ++j == _code.size() ? j = 0 : j;
        }
        return result.str();
    }

    std::string decrypt(const std::string &str) {
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
        std::string number = txtNumber->text().toStdString();
        std::string in = txtIn->text().toStdString();
        std::string out = Code(number).crypt(in);
        txtOut->setText(out.c_str());
    }

    void decrypt() {
        std::string number = txtNumber->text().toStdString();
        std::string out = txtOut->text().toStdString();
        std::string in = Code(number).decrypt(out);
        txtIn->setText(in.c_str());
    }

public:
    GronsfeldTask(): Task("Шифр Гронсфельда") {

    }

    void initWidget(QWidget *wgt) override {
        wgt->setGeometry(0, 0, 360, 480);
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

    void run() const override {}

};