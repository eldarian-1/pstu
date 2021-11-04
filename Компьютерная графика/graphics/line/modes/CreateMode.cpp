#include "CreateMode.h"

#include <QMenu>
#include <QAction>
#include <QPainter>
#include <QMouseEvent>

#include "../Canvas.h"
#include "../figures/Line.h"

const QString EDIT("Редактировать");
const QString DELETE("Удалить");
const QString DELLINES("Удалить линии");

CreateMode::CreateMode() {
    lineMenu = new QMenu();
    lineMenu->addAction(EDIT);
    lineMenu->addAction(DELETE);
    canvasMenu = new QMenu();
    canvasMenu->addAction(DELLINES);
    connect(lineMenu, SIGNAL(triggered(QAction *)), this, SLOT(slotTriggered(QAction *)));
    connect(canvasMenu, SIGNAL(triggered(QAction *)), this, SLOT(slotTriggered(QAction *)));
}

void CreateMode::paint(QPainter* painter) {
    ModeImpl::paint(painter);
    if(activePoint && focusedPoint) {
        painter->drawLine(*activePoint, *focusedPoint);
    }
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
            remove(activePoint);
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
            canvas->getLines().append(new Line(*activePoint, *focusedPoint));
            remove(activePoint);
            break;
        case Qt::RightButton:
            break;
    }
}

void CreateMode::mouseMoveEvent(QMouseEvent *event) {
    auto d = 10.;
    remove(focusedPoint);
    focusedPoint = new QPoint(event->pos());
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
    if(action->text() == EDIT) {
        canvas->setMode(Mode::edit(activeLine));
    } else if(action->text() == DELETE) {
        canvas->getLines().removeOne(activeLine);
        delete activeLine;
    } else if(action->text() == DELLINES) {
        canvas->setMode(Mode::remove());
    }
    activeLine = nullptr;
}

void CreateMode::remove(QPoint*& ptr) {
    if(ptr) {
        delete ptr;
        ptr = nullptr;
    }
}
