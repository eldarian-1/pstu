#pragma once

#include <QPoint>
#include <QColor>

class QPainter;

class Line {
private:
    QPoint p1, p2;
    QColor color;
    int width;

public:
    static Line *active;
    static bool rightButtonPressed;

    Line(QPoint p1, QPoint p2);
    QColor getColor() { return color; }
    void setColor(QColor color) { this->color = color; }
    int getWidth() { return width; }
    void setWidth(int width) { this->width = width; }

    double distanceFrom(QPoint p);

    void draw(QPainter *pointer);
    void activize();

};
