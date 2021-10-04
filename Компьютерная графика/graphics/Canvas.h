#pragma once

#include <QWidget>

#include "Mode.h"

class Line;

class Canvas : public QWidget {
private:
    QList<Line*> lines;
    Mode *mode;

public:
    Canvas();

    QList<Line*> &getLines() { return lines; }

protected:
    void paintEvent(QPaintEvent *event) override { mode->paintEvent(event); }
    void mousePressEvent(QMouseEvent *event) override { mode->mousePressEvent(event); }
    void mouseReleaseEvent(QMouseEvent *event) override { mode->mouseReleaseEvent(event); }
    void mouseMoveEvent(QMouseEvent *event) override { mode->mouseMoveEvent(event); }
    void contextMenuEvent(QContextMenuEvent *event) override { mode->contextMenuEvent(event); }
    void timerEvent(QTimerEvent *event) override;

};
