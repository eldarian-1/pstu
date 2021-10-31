#include "EditMode.h"

#include <QMenu>
#include <QAction>
#include <QPainter>
#include <QMouseEvent>
#include <QColorDialog>

#include "../Line.h"
#include "../Canvas.h"
#include "../widgets/LineEditor.h"

EditMode::EditMode() {}

EditMode::EditMode(Line *line) : EditMode() {
    setLine(line);
}

void EditMode::setLine(Line *line) {
    if(editor) {
        delete editor;
    }
    editor = new LineEditor(line);
}

void EditMode::paint(QPainter *painter) {
    painter->setBrush(QBrush(Qt::white));
    int width = painter->window().width();
    int height = painter->window().height();
    painter->drawRect(-1, -1, width + 1, height + 1);
    for(auto line : canvas->getLines()) {
        line->draw(painter, width, height);
    }
}

void EditMode::mousePressEvent(QMouseEvent *event) {}

void EditMode::mouseReleaseEvent(QMouseEvent *event) {}

void EditMode::mouseMoveEvent(QMouseEvent *event) {}

void EditMode::contextMenuEvent(QContextMenuEvent *event) {}
