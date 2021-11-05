#pragma once

#include "Matrix.h"

class QLine;
class QPoint;

namespace Graphic {
    QPoint* getPoints(Matrix matrix);
    QPoint* getPoints(Matrix matrix, int &size);
    double distance(QPoint a, QPoint b);
    double distance(std::vector<double> vector, QPoint point);
    bool isPoint(QPoint cursor, QPoint target, int allow);
    bool isPoint(std::vector<double> cursor, QPoint target, int allow);
    QPoint pointOf(std::vector<double> vector);

    void out(QLine line);
    void out(QPoint point);

}
