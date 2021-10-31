#include "CreateMode.h"

#include <QMenu>
#include <QAction>
#include <QPainter>
#include <QMouseEvent>
#include <QColorDialog>

#include "../Line.h"
#include "../Canvas.h"
#include "../dialogs/WeightDialog.h"

const QString COLOR("Изменить цвет");
const QString WEIGHT("Изменить толщину");
const QString MOVE("Переместить");
const QString DELETE("Удалить");

CreateMode::CreateMode() {
    menu = new QMenu();
    menu->addAction(COLOR);
    menu->addAction(WEIGHT);
    menu->addAction(MOVE);
    menu->addAction(DELETE);
    connect(menu, SIGNAL(triggered(QAction*)), this, SLOT(slotTriggered(QAction*)));
}

void CreateMode::paint(QPainter *painter) {
    painter->setBrush(QBrush(Qt::white));
    int width = painter->window().width();
    int height = painter->window().height();
    painter->drawRect(-1, -1, width + 1, height + 1);
    for(auto line : canvas->getLines()) {
        line->draw(painter, width, height);
    }
}

void CreateMode::mousePressEvent(QMouseEvent *event) {
    switch(event->button()) {
        case Qt::LeftButton:
            if(activePoint) {
                delete activePoint;
                activePoint = nullptr;
            }
            activePoint = new QPoint(event->pos());
            break;
        case Qt::RightButton:
            Line::rightButtonPressed = true;
            break;
    }
}

void CreateMode::mouseReleaseEvent(QMouseEvent *event) {
    switch(event->button()) {
        case Qt::LeftButton:
            canvas->getLines().append(new Line(*activePoint, event->pos()));
            break;
        case Qt::RightButton:
            Line::rightButtonPressed = false;
            break;
    }
}

void CreateMode::mouseMoveEvent(QMouseEvent *event) {
    auto d = 10.;
    for(auto line : canvas->getLines()) {
        focusLine(line, event->pos(), d);
    }
    if(d == 10. && Line::active) {
        Line::active = nullptr;
    }
}

void CreateMode::contextMenuEvent(QContextMenuEvent *event) {
    if(Line::active) {
        menu->exec(event->globalPos());
        Line::active = nullptr;
        Line::rightButtonPressed = false;
    }
}

void CreateMode::slotTriggered(QAction *action) {
    if(action->text() == COLOR) {
        Line::active->setColor(QColorDialog(Line::active->getColor()).getColor());
    } else if(action->text() == WEIGHT) {
        WeightDialog *dialog = new WeightDialog(Line::active->getWeight());
        if(dialog->exec() == QDialog::Accepted) {
            Line::active->setWeight(dialog->width());
        }
        delete dialog;
    } else if(action->text() == MOVE) {
        canvas->setMode(Mode::move(Line::active));
    } else if(action->text() == DELETE) {
        canvas->getLines().removeOne(Line::active);
        delete Line::active;
        Line::active = nullptr;
    }
}
