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
const QString EDIT("Редактировать");
const QString DELETE("Удалить");

CreateMode::CreateMode() {
    menu = new QMenu();
    menu->addAction(COLOR);
    menu->addAction(WEIGHT);
    menu->addAction(MOVE);
    menu->addAction(EDIT);
    menu->addAction(DELETE);
    connect(menu, SIGNAL(triggered(QAction*)), this, SLOT(slotTriggered(QAction*)));
}

void CreateMode::paint(QPainter *painter) {
    painter->setBrush(QBrush(Qt::white));
    int width = painter->window().width();
    int height = painter->window().height();
    painter->drawRect(-1, -1, width + 1, height + 1);
    for(auto line : canvas->getLines()) {
        line->draw(painter, width, height, line == activeLine, line == focusedLine);
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
            if(focusedLine) {
                activeLine = focusedLine;
            }
            break;
    }
}

void CreateMode::mouseReleaseEvent(QMouseEvent *event) {
    switch(event->button()) {
        case Qt::LeftButton:
            canvas->getLines().append(new Line(*activePoint, event->pos()));
            break;
        case Qt::RightButton:
            break;
    }
}

void CreateMode::mouseMoveEvent(QMouseEvent *event) {
    auto d = 10.;
    for(auto line : canvas->getLines()) {
        if(focusLine(line, event->pos(), d)) {
            focusedLine = line;
        }
    }
    if(d == 10. && focusedLine) {
        focusedLine = nullptr;
    }
}

void CreateMode::contextMenuEvent(QContextMenuEvent *event) {
    if(focusedLine) {
        activeLine = focusedLine;
    }
    if(activeLine) {
        menu->exec(event->globalPos());
        activeLine = nullptr;
        focusedLine = nullptr;
    }
}

void CreateMode::slotTriggered(QAction *action) {
    if(action->text() == COLOR) {
        activeLine->setColor(QColorDialog::getColor(activeLine->getColor()));
    } else if(action->text() == WEIGHT) {
        WeightDialog *dialog = new WeightDialog(activeLine->getWeight());
        if(dialog->exec() == QDialog::Accepted) {
            activeLine->setWeight(dialog->width());
        }
        delete dialog;
    } else if(action->text() == MOVE) {
        canvas->setMode(Mode::move(activeLine));
    } else if(action->text() == EDIT) {
        canvas->setMode(Mode::edit(activeLine));
    } else if(action->text() == DELETE) {
        canvas->getLines().removeOne(activeLine);
        delete activeLine;
    }
    activeLine = nullptr;
}
