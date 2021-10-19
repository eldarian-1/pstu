#pragma once

#include <QWidget>
#include <QColor>
#include <QPainter>

#include <vector>
using namespace std;

struct Point {
    double x, y;
};

double get(vector<double> v, int p) {
    if(p >= 0 && p < v.size()) {
        return v[p];
    } else if(p < 0) {
        return v[v.size() + p];
    } else {
        return v[p - v.size()];
    }
}

double a0(vector<double> v, int i) {
    return (get(v, i - 1) + 4 * get(v, i) + get(v, i + 1)) / 6;
}

double a1(vector<double> v, int i) {
    return (-get(v, i - 1) + get(v, i + 1)) / 2;
}

double a2(vector<double> v, int i) {
    return (get(v, i - 1) - 2 * get(v, i) + get(v, i + 1)) / 2;
}

double a3(vector<double> v, int i) {
    return (-get(v, i - 1) + 3 * get(v, i) - 3 * get(v, i + 1) + get(v, i + 2)) / 6;
}

double f(vector<double> v, int i, double t) {
    return ((a3(v, i) * t + a2(v, i)) * t + a1(v, i)) * t + a0(v, i);
}

Point calc(vector<double> xs, vector<double> ys, int i, double t) {
    double x = f(xs, i, t);
    double y = f(ys, i, t);
    return {x, y};
}

class Dz6 : public QWidget {
private:
    vector<double> xs = {2, 5, 7, 9, 11, 13, 16, 13, 11, 9, 7, 5};
    vector<double> ys = {7, 9, 12, 9, 12, 9, 7, 5, 2, 5, 2, 5};
    int steps = 10;

public:
    Dz6() : QWidget() {}

protected:
    void paintEvent(QPaintEvent *event) override {
        for(int i = 0; i < xs.size(); ++i) xs[i] *= 30;
        for(int i = 0; i < ys.size(); ++i) ys[i] *= 30;

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