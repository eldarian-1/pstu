#pragma once

#include <QWidget>
#include <QLabel>
//#include <QErrorMessage>

#include "Task.h"

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