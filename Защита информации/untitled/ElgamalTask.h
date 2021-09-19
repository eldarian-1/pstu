#pragma once

#include <QWidget>
#include <QLabel>

#include "Task.h"

class ElgamalTask: public Task {
private:
    QLabel *label;

public:
    ElgamalTask(): Task("Метод Эль-Гамаля") {

    }

    void initWidget(QWidget *wgt) override {
        label = new QLabel("Elgamal", wgt);
    }

    void run() const override { }

};