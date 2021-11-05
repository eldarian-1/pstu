#include "Canvas.h"

#include <QPainter>
#include <QPaintEvent>

#include <Const.h>
#include <Graphic.h>
#include <cmath>

Canvas::Canvas() : QWidget() {
    setWindowTitle("Фрактальное дерево");
    setFixedSize(1200, 700);
}

void Canvas::paintEvent(QPaintEvent* event) {
    QPainter painter;
    painter.begin(this);
    painter.setBrush(Qt::white);
    painter.drawRect(-1, -1, 1202, 702);
    QLine startLine(600, 700, 600, 500);
    painter.drawLine(startLine);
    paint(&painter, startLine, 0, 5);
    painter.end();
}

void Canvas::paint(QPainter* painter, QLine line, int start, int end) {
    if(start == end) {
        return;
    }
    QLine target = continuum(line);
    QLine a = rotate(target, -15), b = rotate(target, 15);
    Graphic::out(line);
    Graphic::out(target);
    Graphic::out(a);
    Graphic::out(b);
    painter->drawLine(a);
    painter->drawLine(b);
    paint(painter, a, start + 1, end);
    paint(painter, b, start + 1, end);
}

QLine Canvas::continuum(QLine line) {
    double c;
    if(line.x2() - line.x1()) {
        c = -(double) (line.y1() - line.y2()) / (line.x2() - line.x1());
    } else {
        c = -Const::PI / 2;
    }
    double l = Graphic::distance(line.p1(), line.p2()) * 0.5;
    return QLine(line.p2(), QPoint(line.x2() + std::cos(c) * l, line.y2() + std::sin(c) * l));
}

QLine Canvas::rotate(QLine line, double angle) {
    QPoint start = line.p1();
    QPoint end = line.p2();
    double c = -(double)(start.x() - end.x()) / (end.y() - start.y());
    double a = angle * Const::PI / 180;
    end.rx() -= start.x();
    end.ry() -= start.y();
    end = rotate(end, c + a);
    end.rx() += start.x();
    end.ry() += start.y();
    return QLine(start, end);
}

QPoint Canvas::rotate(QPoint point, double a) {
    int x = std::cos(a) * point.x() + std::sin(a) * point.y();
    int y = -std::sin(a) * point.x() + std::cos(a) * point.y();
    return QPoint(x, y);
}
