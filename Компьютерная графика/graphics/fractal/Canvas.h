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

    void paint(QPainter* painter, QLine line, int start, int end);

    static QLine continuum(QLine line);
    static QLine rotate(QLine line, double angle);
    static QPoint rotate(QPoint point, double angle);

};
