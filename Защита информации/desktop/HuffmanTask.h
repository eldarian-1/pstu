#pragma once

#include <QWidget>
#include <QLabel>

#include "Task.h"

class HuffmanTask: public Task {
private:
    QLabel *label;

public:
    HuffmanTask(): Task("Алгоритм Хаффмана") {

    }

    void initWidget(QWidget *wgt) override {
        label = new QLabel("Huffman", wgt);
    }

    void run() const override { }

};