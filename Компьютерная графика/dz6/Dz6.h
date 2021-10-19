#pragma once

#include <QColor>
#include <QWidget>
#include <QPainter>

#include "common.h"

class Dz6 : public QWidget {
private:
    vector<double> xs = {2, 5, 7, 9, 11, 13, 16, 13, 11, 9, 7, 5};
    vector<double> ys = {7, 9, 12, 9, 12, 9, 7, 5, 2, 5, 2, 5};
    int steps = 100;
    int multiplier = 50;

public:
    Dz6() : QWidget() {
        setWindowTitle("Д/З №6");
        resize(900, 700);
    }

protected:
    void paintEvent(QPaintEvent *event) override {
        for(int i = 0; i < xs.size(); ++i) xs[i] *= multiplier;
        for(int i = 0; i < ys.size(); ++i) ys[i] *= multiplier;

        QPainter painter;
        painter.begin(this);

        painter.setPen(Qt::blue);
        QPoint *points = new QPoint[xs.size()];
        for(int i = 0, n = xs.size(); i < n; ++i) {
            points[i] = QPoint(xs[i], ys[i]);
        }
        painter.drawPolygon(points, xs.size());
        delete[] points;

        painter.setPen(Qt::red);
        points = new QPoint[xs.size() * (steps + 1)];
        for(int i = 0, n = xs.size(); i < n; ++i) {
            for(int t = 0; t <= steps; ++t) {
                Point p = calc(xs, ys, i, (double)t / steps);
                points[i * (steps + 1) + t] = QPoint(p.x, p.y);
            }
        }
        painter.drawPolygon(points, xs.size() * (steps + 1));
        delete[] points;

        painter.end();
    }
};