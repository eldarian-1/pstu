#pragma once

#include <QWidget>
#include <QLabel>

#include "Task.h"

class HashTask: public Task {
private:
    QLabel *label;

public:
    HashTask(): Task("Хеширование") {

    }

    void initWidget(QWidget *wgt) override {
        label = new QLabel("Hash", wgt);
    }

    void run() const override { }

};