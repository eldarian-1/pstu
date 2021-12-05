#include "Graphic.h"

#include <QLine>
#include <QPoint>
#include <QPointF>
#include <cmath>
#include <iostream>

#include "Const.h"

QPoint* Graphic::getPoints(Matrix m) {
    int n;
    return getPoints(m, n);
}

QPoint* Graphic::getPoints(Matrix m, int &n) {
    n = m.n();
    QPoint *result = new QPoint[n];
    for(int i = 0; i < n; ++i) {
        result[i] = QPoint(m[i][0], m[i][1]);
    }
    return result;
}

double Graphic::distance(QPoint a, QPoint b) {
    return std::sqrt(std::pow(a.x() - b.x(), 2) + std::pow(a.y() - b.y(), 2));
}

double Graphic::angle(QPoint from, QPoint to) {
    if(to.x() - from.x()) {
        double r = std::atan((double)-(from.y() - to.y()) / (to.x() - from.x()));
        if(r <= 0) {
            return from.x() > to.x() ? Const::PI + r : r;
        } else {
            return from.x() < to.x() ? r - Const::PI : r;
        }
    } else {
        return from.y() == to.y() ? Const::PI / 4 : from.y() < to.y() ? -Const::PI / 2 : Const::PI / 2;
    }
}

QPoint Graphic::rotate(QPoint point, double a) {
    int x = std::cos(a) * point.x() - std::sin(a) * point.y();
    int y = std::sin(a) * point.x() + std::cos(a) * point.y();
    return QPoint(x, y);
}

QPointF Graphic::rotate(QPointF point, double a) {
    double x = std::cos(a) * point.x() - std::sin(a) * point.y();
    double y = std::sin(a) * point.x() + std::cos(a) * point.y();
    return QPointF(x, y);
}

QPoint Graphic::rotate(QPoint begin, QPoint end, double angl) {
    double a = degreesToRadians(angl);
    double c = angle(begin, end);
    double l = distance(begin, end);
    QPoint target = rotate(QPoint(l, 0), c + a);
    target.rx() += begin.x();
    target.ry() += begin.y();
    return target;
}

QPoint Graphic::continuation(QPoint begin, QPoint end, double multiplier) {
    double c = Graphic::angle(begin, end);
    double l = Graphic::distance(begin, end) * multiplier;
    return QPoint(end.x() + std::cos(c) * l, end.y() + std::sin(c) * l);
}

double Graphic::degreesToRadians(double degrees) {
    return degrees * Const::PI / 180;
}

double Graphic::radiansToDegrees(double radians) {
    return radians * 180 / Const::PI;
}

double Graphic::distance(std::vector<double> vector, QPoint point) {
    return distance(pointOf(vector), point);
}

bool Graphic::isPoint(QPoint cursor, QPoint target, int allow) {
    return distance(cursor, target) <= allow;
}

bool Graphic::isPoint(std::vector<double> cursor, QPoint target, int allow) {
    return isPoint(pointOf(cursor), target, allow);
}

QPoint Graphic::pointOf(std::vector<double> vector) {
    return QPoint(vector[0], vector[1]);
}

void Graphic::out(QLine line) {
    std::cout << line.x1() << " " << line.y1() << " " << line.x2() << " " << line.y2() << "\n";
}

void Graphic::out(QPoint point) {
    std::cout << point.x() << " " << point.y() << "\n";
}
