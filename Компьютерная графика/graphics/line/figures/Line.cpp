#include "Line.h"

#include <QLine>
#include <QPainter>

#include <cmath>
using namespace std;

#include <Func.h>
#include <Const.h>
#include <Graphic.h>

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

int Line::getAngle() {
    int a = (int)(Graphic::angle(p1, p2) * 180 / Const::PI);
    a = a < 0 ? 360 + a : a > 360 ? a - 360 : a;
    return a;
}

void Line::setAngle(int angle) {
    double a = Const::PI / 180 * angle - Graphic::angle(p1, p2);
    QPoint m = middle();
    p1.rx() -= m.x();
    p1.ry() -= m.y();
    p2.rx() -= m.x();
    p2.ry() -= m.y();
    p1 = Graphic::rotate(p1, a);
    p2 = Graphic::rotate(p2, a);
    p1.rx() += m.x();
    p1.ry() += m.y();
    p2.rx() += m.x();
    p2.ry() += m.y();
}

Line Line::forAngle(int angle) {
    Line temp(*this);
    temp.setAngle(angle);
    return temp;
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

QPoint Line::middle() {
    return {(p1.x() + p2.x()) / 2, (p1.y() + p2.y()) / 2};
}

void Line::getPoints(QPoint &top, QPoint &middle, QPoint &bottom) {
    top = p1;
    bottom = p2;
    middle = this->middle();
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

QTextStream& operator >> (QTextStream& in, Line*& line) {
    int x1, y1, x2, y2, weight, r, g, b;
    in >> x1 >> y1 >> x2 >> y2 >> weight >> r >> g >> b;
    line = new Line(QPoint(x1, y1), QPoint(x2, y2));
    line->setWeight(weight);
    line->setColor(QColor(r, g, b));
    return in;
}

QTextStream& operator << (QTextStream& out, Line*& line) {
    out << line->p1.x() << " " << line->p1.y() << " " << line->p2.x() << " " << line->p2.y() << " "
            << line->weight << " " << line->color.red() << " " << line->color.green() << " " << line->color.blue() << " ";
    return out;
}
