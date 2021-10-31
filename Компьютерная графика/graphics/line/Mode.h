#pragma once

#include <QObject>

class Line;
class Canvas;
class MoveMode;
class CreateMode;
class QPainter;
class QPaintEvent;
class QMouseEvent;
class QContextMenuEvent;

class Mode {
protected:
    static Canvas *canvas;
    static CreateMode *createInstance;
    static MoveMode *moveInstance;

public:
    virtual void paintEvent(QPaintEvent *event) = 0;
    virtual void mousePressEvent(QMouseEvent *event) = 0;
    virtual void mouseReleaseEvent(QMouseEvent *event) = 0;
    virtual void mouseMoveEvent(QMouseEvent *event) = 0;
    virtual void contextMenuEvent(QContextMenuEvent *event) = 0;

    static Mode* create();
    static Mode* move(Line* line);

    static bool focusLine(Line *line, QPoint point, double &d);

};

class ModeImpl : public Mode {
protected:
    virtual void paint(QPainter *painter) {}

public:
    void paintEvent(QPaintEvent *event) override;

};

class StateMode : public Mode {
private:
    Mode* state;

public:
    StateMode(Canvas *canvas);

    void setState(Mode* state);

    void paintEvent(QPaintEvent *event) override;
    void mousePressEvent(QMouseEvent *event) override;
    void mouseReleaseEvent(QMouseEvent *event) override;
    void mouseMoveEvent(QMouseEvent *event) override;
    void contextMenuEvent(QContextMenuEvent *event) override;

};
