#include "Point.h"

void Point::draw(QPainter *painter, bool active, bool focused) {
    QPen pen(QBrush(active ? Qt::red : focused ? Qt::green : color), weight);
    painter->setPen(pen);
    painter->drawPoint(point);
}
