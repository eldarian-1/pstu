#pragma once

#include <iostream>
#include <sstream>

#include <QWidget>
#include <QLabel>
#include <QTextEdit>
#include <QPushButton>
#include <QVBoxLayout>
#include <QHBoxLayout>
#include <QErrorMessage>

#include "Task.h"

class Code;
std::string crypt(const std::string &str, const Code &code);
char crypt(const char &c, const int &code);

class Code {
private:
    constexpr static const char alphabet[] = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    static const int size = sizeof(alphabet);

    int* _code;
    int _size;

    char crypt(const char &c, const int &term) {
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

    char decrypt(const char &c, const int &term) {
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

public:
    Code(const int &code) {
        int temp = code, i;
        _size = 0;
        while(temp != 0) {
            temp /= 10;
            ++_size;
        }
        _code = new int[_size];
        for(i = _size - 1, temp = code; i >= 0; --i) {
            _code[i] = temp % 10;
            temp /= 10;
        }
    }

    std::string crypt(const std::string &str) {
        std::stringstream result;
        for(int i = 0, j = 0; i < str.size(); ++i) {
            result << crypt(str[i], _code[j]);
            j == _size ? j = 0 : ++j;
        }
        return result.str();
    }

    std::string decrypt(const std::string &str) {
        std::stringstream result;
        for(int i = 0, j = 0; i < str.size(); ++i) {
            result << decrypt(str[i], _code[j]);
            j == _size ? j = 0 : ++j;
        }
        return result.str();
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
    QTextEdit *txtNumber;
    QTextEdit *txtIn;
    QTextEdit *txtOut;
    QPushButton *btnCrypt;
    QPushButton *btnDecrypt;

public slots:
    void crypt() {
        int number = txtNumber->toPlainText().toInt();
        std::string in = txtIn->toPlainText().toStdString();
        std::string out = Code(number).crypt(in);
        txtOut->setPlainText(out.c_str());
    }

    void decrypt() {
        int number = txtNumber->toPlainText().toInt();
        std::string out = txtOut->toPlainText().toStdString();
        std::string in = Code(number).decrypt(out);
        txtIn->setPlainText(in.c_str());
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
        txtNumber = new QTextEdit();
        txtIn = new QTextEdit();
        txtOut = new QTextEdit();
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