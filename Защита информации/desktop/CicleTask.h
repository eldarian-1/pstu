#pragma once

#include <QWidget>
#include <QLabel>

#include "Task.h"

class CicleTask: public Task {
private:
    QLabel *label;

public:
    CicleTask(): Task("Метод циклических кодов") {

    }

    void initWidget(QWidget *wgt) override {
        label = new QLabel("Cicle", wgt);
    }

    void run() const override { }

};