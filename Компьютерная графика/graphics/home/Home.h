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

#include <cmath>
using namespace std;

class Home : public QWidget {
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
    Home() : QWidget() {
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
        sldF->setValue(43);
        sldT->setMinimum(0);
        sldT->setMaximum(360);
        sldT->setValue(140);
        sldZ->setMinimum(0);
        sldZ->setMaximum(1000);
        sldZ->setValue(249);

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
    Matrix resultMatrix(Matrix &vp, int width, int height) {
        const int k = 50;
        int F = sldF->value(), T = sldT->value();
        double f = Const::PI / 180 * F;
        double t = Const::PI / 180 * T;
        int zc = sldZ->value();
        lblF->setText(QString::asprintf("f: %d", F));
        lblT->setText(QString::asprintf("t: %d", T));
        lblZ->setText(QString::asprintf("Zc: %d", zc));
        Matrix result = (_house * Matrix::scale3D(k, k, k) * Matrix::super(t, f, zc)).normalize()
                * Matrix::transfer3D(width / 2, height / 2, 0);
        vp = Matrix::super(t, f, zc).vanishingPoints() * Matrix::transfer3D(width / 2, height / 2, 0);
        lblInfo->setText(
                QString::asprintf(
                        "Точки схода\nx: (%f, %f)\ny: (%f, %f)\nz: (%f, %f)\nИскажения:\nfx: %f\nfy: %f\nfz: %f",
                        vp[0][0],  vp[0][1],  vp[1][0],  vp[1][1],  vp[2][0],  vp[2][1],
                        sqrt(pow(cos(f), 2) + pow(sin(f) * cos(t), 2)),
                        abs(cos(f)),
                        sqrt(pow(sin(f), 2) + pow(cos(f) * sin(t), 2))
                        ));
        return result;
    }

    void drawPoint(QPainter *painter, QString name, double x, double y) {
        painter->setPen(QPen(Qt::red, 5));
        painter->drawPoint(x,  y);
        painter->setPen(QPen(Qt::black));
        painter->drawText(x + 10, y + 5, name);
    }

protected:
    void paintEvent(QPaintEvent *event) override {
        int width = this->width(), height = this->height();
        Matrix vp, house = resultMatrix(vp, width, height);
        QPoint *points = Graphic::getPoints(house);
        QPainter painter;
        painter.begin(this);
        painter.setBrush(Qt::white);
        painter.drawRect(0, 0, width, height);
        painter.setPen(QPen(Qt::darkBlue, 2));
        painter.drawPolygon(points, house.n());
        delete[] points;
        drawPoint(&painter, "X", vp[0][0],  vp[0][1]);
        drawPoint(&painter, "Y", vp[1][0],  vp[1][1]);
        drawPoint(&painter, "Z", vp[2][0],  vp[2][1]);
        painter.end();
    }

private slots:
    void sliderChanged() {
        repaint();
    }

};
