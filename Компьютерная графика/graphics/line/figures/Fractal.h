#pragma once

#include "Line.h"

#include <vector>
#include <QPoint>
#include <QPainter>

class Fractal {
private:
    static const double fromMultiplier;
    static const double toMultiplier;
    static const double fromAngle;
    static const double toAngle;
    static const int fromLevel;
    static const int toLevel;
    static const int fromCount;
    static const int toCount;

    double angle;
    double multiplier;
    std::vector<Fractal> merges;

public:
    static Fractal generate();
    Fractal(int i);

    void draw(QPainter *painter, QPoint begin, QPoint end, int height);
};

class FractalLine : public Line {
private:
    Fractal fractal;

public:
    FractalLine(QPoint p1, QPoint p2);

    void draw(QPainter *painter, bool active, bool focused) override;
    bool isLine() override { return false; }

};
