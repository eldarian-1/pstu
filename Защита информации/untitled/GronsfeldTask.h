#pragma once

#include <QWidget>
#include <QLabel>
#include <QErrorMessage>

#include "Task.h"

class Code;
std::string crypt(const std::string &str, const Code &code);
char crypt(const char &c, const int &code);

class Code {
private:
    int* _code;
    int _size;

public:
    Code(const int &code) {
        int temp = code, i;
        _size = 0;
        while(temp != 0) {
            temp /= 10;
            ++_size;
        }
        _code = new int[_size];
        for(i = _size - 1, temp = code; i >= 0; ++i) {
            _code[i] = temp % 10;
            temp /= 10;
        }
    }
    const int &size() const {
        return _size;
    }
    const int *code() const {
        return _code;
    }
};

std::string crypt(const std::string &str, const Code &code) {
    int n = code.size();
    std::stringstream result;
    for(int i = 0; i < n; ++i) {
        result << crypt(str[i], code.code()[i]);
    }
    return result.str();
}

char crypt(const char &c, const int &code) {
    static const char alph[] = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
                               "abcdefghijklmnopqrstuvwxyz"
                               "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЪЫЭЮЯ"
                               "абвгдеёжзийклмнопрстуфхцчшщьъыэюя";
    static const int size = sizeof(alph);
}

class GronsfeldTask: public Task {
public:
    GronsfeldTask(): Task("Шифр Гронсфельда") {

    }

    void initWidget(QWidget *wgt) override {
        wgt->setGeometry(0, 0, 360, 480);
        new QLabel("Шифр Гронсфельда", wgt);
    }

    void run() const override {
        /*QErrorMessage message = QErrorMessage();
        message.showMessage("Шифр Гронсфельда");
        message.exec();*/
    }

};