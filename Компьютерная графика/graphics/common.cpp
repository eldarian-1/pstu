#include "common.h"

#include <QPoint>

#include <cmath>
using namespace std;

#include "Line.h"

double distance(Line l, QPoint p) {
    int a1 = l.x1(), a2 = l.x2(), b1 = l.y1(), b2 = l.y2();
    int A = b1 - b2, B = a2 - a1, C = a1 * b2 - a2 * b1;
    int x = p.rx(), y = p.ry();
    double len = sqrt(pow(A, 2) + pow(B, 2));
    double r = fabs(A * x + B * y + C) / len;
    return r + (between(f(A, B, C, a1), f(A, B, C, a2), f(A, B, C, x)) ? 0 : 100);
}

double f(int A, int B, int C, int x) {
    return -(A * x + C) / (double)B;
}

bool between(double y0, double y1, double y) {
    return min(y0, y1) <= y && y <= max(y0, y1);
}