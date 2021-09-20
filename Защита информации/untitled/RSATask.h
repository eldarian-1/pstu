#pragma once

#include <QWidget>
#include <QLabel>
//#include <QErrorMessage>

#include "Task.h"

class RSA {
private:
    static int gcd(int a, int b) {
        if(a == b) return a;
        if(a > b) return gcd(a - b, b);
        else return gcd(a, b - a);
    }

    static std::tuple<int, int, int> gcf(int a, int b) {
        if(b == 0) {
            return {1, 0, a};
        } else {
            int x, y, g;
            std::tie(x, y, g) = gcf(b, a % b);
            return {y, x - (a / b) * y, g};
        }
    }


public:
    RSA(int p, int q) {
        int n = p * q;
        int e = -1;
        int t = (p - 1) * (q - 1);
        for(int i = n; i > 1; --i) {
            int t0 = gcd(i, t);
            if(t0 == 1) {
                e = i;
                break;
            }
        }
        if(e == -1) throw -1;

    }


};

class RSATask: public Task {
private:
    QLabel *label;

public:
    RSATask(): Task("Алгоритм RSA") {

    }

    void initWidget(QWidget *wgt) override {
        label = new QLabel("RSA", wgt);
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