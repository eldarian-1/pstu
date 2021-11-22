#include "ProjectMode.h"

#include "../Canvas.h"

ProjectMode::ProjectMode() {
    line = nullptr;
    projector = nullptr;
}

void ProjectMode::setLine(Line *line) {
    if(projector) {
        delete projector;
    }
    this->line = line;
    projector = new LineProjector(line);
    connect(projector, SIGNAL(closed()), SLOT(slotClosed()));
}

void ProjectMode::paint(QPainter *painter) {
    ModeImpl::paint(painter);
}

void ProjectMode::mousePressEvent(QMouseEvent *event) {}

void ProjectMode::mouseReleaseEvent(QMouseEvent *event) {}

void ProjectMode::mouseMoveEvent(QMouseEvent *event) {}

void ProjectMode::contextMenuEvent(QContextMenuEvent *event) {}

void ProjectMode::slotClosed() {
    canvas->setMode(Mode::create());
}