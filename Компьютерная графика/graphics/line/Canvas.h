#pragma once

#include <QMainWindow>
#include <QTextStream>

#include "Mode.h"

class Line;
class QLabel;

class Canvas : public QMainWindow {
private:
    QLabel *lblStatus;
    QList<Line*> lines;
    StateMode *mode;

public:
    Canvas();

    QList<Line*> &getLines() { return lines; }
    void setMode(Mode *mode) { this->mode->setState(mode); }
    void setStatus(QString text);

    friend QTextStream& operator >> (QTextStream& in, Canvas& canvas);
    friend QTextStream& operator << (QTextStream& out, Canvas& canvas);

protected:
    void paintEvent(QPaintEvent *event) override { mode->paintEvent(event); }
    void mousePressEvent(QMouseEvent *event) override { mode->mousePressEvent(event); }
    void mouseReleaseEvent(QMouseEvent *event) override { mode->mouseReleaseEvent(event); }
    void mouseMoveEvent(QMouseEvent *event) override { mode->mouseMoveEvent(event); }
    void contextMenuEvent(QContextMenuEvent *event) override { mode->contextMenuEvent(event); }
    void timerEvent(QTimerEvent *event) override;

};
