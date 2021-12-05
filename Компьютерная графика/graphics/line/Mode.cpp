#include "Mode.h"

#include <QMenu>
#include <QPainter>
#include <QPaintEvent>

#include "figures/Line.h"
#include "Canvas.h"

#include "modes/CreateMode.h"
#include "modes/EditMode.h"
#include "modes/ProjectMode.h"
#include "modes/RemoveMode.h"
#include "modes/GroupMode.h"

Canvas *Mode::canvas = nullptr;
CreateMode *Mode::createInstance = nullptr;
EditMode *Mode::editInstance = nullptr;
ProjectMode *Mode::projectInstance = nullptr;
RemoveMode *Mode::removeInstance = nullptr;
GroupMode *Mode::groupInstance = nullptr;

template<class TMode>
TMode *Mode::instance(TMode *&mode, const std::function<void(void)>& task) {
    if(mode == nullptr) {
        mode = new TMode;
    }
    if(task) {
        task();
    }
    return mode;
}

Mode* Mode::create() {
    return instance(createInstance);
}

Mode* Mode::edit(Line* line) {
    return instance(editInstance, [&]() {
        editInstance->setLine(line);
    });
}

Mode* Mode::project(Line* line) {
    return instance(projectInstance, [&]() {
        projectInstance->setLine(line);
    });
}

Mode* Mode::remove() {
    return instance(removeInstance, [&]() {
        removeInstance->start();
    });
}

Mode* Mode::group() {
    return instance(groupInstance);
}

QString Mode::menu(QPoint position, std::vector<QString> actions) {
    QMenu menu;
    for(QString action : actions) {
        menu.addAction(action);
    }
    QAction *action = menu.exec(position);
    return (action ? action->text() : "");
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

void ModeImpl::paint(QPainter *painter) {
    painter->setBrush(QBrush(Qt::white));
    int width = painter->window().width();
    int height = painter->window().height();
    painter->drawRect(-1, -1, width + 1, height + 1);
    for(auto line : canvas->getLines()) {
        line->draw(painter, isActive(line), isFocused(line));
    }
}

bool ModeImpl::isActive(Line *line) {
    return false;
}

bool ModeImpl::isFocused(Line *line) {
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
