#pragma once

#include <QWidget>

class QMenu;

class Line;

class Canvas : public QWidget {
Q_OBJECT
private:
    QList<Line*> lines;
    QMenu *menu;
    QPoint activePoint;

public:
    Canvas();

protected:
    void paintEvent(QPaintEvent *event) override;

    void mousePressEvent(QMouseEvent *event) override;

    void mouseReleaseEvent(QMouseEvent *event) override;

    void mouseMoveEvent(QMouseEvent *event) override;

    void contextMenuEvent(QContextMenuEvent *event) override;

public slots:
    void slotTriggered(QAction*);

};