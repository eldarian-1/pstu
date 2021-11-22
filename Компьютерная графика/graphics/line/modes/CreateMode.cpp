#include "CreateMode.h"

#include <QMenu>
#include <QAction>
#include <QPainter>
#include <QMouseEvent>
#include <QFileDialog>
#include <QDataStream>

#include "../Canvas.h"
#include "../figures/Line.h"

const QString EDIT = "Редактировать";
const QString MIRROR = "Зеркалировать";
const QString PROJECT = "Проецировать";
const QString DELETE = "Удалить";
const QString SAVE = "Сохранить линии";
const QString LOAD = "Загрузить линии";
const QString DELLINES = "Удалить линии";

QString CreateMode::lineMenu(QPoint position) {
    QMenu menu;
    menu.addAction(EDIT);
    menu.addAction(MIRROR);
    menu.addAction(PROJECT);
    menu.addAction(DELETE);
    QAction *action = menu.exec(position);
    return (action ? action->text() : "");
}

QString CreateMode::canvasMenu(QPoint position) {
    QMenu menu;
    menu.addAction(SAVE);
    menu.addAction(LOAD);
    menu.addAction(DELLINES);
    QAction *action = menu.exec(position);
    return (action ? action->text() : "");
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
        canvas->setStatus(QString::asprintf("x: %d\ny: %d", event->pos().x(), event->pos().y()));
    }
}

void CreateMode::contextMenuEvent(QContextMenuEvent *event) {
    if(focusedLine) {
        activeLine = focusedLine;
    }
    if(activeLine) {
        QString text = lineMenu(event->globalPos());
        if(text == EDIT) {
            canvas->setMode(Mode::edit(activeLine));
        } else if(text == MIRROR) {
            int x1 = activeLine->top().x(), x2 = activeLine->bottom().x();
            int y1 = activeLine->top().y(), y2 = activeLine->bottom().y();
            activeLine->rebuild(QPoint(x1, y2), QPoint(x2, y1));
        } else if(text == PROJECT) {
            canvas->setMode(Mode::project(activeLine));
        } else if(text == DELETE) {
            canvas->getLines().removeOne(activeLine);
            delete activeLine;
        }
        activeLine = nullptr;
        focusedLine = nullptr;
    } else {
        QString text = canvasMenu(event->globalPos());
        if (text == SAVE) {
            QFile file(QFileDialog::getSaveFileName());
            file.open(QIODevice::WriteOnly);
            QTextStream out(&file);
            out << *Mode::canvas;
            file.close();
        } else if (text == LOAD) {
            QFile file(QFileDialog::getOpenFileName());
            file.open(QIODevice::ReadOnly);
            QTextStream in(&file);
            in >> *Mode::canvas;
            file.close();
        } else if (text == DELLINES) {
            canvas->setMode(Mode::remove());
        }
    }
}

void CreateMode::remove(QPoint*& ptr) {
    if(ptr) {
        delete ptr;
        ptr = nullptr;
    }
}
