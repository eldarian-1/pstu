#pragma once

#include <QWidget>
#include <QLabel>
#include <QErrorMessage>

#include "Task.h"

class PickTask: public Task {
private:
    QLabel *label;

public:
    PickTask(): Task("Формула Пика") {

    }

    void initWidget(QWidget *wgt) override {
        wgt->setGeometry(0, 0, 360, 480);
        label = new QLabel("Формула Пика", wgt);
    }

    void run() const override {
        QErrorMessage message = QErrorMessage();
        message.showMessage("Шифр Гронсфельда");
        message.exec();
    }

};