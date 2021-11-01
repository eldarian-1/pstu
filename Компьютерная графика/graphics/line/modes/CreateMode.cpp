#include "CreateMode.h"

#include <QMenu>
#include <QAction>
#include <QPainter>
#include <QMouseEvent>
#include <QColorDialog>

#include "../figures/Line.h"
#include "../Canvas.h"
#include "../dialogs/WeightDialog.h"

const QString COLOR("Изменить цвет");
const QString WEIGHT("Изменить толщину");
const QString MOVE("Переместить");
const QString EDIT("Редактировать");
const QString DELETE("Удалить");
const QString DELLINES("Удалить линии");

CreateMode::CreateMode() {
    lineMenu = new QMenu();
    lineMenu->addAction(COLOR);
    lineMenu->addAction(WEIGHT);
    lineMenu->addAction(MOVE);
    lineMenu->addAction(EDIT);
    lineMenu->addAction(DELETE);
    canvasMenu = new QMenu();
    canvasMenu->addAction(DELLINES);
    connect(lineMenu, SIGNAL(triggered(QAction *)), this, SLOT(slotTriggered(QAction *)));
    connect(canvasMenu, SIGNAL(triggered(QAction *)), this, SLOT(slotTriggered(QAction *)));
}

bool CreateMode::isActive(Line *line) {
    return line == activeLine;
}

bool CreateMode::isFocused(Line *line) {
    return line == focusedLine;
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
    } else if (focusedLine) {
        canvas->setStatus(focusedLine->toString());
    }
    if(!focusedLine) {
        canvas->setStatus("");
    }
}

void CreateMode::contextMenuEvent(QContextMenuEvent *event) {
    if(focusedLine) {
        activeLine = focusedLine;
    }
    if(activeLine) {
        lineMenu->exec(event->globalPos());
        activeLine = nullptr;
        focusedLine = nullptr;
    } else {
        canvasMenu->exec(event->globalPos());
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
    } else if(action->text() == DELLINES) {
        canvas->setMode(Mode::remove());
    }
    activeLine = nullptr;
}
