#pragma once

#include <QColor>
#include <QWidget>
#include <QPainter>

#include <Matrix.h>

class Dz6 : public QWidget {
private:
    typedef std::pair<int, QPoint> pair_t;

    static const int steps = 100;
    const char *add = "Добавить точку";
    const char *del = "Удалить точку";

    pair_t* focusedPoint = nullptr;
    pair_t* activePoint = nullptr;

    Matrix matrix {
            {100, 350},
            {250, 450},
            {350, 600},
            {450, 450},
            {550, 600},
            {650, 450},
            {800, 350},
            {650, 250},
            {550, 100},
            {450, 250},
            {350, 100},
            {250, 250},
    };

public:
    Dz6();

protected:
    bool isPoint(QPoint point, int &i);
    int minDistance(QPoint point);

    void paintEvent(QPaintEvent *event) override;
    void mousePressEvent(QMouseEvent *event) override;
    void mouseReleaseEvent(QMouseEvent *event) override;
    void mouseMoveEvent(QMouseEvent *event) override;
    void contextMenuEvent(QContextMenuEvent *event) override;
    void timerEvent(QTimerEvent *event) override;

    static double distance(std::vector<double> vector, QPoint point);
    static void remove(pair_t*& p);

};
