#include <QMenu>
#include <QLabel>
#include <QPainter>
#include <QStatusBar>
#include <QPaintEvent>

#include "figures/Line.h"
#include "Mode.h"
#include "Canvas.h"

Canvas::Canvas() : QMainWindow() {
    lblStatus = new QLabel;
    resize(1000, 500);
    setWindowTitle("Компьютерная графика | РИС-19-1б | Миннахметов Эльдар");
    setMouseTracking(true);
    startTimer(20);
    mode = new StateMode(this);
    statusBar()->addWidget(lblStatus);
}

void Canvas::setStatus(QString text) {
    lblStatus->setText(text);
}

void Canvas::timerEvent(QTimerEvent *event) {
    repaint();
}
