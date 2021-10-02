#include "Line.h"

#include <QPainter>
#include <QLine>

Line* Line::active = nullptr;
bool Line::rightButtonPressed = false;

Line::Line(QPoint p1, QPoint p2) : p1(p1), p2(p2), color(Qt::black), width(1) {}

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