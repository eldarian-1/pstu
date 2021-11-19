#pragma once

#include <QPoint>
#include <QColor>
#include <QLineF>

class QPainter;

class Line {
private:
    QPoint p1, p2;
    double a, b, c;
    QColor color;
    int weight;

    double f(double x) const;
    double g(double y) const;

public:
    Line(QPoint p1, QPoint p2);
    void rebuild(QPoint p1, QPoint p2);
    void moveCenter(QPoint old, QPoint now);
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

    QPoint &top();
    QPoint &bottom();
    void getPoints(QPoint &a, QPoint &b, QPoint &c);
    double distanceFrom(const QPoint &p) const;

    void draw(QPainter *pointer, bool active = false, bool focused = false);
    QString toString();

};
