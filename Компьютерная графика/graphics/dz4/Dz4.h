#pragma once

#include <QTimer>
#include <QColor>
#include <QLabel>
#include <QWidget>
#include <QSlider>
#include <QPainter>
#include <QVBoxLayout>

#include <iostream>

#include <Matrix.h>
#include <common.h>

class Dz4 : public QWidget {
Q_OBJECT

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
    QLabel *lblF, *lblT, *lblZ;
    QSlider *sldF, *sldT, *sldZ;

public:
    Dz4() : QWidget() {
        setWindowTitle("Д/З №4");
        resize(900, 700);
        lytControls = new QVBoxLayout;
        lblF = new QLabel("f");
        lblT = new QLabel("t");
        lblZ = new QLabel("Zc");
        sldF = new QSlider;
        sldT = new QSlider;
        sldZ = new QSlider;

        sldF->setMinimum(0);
        sldF->setMaximum(360);
        sldF->setValue(15);
        sldT->setMinimum(0);
        sldT->setMaximum(360);
        sldT->setValue(5);
        sldZ->setMinimum(0);
        sldZ->setMaximum(1000);
        sldZ->setValue(100);

        this->setLayout(lytControls);
        lytControls->addWidget(lblF);
        lytControls->addWidget(sldF);
        lytControls->addWidget(lblT);
        lytControls->addWidget(sldT);
        lytControls->addWidget(lblZ);
        lytControls->addWidget(sldZ);

        QTimer *timer = new QTimer(this);
        connect(timer, SIGNAL(timeout()), SLOT(repaint()));
        timer->start(20);
    }

private:
    QPoint* getPoints(Matrix &matrix) {
        Matrix m = matrix.normalize();
        Matrix t = transfer3D(450, 350, 0);//transfer3D(-m.min(0) + 100, -m.min(1) + 100, 0);
        m = (m * t);
        int n = matrix.n();
        QPoint *result = new QPoint[n];
        for(int i = 0; i < n; ++i) {
            result[i] = QPoint(m[i][0], m[i][1]);
        }
        return result;
    }

protected:
    void paintEvent(QPaintEvent *event) override {
        double t = PI / 180 * sldT->value();
        double f = PI / 180 * sldF->value();
        Matrix h = _house.to2D(t, f, sldZ->value());
        QPoint *points = getPoints(h);
        QPainter painter;
        painter.begin(this);
        painter.drawPolygon(points, h.n());
        painter.end();
        delete[] points;
    }

};
