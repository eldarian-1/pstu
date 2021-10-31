#include "Line.h"

#include <QPainter>
#include <QLine>

#include <cmath>
using namespace std;

Line* Line::active = nullptr;
bool Line::rightButtonPressed = false;

double Line::f(double x) const {
    return (b == 0. ? -c / a : -(a * x + c) / b);
}

Line::Line(QPoint p1, QPoint p2) : color(Qt::black), weight(1) {
    a = p1.y() - p2.y();
    b = p2.x() - p1.x();
    c = p1.x() * p2.y() - p2.x() * p1.y();
}

double Line::distanceFrom(const QPoint &p) const {
    return fabs(a * p.x() + b * p.y() + c) / sqrt(pow(a, 2) + pow(b, 2));
}

QLineF Line::getLine(const QPainter *painter, int width, int height) {
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

void Line::draw(QPainter *painter, int width, int height) {
    QPen pen;
    pen.setWidth(weight);
    if(this == active) {
        pen.setColor(rightButtonPressed ? Qt::green : Qt::red);
    } else {
        pen.setColor(color);
    }
    painter->setPen(pen);
    painter->drawLine(getLine(painter, width, height));
}

void Line::activize() {
    active = this;
}

QString Line::toString() {
    return QString::asprintf("%fx + %fy + %f = 0", a, b, c);
}
