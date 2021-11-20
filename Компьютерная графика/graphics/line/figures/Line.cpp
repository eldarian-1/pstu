#include "Line.h"

#include <QPainter>
#include <QLine>

#include <cmath>
using namespace std;

#include <Func.h>

double Line::f(double x) const {
    return (b == 0. ? -c / a : -(a * x + c) / b);
}

double Line::g(double y) const {
    return (a == 0. ? -c / b : -(b * y + c) / a);
}

Line::Line(QPoint p1, QPoint p2) : p1(p1), p2(p2), color(Qt::black), weight(1) {
    rebuild(p1, p2);
}

void Line::rebuild(QPoint p1, QPoint p2) {
    this->p1 = p1;
    this->p2 = p2;
    a = p1.y() - p2.y();
    b = p2.x() - p1.x();
    c = p1.x() * p2.y() - p2.x() * p1.y();
    int d = Func::gcd((int)a, (int)b, (int)c);
    a /= d;
    b /= d;
    c /= d;
}



void Line::moveCenter(QPoint old, QPoint now) {
    int dx = old.x() - now.x();
    int dy = old.y() - now.y();
    rebuild(QPoint(p1.x() - dx, p1.y() - dy), QPoint(p2.x() - dx, p2.y() - dy));
}

double Line::distanceFrom(const QPoint &p) const {
    return fabs(a * p.x() + b * p.y() + c) / sqrt(pow(a, 2) + pow(b, 2));
}

QPoint &Line::top() {
    return p1;
}
QPoint &Line::bottom() {
    return p2;
}

void Line::top(QPoint p) {
    rebuild(p, bottom());
}

void Line::bottom(QPoint p) {
    rebuild(top(), p);
}

void Line::getPoints(QPoint &top, QPoint &middle, QPoint &bottom) {
    top = p1;
    bottom = p2;
    middle = {(p1.x() + p2.x()) / 2, (p1.y() + p2.y()) / 2};
}

void Line::draw(QPainter *painter, bool active, bool focused) {
    QPen pen;
    pen.setWidth(weight);
    pen.setColor(focused ? Qt::red : active ? Qt::green : color);
    painter->setPen(pen);
    painter->drawLine(p1, p2);
}

QString Line::toString() {
    int a = this->a, b = this->b, c = this->c;
    return QString::asprintf("%dx ", a) +
        (b >= 0 ? QString::asprintf("+ %dy ", b) : QString::asprintf("- %dy ", -b)) +
        (c >= 0 ? QString::asprintf("+ %d = 0", c) : QString::asprintf("- %d = 0", -c));
}
