#pragma once

#include "../Mode.h"
#include "../figures/Point.h"

class GroupMode : public QObject, public ModeImpl {
    Q_OBJECT

private:
    QVector<QPoint*> points;
    QRect *rect = nullptr;
    QPoint *firstPoint = nullptr;
    QPoint *secondPoint = nullptr;
    QPoint *movePoint = nullptr;

    QString menu(QPoint position);

    static void drawRect(QPainter *painter, QRect *r, QColor color);
    void drawPoints(QPainter *painter, QVector<QPoint*>& ps, QColor color);
    static QRect getRect(QPoint p1, QPoint p2);
    static QPoint newPoint(QPoint p1, QPoint p2, QPoint target);
    static bool isPointInRect(QRect &r, QPoint p);
    static QVector<QPoint*> getPoints(QRect &r);

public:
    GroupMode();

protected:
    void paint(QPainter *painter) override;

public:
    void mousePressEvent(QMouseEvent *event) override;
    void mouseReleaseEvent(QMouseEvent *event) override;
    void mouseMoveEvent(QMouseEvent *event) override;
    void contextMenuEvent(QContextMenuEvent *event) override;

};
