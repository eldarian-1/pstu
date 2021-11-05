#include "Canvas.h"

#include <QPainter>
#include <QPaintEvent>

#include <Graphic.h>

#include <iostream>

Canvas::Canvas() : QWidget() {
    setWindowTitle("Фрактальное дерево");
    setFixedSize(1200, 700);
}

void Canvas::paintEvent(QPaintEvent* event) {
    QPainter painter;
    painter.begin(this);
    painter.setBrush(Qt::white);
    painter.drawRect(-1, -1, 1202, 702);
    paint(&painter, QPoint(600, 0), QPoint(600, 200), 0, 3);
    painter.end();
}

void Canvas::paint(QPainter* painter, QPoint begin, QPoint end, int i, int n) {
    if(i == n) {
        return;
    }
    painter->drawLine(begin.x(), 700 - begin.y(), end.x(), 700 - end.y());
    QPoint target = Graphic::continuation(begin, end, 0.5);
    QPoint a = rotate(begin, target, -45);
    QPoint b = rotate(begin, target, 45);
    //QPoint c = rotate(begin, target, 45);
    paint(painter, end, a, i + 1, n);
    paint(painter, end, b, i + 1, n);
    //paint(painter, end, c, i + 1, n);
}

QPoint Canvas::rotate(QPoint begin, QPoint end, double angle) {
    double a = Graphic::degreesToRadians(angle);
    double c = Graphic::angle(begin, end);
    double l = Graphic::distance(begin, end);
    std::cout << Graphic::radiansToDegrees(c) << " " << Graphic::radiansToDegrees(c + a) << "\n";
    QPoint target = Graphic::rotate(QPoint(l, 0), c + a);
    target.rx() += end.x();
    target.ry() += end.y();
    return target;
}
