#pragma once

#include <QPoint>
#include <QColor>
#include <QLineF>
#include <QTextStream>

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
    int getAngle();
    void setWeight(int weight) { this->weight = weight; }
    void setAngle(int angle);
    Line forAngle(int angle);
    int A() { return a; }
    int B() { return b; }
    int C() { return c; }
    void A(double a) { this->a = a; }
    void B(double b) { this->b = b; }
    void C(double c) { this->c = c; }

    QPoint &top();
    QPoint &bottom();
    void top(QPoint p);
    void bottom(QPoint p);
    QPoint middle();
    void getPoints(QPoint &a, QPoint &b, QPoint &c);
    double distanceFrom(const QPoint &p) const;

    virtual void draw(QPainter *pointer, bool active = false, bool focused = false);
    QString toString();

    virtual bool isLine() { return true; }

    friend QTextStream& operator >> (QTextStream& in, Line*& line);
    friend QTextStream& operator << (QTextStream& out, Line*& line);

};
