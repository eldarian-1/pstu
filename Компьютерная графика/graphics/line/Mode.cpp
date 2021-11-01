#include "Mode.h"

#include <QMenu>
#include <QPainter>
#include <QPaintEvent>

#include "figures/Line.h"
#include "Canvas.h"

#include "modes/CreateMode.h"
#include "modes/MoveMode.h"
#include "modes/EditMode.h"

Canvas *Mode::canvas = nullptr;
CreateMode *Mode::createInstance = nullptr;
MoveMode *Mode::moveInstance = nullptr;
EditMode *Mode::editInstance = nullptr;

Mode* Mode::create() {
    if(createInstance == nullptr) {
        createInstance = new CreateMode;
    }
    return createInstance;
}

Mode* Mode::move(Line* line) {
    if(moveInstance == nullptr) {
        moveInstance = new MoveMode;
    }
    moveInstance->setLine(line);
    return moveInstance;
}

Mode* Mode::edit(Line* line) {
    if(editInstance == nullptr) {
        editInstance = new EditMode;
    }
    editInstance->setLine(line);
    return editInstance;
}

bool Mode::focusLine(Line *line, QPoint point, double &d) {
    auto allow = line->getWeight() / 2.;
    auto real = line->distanceFrom(point);
    auto diff = abs(allow - real);
    if(real < allow || diff < d) {
        d = diff;
        return true;
    }
    return false;
}

void ModeImpl::paintEvent(QPaintEvent *event) {
    QPainter painter;
    painter.begin(canvas);
    paint(&painter);
    painter.end();
}

StateMode::StateMode(Canvas *canvas) {
    Mode::canvas = canvas;
    state = Mode::create();
}

void StateMode::setState(Mode* state) {
    this->state = state;
}

void StateMode::paintEvent(QPaintEvent *event) {
    state->paintEvent(event);
}

void StateMode::mousePressEvent(QMouseEvent *event) {
    state->mousePressEvent(event);
}

void StateMode::mouseReleaseEvent(QMouseEvent *event) {
    state->mouseReleaseEvent(event);
}

void StateMode::mouseMoveEvent(QMouseEvent *event) {
    state->mouseMoveEvent(event);
}

void StateMode::contextMenuEvent(QContextMenuEvent *event) {
    state->contextMenuEvent(event);
}
