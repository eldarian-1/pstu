#pragma once

#include <QTimer>
#include <QColor>
#include <QLabel>
#include <QWidget>
#include <QSlider>
#include <QPainter>
#include <QVBoxLayout>

#include <Const.h>
#include <Matrix.h>
#include <Splines.h>
#include <Graphic.h>

class Dz4 : public QWidget {
Q_OBJECT

private:
    Matrix _house {
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
    QLabel *lblF, *lblT, *lblZ, *lblInfo;
    QSlider *sldF, *sldT, *sldZ;

public:
    Dz4() : QWidget() {
        setWindowTitle("Д/З №4");
        resize(900, 700);
        lytControls = new QVBoxLayout;
        lblF = new QLabel("f");
        lblT = new QLabel("t");
        lblZ = new QLabel("Zc");
        lblInfo = new QLabel("Точки схода\nx:\ny:\nz:");
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
        lytControls->addWidget(lblInfo);

        QTimer *timer = new QTimer(this);
        connect(timer, SIGNAL(timeout()), SLOT(sliderChanged()));
        timer->start(20);
    }

private:
    Matrix resultMatrix() {
        double t = Const::PI / 180 * sldT->value();
        double f = Const::PI / 180 * sldF->value();
        int zc = sldZ->value();
        Matrix result = _house.to2D(t, f, zc).normalize() * Matrix::transfer3D(450, 350, 0);
        Matrix vp = result.vanishingPoints();
        lblInfo->setText(
                QString::asprintf(
                        "Точки схода\nx: (%f, %f)\ny: (%f, %f)\nz: (%f, %f)",
                        vp[0][0],  vp[0][1],  vp[1][0],  vp[1][1],  vp[2][0],  vp[2][1]));
        return result;
    }

protected:
    void paintEvent(QPaintEvent *event) override {
        Matrix house = resultMatrix();
        QPoint *points = Graphic::getPoints(house);
        QPainter painter;
        painter.begin(this);
        painter.drawPolygon(points, house.n());
        painter.end();
        delete[] points;
    }

private slots:
    void sliderChanged() {
        repaint();
    }

};
