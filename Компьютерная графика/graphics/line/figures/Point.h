#pragma once

#include <QColor>
#include <QPainter>

class Point {
private:
    QPoint point;
    unsigned weight;
    QColor color;

public:
    Point(int x = 0, int y = 0, unsigned weight = 1, QColor color = Qt::black)
        : point(x, y), weight(weight), color(color) {}

    void draw(QPainter *painter, bool active, bool focused);
    QPoint &qt() { return point; }

};
