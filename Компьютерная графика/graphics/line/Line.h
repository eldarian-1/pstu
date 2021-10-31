#pragma once

#include <QPoint>
#include <QColor>
#include <QLineF>

class QPainter;

class Line {
private:
    double a, b, c;
    QColor color;
    int weight;

    double f(double x) const;
    QLineF getLine(const QPainter *painter, int width, int height);

public:
    Line(QPoint p1, QPoint p2);
    QColor getColor() { return color; }
    void setColor(QColor color) { this->color = color; }
    int getWeight() { return weight; }
    void setWeight(int weight) { this->weight = weight; }
    int A() { return a; }
    int B() { return b; }
    int C() { return c; }
    void A(double a) { this->a = a; }
    void B(double b) { this->b = b; }
    void C(double c) { this->c = c; }

    double distanceFrom(const QPoint &p) const;

    void draw(QPainter *pointer, int width, int height, bool active = false, bool focused = false);
    QString toString();

};
