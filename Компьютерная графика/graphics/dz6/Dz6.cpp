#include "Dz6.h"

#include <QMenu>
#include <QMouseEvent>
#include <QMessageBox>
#include <QContextMenuEvent>

#include <Splines.h>
#include <Graphic.h>

#include <cmath>

Dz6::Dz6() : QWidget() {
    setWindowTitle("Д/З №6");
    resize(900, 700);
    startTimer(20);
    setMouseTracking(true);
}

void Dz6::paintEvent(QPaintEvent *event) {
    QPainter painter;
    painter.begin(this);

    painter.setPen(Qt::blue);
    int n;
    QPoint *points = Graphic::getPoints(matrix, n);
    painter.drawPolygon(points, n);
    delete[] points;

    painter.setPen(Qt::red);
    Matrix temp = Splines::get(matrix, steps);
    points = Graphic::getPoints(temp, n);
    painter.drawPolygon(points, n);
    delete[] points;

    if(focusedPoint) {
        QPen pen(QBrush(Qt::darkGreen), 5);
        painter.setPen(pen);
        painter.drawPoint(focusedPoint->second);
    }

    painter.end();
}

bool Dz6::isPoint(QPoint point, int &i) {
    int n = matrix.n();
    for(i = 0; i < n; ++i) {
        if(distance(matrix[i], point) <= 5) {
            return true;
        }
    }
    return false;
}

int Dz6::minDistance(QPoint point) {
    int index = 0, min = 1000000000;
    for(int i = 0, n = matrix.n(); i < n; ++i) {
        int d = distance(matrix[i - 1], point) + distance(matrix[i], point);
        if(d < min) {
            min = d;
            index = i;
        }
    }
    return index;
}

void Dz6::mousePressEvent(QMouseEvent *event) {
    int i;
    if(focusedPoint) {
        activePoint = new pair_t(*focusedPoint);
    }
}

void Dz6::mouseReleaseEvent(QMouseEvent *event) {
    if(activePoint) {
        remove(activePoint);
    }
}

void Dz6::mouseMoveEvent(QMouseEvent *event) {
    int i;
    if(focusedPoint) {
        remove(focusedPoint);
    }
    if(isPoint(event->pos(), i)) {
        focusedPoint = new pair_t { i, QPoint(matrix[i][0], matrix[i][1]) };
    }
    if(activePoint) {
        matrix[activePoint->first][0] = event->x();
        matrix[activePoint->first][1] = event->y();
    }
}

void Dz6::contextMenuEvent(QContextMenuEvent *event) {
    QMenu menu;
    if(focusedPoint) {
        menu.addAction(del);
    } else {
        menu.addAction(add);
    }
    QString res = menu.exec(event->globalPos())->text();
    if(res == add) {
        QPoint p = event->pos();
        int i = minDistance(p);
        matrix.insert(i, {(double)p.x(), (double)p.y()});
    } else if(res == del) {
        if(matrix.n() <= 4) {
            QMessageBox::warning(this, "Предупреждение", "Точек не может быть менее 4!");
        } else {
            matrix.erase(focusedPoint->first);
        }
        remove(focusedPoint);
        remove(activePoint);
    }
}

void Dz6::timerEvent(QTimerEvent *event) {
    repaint();
}

double Dz6::distance(std::vector<double> vector, QPoint point) {
    return std::sqrt(std::pow(vector[0] - point.x(), 2) + std::pow(vector[1] - point.y(), 2));
}

void Dz6::remove(pair_t*& p) {
    delete p;
    p = nullptr;
}
