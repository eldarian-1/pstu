#include "Line.h"

#include <QPainter>
#include <QLine>

#include <cmath>
using namespace std;

Line* Line::active = nullptr;
bool Line::rightButtonPressed = false;

Line::Line(QPoint p1, QPoint p2) : p1(p1), p2(p2), color(Qt::black), width(1) {}

int f(int a, int b, int c, int x) {
    return -(a * x + c) / b;
}

bool between(const int &a0, const int &a1, const int &a) {
    return min(a0, a1) <= a && a <= max(a0, a1);
}

void equation(const int &a1, const int &a2, const int &b1, const int &b2, int &a, int &b, int &c) {
    a = b1 - b2;
    b = a2 - a1;
    c = a1 * b2 - a2 * b1;
}

void points(QPoint &p1, QPoint &p2, QPoint &p, int &a1, int &a2, int &b1, int &b2, int &x, int &y) {
    a1 = p1.rx();
    a2 = p2.rx();
    b1 = p1.ry();
    b2 = p2.ry();
    x = p.rx();
    y = p.ry();
}

double length(const int &a, const int &b) {
    return sqrt(pow(a, 2) + pow(b, 2));
}

double distance(const int &a, const int &b, const int &c, const int &x, const int &y) {
    return fabs(a * x + b * y + c) / length(a, b);
}

double Line::distanceFrom(QPoint p) {
    double d;
    int a1, a2, b1, b2, a, b, c, x, y;
    points(p1, p2, p, a1, a2, b1, b2, x, y);
    equation(a1, a2, b1, b2, a, b, c);
    d = distance(a, b, c, x, y);
    if(b == 0) {
        d += (between(a1, a2, -c / a) ? 0 : 100);
    } else {
        d += (between(f(a, b, c, a1), f(a, b, c, a2), f(a, b, c, x)) ? 0 : 100);
    }
    return d;
}

void Line::draw(QPainter *painter) {
    QPen pen;
    pen.setWidth(width);
    if(this == active) {
        pen.setColor(rightButtonPressed ? Qt::green : Qt::red);
    } else {
        pen.setColor(color);
    }
    QLine line(p1, p2);
    painter->setPen(pen);
    painter->drawLine(line);
}

void Line::activize() {
    active = this;
}