#include "Graphic.h"

#include <QPoint>
#include <cmath>

QPoint* Graphic::getPoints(Matrix m) {
    int n;
    return getPoints(m, n);
}

QPoint* Graphic::getPoints(Matrix m, int &n) {
    n = m.n();
    QPoint *result = new QPoint[n];
    for(int i = 0; i < n; ++i) {
        result[i] = QPoint(m[i][0], m[i][1]);
    }
    return result;
}

double Graphic::distance(QPoint a, QPoint b) {
    return std::sqrt(std::pow(a.x() - b.x(), 2) + std::pow(a.y() - b.y(), 2));
}

double Graphic::distance(std::vector<double> vector, QPoint point) {
    return distance(pointOf(vector), point);
}

bool Graphic::isPoint(QPoint cursor, QPoint target, int allow) {
    return distance(cursor, target) <= allow;
}

bool Graphic::isPoint(std::vector<double> cursor, QPoint target, int allow) {
    return isPoint(pointOf(cursor), target, allow);
}

QPoint Graphic::pointOf(std::vector<double> vector) {
    return QPoint(vector[0], vector[1]);
}
