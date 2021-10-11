#pragma once

#include <QWidget>
#include <QLabel>

#include "Task.h"

class GammaTask: public Task {
private:
    QLabel *label;

public:
    GammaTask(): Task("Метод однократного гаммирования") {

    }

    void initWidget(QWidget *wgt) override {
        label = new QLabel("Gamma", wgt);
    }

    void run() const override { }

};