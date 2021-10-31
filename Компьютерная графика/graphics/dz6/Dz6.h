#pragma once

#include <QColor>
#include <QWidget>
#include <QPainter>

#include <Matrix.h>

class Dz6 : public QWidget {
private:
    static const int steps = 100;
    Matrix matrix {
            {100, 350},
            {250, 450},
            {350, 600},
            {450, 450},
            {550, 600},
            {650, 450},
            {800, 350},
            {650, 250},
            {550, 100},
            {450, 250},
            {350, 100},
            {250, 250},
    };

public:
    Dz6();

protected:
    void paintEvent(QPaintEvent *event) override;

};
