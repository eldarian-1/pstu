#pragma once

#include <QWidget>
#include <QLabel>

#include "Task.h"

class DESTask: public Task {
private:
    QLabel *label;

public:
    DESTask(): Task("Методика DES") {

    }

    void initWidget(QWidget *wgt) override {
        label = new QLabel("DES", wgt);
    }

    void run() const override { }

};