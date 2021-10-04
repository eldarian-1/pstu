#pragma once

#include <QObject>

class QMenu;
class Canvas;
class QPoint;
class QAction;
class QPainter;
class QPaintEvent;
class QMouseEvent;
class QContextMenuEvent;

class Mode {
public:
    virtual void paintEvent(QPaintEvent *event) = 0;
    virtual void mousePressEvent(QMouseEvent *event) = 0;
    virtual void mouseReleaseEvent(QMouseEvent *event) = 0;
    virtual void mouseMoveEvent(QMouseEvent *event) = 0;
    virtual void contextMenuEvent(QContextMenuEvent *event) = 0;

};

class ModeImpl : public Mode {
private:
    Canvas *canvas;

protected:
    ModeImpl(Canvas *canvas) : canvas(canvas) {}
    virtual void paint(QPainter *painter) {}
    Canvas *getCanvas() { return canvas; }

public:
    void paintEvent(QPaintEvent *event) override;

};

class StateMode : public Mode {
private:
    ModeImpl* state = nullptr;

public:
    StateMode(Canvas *canvas);

    void setState(ModeImpl* state);

    void paintEvent(QPaintEvent *event) override { state->paintEvent(event); }
    void mousePressEvent(QMouseEvent *event) override { state->mousePressEvent(event); }
    void mouseReleaseEvent(QMouseEvent *event) override { state->mouseReleaseEvent(event); }
    void mouseMoveEvent(QMouseEvent *event) override { state->mouseMoveEvent(event); }
    void contextMenuEvent(QContextMenuEvent *event) override { state->contextMenuEvent(event); }

};

class CreateMode : public QObject, public ModeImpl {
Q_OBJECT

private:
    QMenu *menu;
    QPoint *activePoint = nullptr;

protected:
    void paint(QPainter *painter) override;

public:
    CreateMode(Canvas *canvas);

    void mousePressEvent(QMouseEvent *event) override;
    void mouseReleaseEvent(QMouseEvent *event) override;
    void mouseMoveEvent(QMouseEvent *event) override;
    void contextMenuEvent(QContextMenuEvent *event) override;

public slots:
    void slotTriggered(QAction *action);

};

class MoveMode : public ModeImpl {
private:

public:
    MoveMode(Canvas *canvas);

    void mousePressEvent(QMouseEvent *event) override;
    void mouseReleaseEvent(QMouseEvent *event) override;
    void mouseMoveEvent(QMouseEvent *event) override;
    void contextMenuEvent(QContextMenuEvent *event) override;
};
