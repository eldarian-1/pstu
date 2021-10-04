#include "Mode.h"

#include <QMenu>
#include <QBrush>
#include <QWidget>
#include <QPainter>
#include <QPaintEvent>
#include <QMouseEvent>
#include <QColorDialog>

#include "Line.h"
#include "Canvas.h"
#include "WidthDialog.h"

const QString COLOR("Изменить цвет");
const QString WEIGHT("Изменить толщину");
const QString DELETE("Удалить");

void ModeImpl::paintEvent(QPaintEvent *event) {
    QPainter painter;
    painter.begin(canvas);
    paint(&painter);
    painter.end();
}

StateMode::StateMode(Canvas *canvas) {
    state = new CreateMode(canvas);
}

void StateMode::setState(ModeImpl* state) {
    if(this->state) {
        delete this->state;
    }
    this->state = state;
}

CreateMode::CreateMode(Canvas *canvas) : ModeImpl(canvas) {
    menu = new QMenu();
    menu->addAction(COLOR);
    menu->addAction(WEIGHT);
    menu->addAction(DELETE);
    connect(menu, SIGNAL(triggered(QAction*)), this, SLOT(slotTriggered(QAction*)));
}

void CreateMode::paint(QPainter *painter) {
    painter->setBrush(QBrush(Qt::white));
    int width = painter->window().width();
    int height = painter->window().height();
    painter->drawRect(-1, -1, width + 1, height + 1);
    for(auto line : getCanvas()->getLines()) {
        line->draw(painter, width, height);
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
            Line::rightButtonPressed = true;
            break;
    }
}

void CreateMode::mouseReleaseEvent(QMouseEvent *event) {
    switch(event->button()) {
        case Qt::LeftButton:
            getCanvas()->getLines().append(new Line(*activePoint, event->pos()));
            break;
        case Qt::RightButton:
            Line::rightButtonPressed = false;
            break;
    }
}

void CreateMode::mouseMoveEvent(QMouseEvent *event) {
    auto d = 20.;
    for(auto line : getCanvas()->getLines()) {
        auto allow = line->getThickness() / 2. + 10.;
        auto real = line->distanceFrom(event->pos());
        auto diff = allow - real;
        if(diff > 0 && diff < d) {
            d = diff;
            line->activize();
        }
    }
    if(d == 20. && Line::active) {
        Line::active = nullptr;
    }
}

void CreateMode::contextMenuEvent(QContextMenuEvent *event) {
    if(Line::active) {
        menu->exec(event->globalPos());
        Line::active = nullptr;
        Line::rightButtonPressed = false;
    }
}

void CreateMode::slotTriggered(QAction *action) {
    if(action->text() == COLOR) {
        Line::active->setColor(QColorDialog(Line::active->getColor()).getColor());
    } else if(action->text() == WEIGHT) {
        WidthDialog *dialog = new WidthDialog(Line::active->getThickness());
        if(dialog->exec() == QDialog::Accepted) {
            Line::active->setThickness(dialog->width());
        }
        delete dialog;
    } else if(action->text() == DELETE) {
        getCanvas()->getLines().removeOne(Line::active);
        delete Line::active;
        Line::active = nullptr;
    }
}

MoveMode::MoveMode(Canvas *canvas) : ModeImpl(canvas) {}

void MoveMode::mousePressEvent(QMouseEvent *event) {

}

void MoveMode::mouseReleaseEvent(QMouseEvent *event) {

}

void MoveMode::mouseMoveEvent(QMouseEvent *event) {

}

void MoveMode::contextMenuEvent(QContextMenuEvent *event) {

}
