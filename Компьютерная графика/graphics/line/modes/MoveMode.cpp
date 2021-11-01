#include "MoveMode.h"

#include <QMenu>
#include <QAction>
#include <QPainter>
#include <QMouseEvent>

#include "../figures/Line.h"
#include "../Canvas.h"

const QString CHANGE_ANGLE("Изменить угол");
const QString FINISH_MOVE("Завершить перемещение");

MoveMode::MoveMode() {}

void MoveMode::setLine(Line *line) {
    this->line = line;
}

void MoveMode::paint(QPainter *painter) {
    int width = painter->window().width();
    int height = painter->window().height();
    line->draw(painter, width, height, true, focused);
}

void MoveMode::mousePressEvent(QMouseEvent *event) {

}

void MoveMode::mouseReleaseEvent(QMouseEvent *event) {

}

void MoveMode::mouseMoveEvent(QMouseEvent *event) {
    double d = 10.;
    focusLine(line, event->pos(), d);
    focused = d < 10.;
}

void MoveMode::contextMenuEvent(QContextMenuEvent *event) {
    QMenu menu;
    menu.addAction(CHANGE_ANGLE);
    menu.addAction(FINISH_MOVE);
    QAction* action = menu.exec(event->globalPos());
    if(action) {
        QString res = action->text();
        if (res == CHANGE_ANGLE) {

        } else if (res == FINISH_MOVE) {
            canvas->setMode(create());
        }
    }
}
