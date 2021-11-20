#pragma once

#include <QPen>
#include <QTimer>
#include <QPoint>
#include <QColor>
#include <QLabel>
#include <QWidget>
#include <QSlider>
#include <QPainter>
#include <QVBoxLayout>

#include <Matrix.h>

struct point_t {
    QPoint point;
    int weight;
    QColor color;
};

class Point : public QWidget {
private:
    point_t left{{50, 50}, 13, Qt::blue}, right{{850, 450}, 29, Qt::red};
    QHBoxLayout *lyt;
    QLabel *lblFrom, *lblTo;
    QSlider *sld;

    point_t morfing(double t) {
        return point_t {
            {
                    int(left.point.x() * (1 - t) + right.point.x() * t),
                    int(left.point.y() * (1 - t) + right.point.y() * t),
                },
            int(left.weight * (1 - t) + right.weight * t),
            {
                    int(left.color.red() * (1 - t) + right.color.red() * t),
                    int(left.color.green() * (1 - t) + right.color.green() * t),
                    int(left.color.blue() * (1 - t) + right.color.blue() * t)
            }};
    }

    void drawPoint(QPainter *painter, point_t p) {
        painter->setBrush(p.color);
        painter->drawEllipse(p.point, p.weight, p.weight);
    }

public:
    Point() : QWidget() {
        setWindowTitle("Д/З №5");
        setFixedSize(900, 500);

        lyt = new QHBoxLayout;
        lblFrom = new QLabel("t: 0.0");
        lblTo = new QLabel(" 1.0");
        sld = new QSlider(Qt::Horizontal);

        lyt->setAlignment(Qt::AlignTop);
        sld->setRange(0, 1000);
        setLayout(lyt);
        lyt->addWidget(lblFrom);
        lyt->addWidget(sld);
        lyt->addWidget(lblTo);

        QTimer *timer = new QTimer(this);
        connect(timer, SIGNAL(timeout()), SLOT(repaint()));
        timer->start(20);
    }

protected:
    void paintEvent(QPaintEvent *event) override {
        double t = sld->value() / 1000.0;

        QPainter painter;
        painter.begin(this);
        painter.drawText(180, 13, QString::asprintf("%.3f", t));
        drawPoint(&painter, left);
        drawPoint(&painter, right);
        drawPoint(&painter, morfing(t));
        painter.end();
    }

};
