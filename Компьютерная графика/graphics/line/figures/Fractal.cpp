#include "Fractal.h"

#include <Graphic.h>

const double Fractal::fromMultiplier = 0.5;
const double Fractal::toMultiplier = 0.7;
const double Fractal::fromAngle = -45;
const double Fractal::toAngle = 45;
const int Fractal::fromLevel = 7;
const int Fractal::toLevel = 9;
const int Fractal::fromCount = 2;
const int Fractal::toCount = 4;

double Fractal::rand(double from, double to) {
    return from + (to - from) * ::rand() / RAND_MAX;
}

Fractal Fractal::generate() {
    srand(time(0));
    int n = rand(fromLevel, toLevel);
    return Fractal(n);
}

Fractal::Fractal(int i) {
    angle = rand(fromAngle, toAngle);
    multiplier = rand(fromMultiplier, toMultiplier);
    merges = std::vector<Fractal>();
    if (i) {
        int n = rand(fromCount, toCount);
        for (int j = 0; j < n; ++j) {
            merges.push_back(Fractal(i - 1));
        }
    }
}

void Fractal::draw(QPainter *painter, QPoint begin, QPoint end) {
    painter->drawLine(begin, end);
    for(Fractal& fractal : merges) {
        QPoint target = Graphic::continuation(begin, end, fractal.multiplier);
        fractal.draw(painter, end, Graphic::rotate(end, target, fractal.angle));
    }
}

FractalLine::FractalLine(QPoint p1, QPoint p2)
    : Line(p1, p2), fractal(Fractal::generate()) {}

void FractalLine::draw(QPainter *painter, bool active, bool focused) {
    painter->setPen(focused ? Qt::red : active ? Qt::green : Qt::black);
    fractal.draw(painter, top(), bottom());
}
