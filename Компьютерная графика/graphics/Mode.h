#pragma once

class QPaintEvent;
class QMouseEvent;
class QContextMenuEvent;

class Mode {
private:


public:
    virtual void paintEvent(QPaintEvent *event) = 0;
    virtual void mousePressEvent(QMouseEvent *event) = 0;
    virtual void mouseReleaseEvent(QMouseEvent *event) = 0;
    virtual void mouseMoveEvent(QMouseEvent *event) = 0;
    virtual void contextMenuEvent(QContextMenuEvent *event) = 0;
};
