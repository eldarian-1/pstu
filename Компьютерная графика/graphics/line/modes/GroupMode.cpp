#include "GroupMode.h"

#include <QMenu>
#include <QAction>
#include <QPainter>
#include <QMouseEvent>
#include <QColorDialog>

#include "../Canvas.h"
#include "../figures/Line.h"

const QString CANCEL = "Отменить выделение";
const QString CREATE = "Создание";

void GroupMode::drawRect(QPainter *painter, QRect *r, QColor color) {
    painter->setPen(QPen(color, 1, Qt::DashLine));
    painter->setBrush(Qt::NoBrush);
    painter->drawRect(*r);
}

void GroupMode::drawPoints(QPainter *painter, QVector<QPoint*>& ps, QColor color) {
    painter->setPen(QPen(color, 3));
    for(QPoint* point : points) {
        painter->drawPoint(*point);
    }
}

GroupMode::GroupMode() {}

void GroupMode::paint(QPainter *painter) {
    ModeImpl::paint(painter);
    if (rect) {
        drawRect(painter, rect, Qt::black);
        drawPoints(painter, points, Qt::black);
    }
    if (firstPoint && secondPoint) {
        QRect r = getRect(*firstPoint, *secondPoint);
        drawRect(painter, &r, Qt::darkBlue);
        QVector<QPoint*> ps = getPoints(r);
        drawPoints(painter, ps, Qt::darkBlue);
    }
}

QRect GroupMode::getRect(QPoint p1, QPoint p2) {
    return QRect(
            QPoint(
                    std::min(p1.x(), p2.x()),
                    std::min(p1.y(), p2.y())
            ),
            QPoint(
                    std::max(p1.x(), p2.x()),
                    std::max(p1.y(), p2.y())
            )
    );
}

QPoint GroupMode::newPoint(QPoint p1, QPoint p2, QPoint t) {
    int dx = p1.x() - p2.x();
    int dy = p1.y() - p2.y();
    return QPoint(t.x() - dx, t.y() - dy);
}

bool GroupMode::isPointInRect(QRect &r, QPoint p) {
    return r.x() <= p.x() && r.y() <= p.y()
        && p.x() <= (r.x() + r.width())
        && p.y() <= (r.y() + r.height());
}

QVector<QPoint*> GroupMode::getPoints(QRect &r) {
    QVector<QPoint*> ps;
    for(Line* line : canvas->getLines()) {
        if(isPointInRect(r, line->top())) {
            ps.push_back(&line->top());
        }
        if(isPointInRect(r, line->bottom())) {
            ps.push_back(&line->bottom());
        }
    }
    return ps;
}

void GroupMode::mousePressEvent(QMouseEvent *event) {
    if (event->button() == Qt::LeftButton) {
        if (rect && isPointInRect(*rect, event->pos())) {
            remove(movePoint);
            movePoint = new QPoint(event->pos());
        } else {
            points.clear();
            remove(firstPoint);
            firstPoint = new QPoint(event->pos());
        }
    }
}

void GroupMode::mouseReleaseEvent(QMouseEvent *event) {
    if (event->button() == Qt::LeftButton) {
        if (firstPoint && secondPoint) {
            remove(rect);
            rect = new QRect(getRect(*firstPoint, *secondPoint));
            points = getPoints(*rect);
            remove(firstPoint);
            remove(secondPoint);
        } else if (movePoint) {
            remove(movePoint);
        }
    }
}

void GroupMode::mouseMoveEvent(QMouseEvent *event) {
    if (firstPoint) {
        remove(secondPoint);
        secondPoint = new QPoint(event->pos());
    } else if (movePoint) {
        for(QPoint* point : points) {
            *point = newPoint(*movePoint, event->pos(), *point);
        }
        rect->setBottomLeft(newPoint(*movePoint, event->pos(), rect->bottomLeft()));
        rect->setTopRight(newPoint(*movePoint, event->pos(), rect->topRight()));
        remove(movePoint);
        movePoint = new QPoint(event->pos());
    }
    canvas->setStatus(QString::asprintf("x: %d\ny: %d", event->pos().x(), event->pos().y()));
}

void GroupMode::contextMenuEvent(QContextMenuEvent *event) {
    QString text;
    if (isPointInRect(*rect, event->pos())) {
        text = Mode::menu(event->globalPos(), {CANCEL});
    } else {
        text = Mode::menu(event->globalPos(), {CREATE});
    }
    if(text == CANCEL) {
        points.clear();
        remove(rect);
    } else if(text == CREATE) {
        points.clear();
        remove(rect);
        remove(movePoint);
        remove(firstPoint);
        remove(secondPoint);
        canvas->setMode(Mode::create());
    }
}
