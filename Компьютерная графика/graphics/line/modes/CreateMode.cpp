#include "CreateMode.h"

#include <QMenu>
#include <QAction>
#include <QPainter>
#include <QMouseEvent>
#include <QFileDialog>
#include <QDataStream>

#include "../Canvas.h"
#include "../figures/Line.h"
#include "../figures/Fractal.h"

bool CreateMode::drawTree = false;

const QString EDIT = "Редактировать";
const QString MIRROR = "Зеркалировать";
const QString PROJECT = "Проецировать";
const QString DELETE = "Удалить";
const QString SAVE = "Сохранить линии";
const QString LOAD = "Загрузить линии";
const QString GROUP = "Группирование";
const QString TREE = "Рисовать деревья";
const QString LINE = "Рисовать линии";
const QString DELLINES = "Удалить линии";

QString CreateMode::lineMenu(QPoint position, Line *line) {
    std::vector<QString> actions;
    if (line->isLine()) {
        actions = {EDIT, MIRROR, PROJECT};
    }
    actions.push_back(DELETE);
    return menu(position, actions);
}

QString CreateMode::canvasMenu(QPoint position) {
    std::vector<QString> actions = {SAVE, LOAD, GROUP};
    actions.push_back(drawTree ? LINE : TREE);
    actions.push_back(DELLINES);
    return menu(position, actions);
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
            Line *line;
            if (drawTree) {
                line = new FractalLine(*activePoint, *focusedPoint);
            } else {
                line = new Line(*activePoint, *focusedPoint);
            }
            canvas->getLines().append(line);
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
        QString text = lineMenu(event->globalPos(), activeLine);
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
        } else if (text == GROUP) {
            canvas->setMode(Mode::group());
        } else if (text == LINE) {
            drawTree = false;
        } else if (text == TREE) {
            drawTree = true;
        } else if (text == DELLINES) {
            canvas->setMode(Mode::remove());
        }
    }
}
