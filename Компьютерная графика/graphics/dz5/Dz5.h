#pragma once

#include <QTimer>
#include <QColor>
#include <QLabel>
#include <QWidget>
#include <QSlider>
#include <QPainter>
#include <QVBoxLayout>

#include <Matrix.h>

class Dz5 : public QWidget {
private:
    Matrix left {
            {80, 30, 1},
            {100, 35, 1},
            {90, 10, 1},
            {100, 10, 1},
            {90, 10, 1},
            {100, 35, 1},
            {80, 30, 1},
            {100, 40, 1},
            {90, 20, 1},
            {100, 20, 1},
            {90, 20, 1},
            {100, 40, 1},
            {80, 30, 1},
            {60, 60, 1},
            {50, 82, 1},
            {60, 100, 1},
            {50, 82, 1},
            {60, 60, 1},
            {75, 80, 1},
            {70, 100, 1},
            {75, 80, 1},
            {60, 60, 1},
            {78, 55, 1},
            {60, 60, 1},
    }, right {
            {80, 30, 1},
            {100, 35, 1},
            {90, 10, 1},
            {100, 10, 1},
            {90, 10, 1},
            {100, 35, 1},
            {80, 30, 1},
            {100, 40, 1},
            {90, 20, 1},
            {100, 20, 1},
            {90, 20, 1},
            {100, 40, 1},
            {80, 30, 1},
            {60, 60, 1},
            {50, 82, 1},
            {60, 100, 1},
            {50, 82, 1},
            {60, 60, 1},
            {75, 80, 1},
            {70, 100, 1},
            {75, 80, 1},
            {60, 60, 1},
            {78, 55, 1},
            {60, 60, 1},
    };

public:
    Dz5() : QWidget() {
        setWindowTitle("Д/З №5");
        resize(900, 700);
        QTimer *timer = new QTimer(this);
        connect(timer, SIGNAL(timeout()), SLOT(repaint()));
        timer->start(20);
    }

private:
    QPoint* getPoints(Matrix m) {
        int n = m.n();
        QPoint *result = new QPoint[n];
        for(int i = 0; i < n; ++i) {
            result[i] = QPoint(m[i][0], m[i][1]);
        }
        return result;
    }

protected:
    void paintEvent(QPaintEvent *event) override {
        int n = left.n();
        QPoint* l = getPoints(left);
        QPoint* r = getPoints(right);
        //QPoint* m = getPoints(left);

        QPainter painter;
        painter.begin(this);
        painter.setPen(Qt::green);
        painter.drawPolygon(l, n);
        painter.setPen(Qt::blue);
        painter.drawPolygon(r, n);
        //painter.setPen(Qt::red);
        //painter.drawPolygon(m, n);
        painter.end();

        delete[] l;
        delete[] r;
        //delete[] m;
    }

};
