#pragma once

#include <QColor>
#include <QWidget>
#include <QSlider>
#include <QPainter>
#include <QVBoxLayout>

#include <iostream>

#include <Matrix.h>

class Dz4 : public QWidget {
private:
    Matrix _house{
            {0, 0, 0, 1}, // a
            {2, 0, 0, 1}, // b
            {2, 2, 0, 1}, // c
            {1, 3, 0, 1}, // d
            {0, 2, 0, 1}, // e
            {0, 0, 0, 1}, // a
            {0, 0, 2, 1}, // f
            {0, 2, 2, 1}, // j
            {1, 3, 2, 1}, // i
            {1, 3, 0, 1}, // d
            {1, 3, 2, 1}, // i
            {2, 2, 2, 1}, // h
            {2, 0, 2, 1}, // g
            {0, 0, 2, 1}, // f
            {0, 2, 2, 1}, // j
            {0, 2, 0, 1}, // e
            {2, 2, 0, 1}, // c
            {2, 2, 2, 1}, // h
            {0, 2, 2, 1}, // j
            {2, 2, 2, 1}, // h
            {2, 0, 2, 1}, // g
            {2, 0, 0, 1}, // b
    };
    QVBoxLayout *lytControls;
    QSlider *sldF, *sldT, *sldZ;

public:
    Dz4() : QWidget() {
        setWindowTitle("Д/З №4");
        resize(900, 700);
        lytControls = new QVBoxLayout;
        sldF = new QSlider;
        sldT = new QSlider;
        sldZ = new QSlider;
        this->setLayout(lytControls);
        lytControls->addWidget(sldF);
        lytControls->addWidget(sldT);
        lytControls->addWidget(sldZ);
    }

private:
    QPoint* getPoints(Matrix &matrix) {
        Matrix m = matrix.normalize();
        Matrix t = transfer3D(-m.min(0) + 100, -m.min(1) + 100, 0);
        m = (m * t);
        int _n = matrix.n();
        QPoint *result = new QPoint[_n];
        for(int i = 0; i < _n; ++i) {
            result[i] = QPoint(m[i][0], m[i][1]);
        }
        return result;
    }

protected:
    void paintEvent(QPaintEvent *event) override {
        Matrix t = scale3D(5, 5, 5);
        Matrix house = (_house * t);
        Matrix h = house.to2D(0.13, 0.6, 30);
        int size = h.n();
        QPoint *points = getPoints(h);

        QPainter painter;
        painter.begin(this);
        painter.drawPolygon(points, size);
        painter.end();
        delete[] points;
    }
};
