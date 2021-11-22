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

QTextStream& operator >> (QTextStream& in, Canvas& canvas) {
    for(auto item : canvas.lines) {
        delete item;
    }
    canvas.lines.clear();
    int n;
    in >> n;
    for(int i = 0; i < n; ++i) {
        Line *temp;
        in >> temp;
        canvas.lines.push_back(temp);
    }
    return in;
}

QTextStream& operator << (QTextStream& out, Canvas& canvas) {
    out << canvas.lines.count() << " ";
    for(auto item : canvas.lines) {
        out << item << " ";
    }
    return out;
}
