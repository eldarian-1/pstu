#include "EditMode.h"

#include <QMenu>
#include <QAction>
#include <QPainter>
#include <QMouseEvent>
#include <QColorDialog>

#include "../Canvas.h"
#include "../figures/Line.h"
#include "../figures/Point.h"
#include "../widgets/LineEditor.h"

#include <Graphic.h>

Point top, middle, bottom;
Point *focusedPoint = nullptr, *activePoint = nullptr;

EditMode::EditMode() {}

EditMode::EditMode(Line *line) : EditMode() {
    setLine(line);
}

void EditMode::setLine(Line *line) {
    if(editor) {
        delete editor;
    }
    this->line = line;
    editor = new LineEditor(line);
    connect(editor, SIGNAL(closed()), SLOT(slotClosed()));
}

void EditMode::paint(QPainter *painter) {
    painter->setBrush(QBrush(Qt::white));
    int width = painter->window().width();
    int height = painter->window().height();
    painter->drawRect(-1, -1, width + 1, height + 1);
    for(auto line : canvas->getLines()) {
        line->draw(painter, width, height);
    }

    if(line != nullptr) {
        line->getPoints(top.qt(), middle.qt(), bottom.qt(), width, height);
        painter->setPen(QPen(QBrush(Qt::red), 10));
        top.draw(painter, false, false);
        middle.draw(painter, false, false);
        bottom.draw(painter, false, false);
    }
}

void EditMode::mousePressEvent(QMouseEvent *event) {
    activePoint = focusedPoint ? focusedPoint : nullptr;
}

void EditMode::mouseReleaseEvent(QMouseEvent *event) {
    if(activePoint) {
        activePoint = nullptr;
    }
}

void EditMode::mouseMoveEvent(QMouseEvent *event) {
    if(activePoint) {

    } else {
        if (Graphic::isPoint(event->pos(), top.qt(), 5)) {
            focusedPoint = &top;
        } else if (Graphic::isPoint(event->pos(), middle.qt(), 5)) {
            focusedPoint = &middle;
        } else if (Graphic::isPoint(event->pos(), bottom.qt(), 5)) {
            focusedPoint = &bottom;
        } else {
            focusedPoint = nullptr;
        }
    }
}

void EditMode::contextMenuEvent(QContextMenuEvent *event) {}

void EditMode::slotClosed() {
    canvas->setMode(Mode::create());
}
