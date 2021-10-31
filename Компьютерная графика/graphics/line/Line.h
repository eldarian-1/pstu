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
    static Line *active;
    static bool rightButtonPressed;

    Line(QPoint p1, QPoint p2);
    QColor getColor() { return color; }
    void setColor(QColor color) { this->color = color; }
    int getWeight() { return weight; }
    void setWeight(int weight) { this->weight = weight; }
    double A() { return a; }
    double B() { return b; }
    double C() { return c; }
    void A(double a) { this->a = a; }
    void B(double b) { this->b = b; }
    void C(double c) { this->c = c; }

    double distanceFrom(const QPoint &p) const;

    void draw(QPainter *pointer, int width, int height);
    void activize();
    QString toString();

};
