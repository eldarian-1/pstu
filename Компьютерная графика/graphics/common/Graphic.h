#pragma once

#include "Matrix.h"

class QLine;
class QPoint;

namespace Graphic {
    QPoint* getPoints(Matrix matrix);
    QPoint* getPoints(Matrix matrix, int &size);

    double distance(QPoint a, QPoint b);
    double angle(QPoint a, QPoint b);
    QPoint rotate(QPoint point, double angle);
    QPoint continuation(QPoint begin, QPoint end, double multiplier);
    double degreesToRadians(double degrees);
    double radiansToDegrees(double radians);
    double distance(std::vector<double> vector, QPoint point);

    bool isPoint(QPoint cursor, QPoint target, int allow);
    bool isPoint(std::vector<double> cursor, QPoint target, int allow);
    QPoint pointOf(std::vector<double> vector);

    void out(QLine line);
    void out(QPoint point);

}
