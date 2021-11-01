#include "Line.h"

#include <QPainter>
#include <QLine>

#include <cmath>
using namespace std;

double Line::f(double x) const {
    return (b == 0. ? -c / a : -(a * x + c) / b);
}

Line::Line(QPoint p1, QPoint p2) : color(Qt::black), weight(1) {
    rebuild(p1, p2);
}

void Line::rebuild(QPoint p1, QPoint p2) {
    a = p1.y() - p2.y();
    b = p2.x() - p1.x();
    c = p1.x() * p2.y() - p2.x() * p1.y();
}

void Line::moveCenter(QPoint old, QPoint now) {
    int dx = old.x() - now.x();
    int dy = old.y() - now.y();
    QLineF l = getLine(1000, 1000);
    rebuild(QPoint(l.x1() - dx, l.y1() - dy), QPoint(l.x2() - dx, l.y2() - dy));
}

double Line::distanceFrom(const QPoint &p) const {
    return fabs(a * p.x() + b * p.y() + c) / sqrt(pow(a, 2) + pow(b, 2));
}

QLineF Line::getLine(int width, int height) {
    QPointF p1, p2;
    if(b == 0) {
        p1 = QPointF(-c/a, 0);
        p2 = QPointF(-c/a, height);
    } else if(a == 0) {
        p1 = QPointF(0, -c/b);
        p2 = QPointF(width, -c/b);
    } else {
        p1 = QPointF(0, f(0));
        p2 = QPointF(width, f(width));
    }
    return QLineF(p1, p2);
}

void Line::getPoints(QPoint &top, QPoint &middle, QPoint &bottom, int width, int height) {
    if(b == 0) {
        top = QPoint(-c/a, 0.25 * height);
        middle = QPoint(-c/a, 0.5 * height);
        bottom = QPoint(-c/a, 0.75 * height);
    } else if(a == 0) {
        top = QPoint(0.25 * width, -c/b);
        middle = QPoint(0.5 * width, -c/b);
        bottom = QPoint(0.75 * width, -c/b);
    } else {
        top = QPoint(0.25 * width, f(0.25 * width));
        middle = QPoint(0.5 * width, f(0.5 * width));
        bottom = QPoint(0.75 * width, f(0.75 * width));
    }
}

void Line::draw(QPainter *painter, int width, int height, bool active, bool focused) {
    QPen pen;
    pen.setWidth(weight);
    pen.setColor(focused ? Qt::red : active ? Qt::green : color);
    painter->setPen(pen);
    painter->drawLine(getLine(width, height));
}

QString Line::toString() {
    return QString::asprintf("%dx + %dy + %d = 0", A(), B(), C());
}
