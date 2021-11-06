#include "Canvas.h"

#include <QPainter>
#include <QPaintEvent>

#include <Graphic.h>

Canvas::Canvas() : QWidget() {
    setWindowTitle("Фрактальное дерево");
    setFixedSize(1200, 700);
}

void Canvas::paintEvent(QPaintEvent* event) {
    QPainter painter;
    painter.begin(this);
    painter.setBrush(Qt::white);
    painter.drawRect(-1, -1, 1202, 702);
    paint(&painter, QPoint(600, 0), QPoint(600, 350), 0, 10);
    painter.end();
}

void Canvas::paint(QPainter* painter, QPoint begin, QPoint end, int i, int n) {
    if(i == n) {
        return;
    }
    painter->drawLine(begin.x(), 700 - begin.y(), end.x(), 700 - end.y());
    QPoint target = Graphic::continuation(begin, end, 0.5);
    QPoint a = rotate(end, target, -113);
    QPoint b = rotate(end, target, -38);
    QPoint c = rotate(end, target, 37);
    QPoint d = rotate(end, target, 112);
    paint(painter, end, a, i + 1, n);
    paint(painter, end, b, i + 1, n);
    paint(painter, end, c, i + 1, n);
    paint(painter, end, d, i + 1, n);
}

QPoint Canvas::rotate(QPoint begin, QPoint end, double angle) {
    double a = Graphic::degreesToRadians(angle);
    double c = Graphic::angle(begin, end);
    double l = Graphic::distance(begin, end);
    QPoint target = Graphic::rotate(QPoint(l, 0), c + a);
    target.rx() += begin.x();
    target.ry() += begin.y();
    return target;
}
