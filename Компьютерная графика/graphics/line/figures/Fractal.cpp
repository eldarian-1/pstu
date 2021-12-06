#include "Fractal.h"

#include <Func.h>
#include <Graphic.h>

const double Fractal::fromMultiplier = 0.5;
const double Fractal::toMultiplier = 0.75;
const double Fractal::fromAngle = -60;
const double Fractal::toAngle = 60;
const int Fractal::fromLevel = 7;
const int Fractal::toLevel = 10;
const int Fractal::fromCount = 2;
const int Fractal::toCount = 5;

Fractal Fractal::generate() {
    srand(time(0));
    int n = Func::rand(fromLevel, toLevel + 1);
    return Fractal(n);
}

Fractal::Fractal(int i) {
    angle = Func::rand(fromAngle, toAngle);
    multiplier = Func::rand(fromMultiplier, toMultiplier);
    merges = std::vector<Fractal>();
    if (i) {
        int n = Func::rand(fromCount, toCount);
        for (int j = 0; j < n; ++j) {
            merges.push_back(Fractal(i - 1));
        }
    }
}

void Fractal::draw(QPainter *painter, QPoint begin, QPoint end, int height) {
    if(abs(end.x()) > 2000 || abs(end.y()) > 2000) {
        return;
    }
    painter->drawLine(begin.x(), height - begin.y(), end.x(), height - end.y());
    for(Fractal& fractal : merges) {
        QPoint target = Graphic::continuation(begin, end, fractal.multiplier);
        fractal.draw(painter, end, Graphic::rotate(end, target, fractal.angle), height);
    }
}

FractalLine::FractalLine(QPoint p1, QPoint p2)
    : Line(p1, p2), fractal(Fractal::generate()) {}

void FractalLine::draw(QPainter *painter, bool active, bool focused) {
    int height = painter->window().height();
    QPoint from(top().x(), height - top().y());
    QPoint to(bottom().x(), height - bottom().y());
    painter->setPen(focused ? Qt::red : active ? Qt::green : Qt::black);
    fractal.draw(painter, from, to, height);
}
