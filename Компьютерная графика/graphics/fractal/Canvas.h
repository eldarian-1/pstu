#pragma once

#include <QPoint>
#include <QLine>
#include <QWidget>

class QPainter;
class QPaintEvent;

class Canvas : public QWidget {
Q_OBJECT

private:


public:
    Canvas();

protected:
    void paintEvent(QPaintEvent* event) override;
    void paint(QPainter* painter, QPoint begin, QPoint end, int i, int n);
    static QPoint rotate(QPoint begin, QPoint end, double angle);

};
