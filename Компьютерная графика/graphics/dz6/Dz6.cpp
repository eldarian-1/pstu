#include "Dz6.h"

#include <Splines.h>
#include <Graphic.h>

Dz6::Dz6() : QWidget() {
    setWindowTitle("Д/З №6");
    resize(900, 700);
}

void Dz6::paintEvent(QPaintEvent *event) {
    QPainter painter;
    painter.begin(this);

    painter.setPen(Qt::blue);
    int n;
    QPoint *points = Graphic::getPoints(matrix, n);
    painter.drawPolygon(points, n);
    delete[] points;

    painter.setPen(Qt::red);
    Matrix temp = Splines::get(matrix, steps);
    points = Graphic::getPoints(temp, n);
    painter.drawPolygon(points, n);
    delete[] points;

    painter.end();
}
