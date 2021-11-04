#pragma once

#include "../Mode.h"

class QMenu;
class QAction;

class CreateMode : public QObject, public ModeImpl {
    Q_OBJECT

private:
    QMenu *lineMenu;
    QMenu *canvasMenu;
    QPoint *activePoint = nullptr;
    QPoint *focusedPoint = nullptr;
    Line *activeLine = nullptr;
    Line *focusedLine = nullptr;

protected:
    void paint(QPainter* painter) override;
    bool isActive(Line *line) override;
    bool isFocused(Line *line) override;

public:
    CreateMode();

    void mousePressEvent(QMouseEvent *event) override;
    void mouseReleaseEvent(QMouseEvent *event) override;
    void mouseMoveEvent(QMouseEvent *event) override;
    void contextMenuEvent(QContextMenuEvent *event) override;

public slots:
    void slotTriggered(QAction *action);

private:
    static void remove(QPoint*& ptr);

};
