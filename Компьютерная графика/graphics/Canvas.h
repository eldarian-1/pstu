#pragma once

#include <QWidget>

class Canvas: public QWidget {
public:
    Canvas() : QWidget() {
        resize(1000, 500);
    }
};