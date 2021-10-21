#pragma once

#include <QTimer>
#include <QColor>
#include <QLabel>
#include <QWidget>
#include <QSlider>
#include <QPainter>
#include <QVBoxLayout>

class Dz5 : public QWidget {

public:
    Dz5() : QWidget() {
        setWindowTitle("Д/З №5");
        resize(900, 700);
        QTimer *timer = new QTimer(this);
        connect(timer, SIGNAL(timeout()), SLOT(repaint()));
        timer->start(20);
    }

protected:
    void paintEvent(QPaintEvent *event) override {
        QPainter painter;
        painter.begin(this);
        painter.end();
    }

};
