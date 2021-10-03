#pragma once

#include <QPoint>
#include <QColor>
#include <QLineF>

class QPainter;

class Line {
private:
    double a, b, c;
    QColor color;
    int thickness;

    double f(double x) const;
    QLineF getLine(const QPainter *painter, int width, int height);

public:
    static Line *active;
    static bool rightButtonPressed;

    Line(QPoint p1, QPoint p2);
    QColor getColor() { return color; }
    void setColor(QColor color) { this->color = color; }
    int getThickness() { return thickness; }
    void setThickness(int thickness) { this->thickness = thickness; }

    double distanceFrom(const QPoint &p) const;

    void draw(QPainter *pointer, int width, int height);
    void activize();

};
