#include "Graphic.h"

#include <QPoint>

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
