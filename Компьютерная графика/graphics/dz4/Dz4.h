#pragma once

#include <QColor>
#include <QWidget>
#include <QPainter>

#include <iostream>

#include <Matrix.h>

class Dz4 : public QWidget {
private:
    Matrix_ptr _house;

public:
    Dz4() : QWidget() {
        setWindowTitle("Д/З №4");
        resize(900, 700);
        _house = Matrix_ptr(new Matrix{
                {0, 0, 0, 1},
                {2, 0, 0, 1},
                {2, 2, 0, 1},
                {1, 3, 0, 1},
                {0, 2, 0, 1},
                {0, 0, 2, 1},
                {2, 0, 2, 1},
                {2, 2, 2, 1},
                {1, 3, 2, 1},
                {0, 2, 2, 1},
                {1, 0, 4, 2},
                {1, 2, 4, 2},
                {3, 2, 4, 2},
                {3, 0, 4, 2},
                {4, 1, 3, 2},
                {4, 2, 3, 2},
                {4, 2, 1, 2},
                {4, 1, 1, 2},
        });
    }

private:
    QPoint* getPoints(Matrix_ptr matrix) {
        Matrix m = matrix->normalize();
        int _n = matrix->n();
        QPoint *result = new QPoint[_n];
        for(int i = 0; i < _n; ++i) {
            result[i] = QPoint(m[i][0], m[i][1]);
        }
        return result;
    }

protected:
    void paintEvent(QPaintEvent *event) override {
        Matrix_ptr t = Matrix3D::transfer(50, 50, 50);

        std::cout << _house->n() << " " << _house->m() << " " << t->n() << " " << t->m() << "\n";

        Matrix_ptr house = Matrix::multiply(_house, t)->to2D(0.13, 0.6, 30);
        int size = _house->n();
        QPoint *points = getPoints(house);

        QPainter painter;
        painter.begin(this);
        painter.drawPolygon(points, size);
        painter.end();
        delete[] points;
    }
};
