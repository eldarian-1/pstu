#pragma once

#include "../Mode.h"

class QMenu;
class QAction;

class CreateMode : public QObject, public ModeImpl {
    Q_OBJECT

private:
    QMenu *menu;
    QPoint *activePoint = nullptr;
    Line *activeLine = nullptr;
    Line *focusedLine = nullptr;

protected:
    void paint(QPainter *painter) override;

public:
    CreateMode();

    void mousePressEvent(QMouseEvent *event) override;
    void mouseReleaseEvent(QMouseEvent *event) override;
    void mouseMoveEvent(QMouseEvent *event) override;
    void contextMenuEvent(QContextMenuEvent *event) override;

public slots:
    void slotTriggered(QAction *action);

};
