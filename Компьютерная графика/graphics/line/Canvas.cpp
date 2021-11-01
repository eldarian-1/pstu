#include <QWidget>
#include <QPainter>
#include <QPaintEvent>
#include <QMenu>

#include "figures/Line.h"
#include "Mode.h"
#include "Canvas.h"

Canvas::Canvas() : QWidget() {
    resize(1000, 500);
    setWindowTitle("Компьютерная графика | РИС-19-1б | Миннахметов Эльдар");
    setMouseTracking(true);
    startTimer(20);
    mode = new StateMode(this);
}

void Canvas::timerEvent(QTimerEvent *event) {
    repaint();
}