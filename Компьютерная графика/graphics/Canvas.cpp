#include <QWidget>
#include <QPainter>
#include <QPaintEvent>
#include <QMenu>
#include <QColorDialog>

#include "Canvas.h"
#include "Line.h"
#include "WidthDialog.h"

const QString COLOR("Изменить цвет");
const QString WEIGHT("Изменить толщину");
const QString DELETE("Удалить");

Canvas::Canvas() : QWidget() {
    resize(1000, 500);
    setWindowTitle("Компьютерная графика | РИС-19-1б | Миннахметов Эльдар");
    setMouseTracking(true);
    menu = new QMenu();
    menu->addAction(COLOR);
    menu->addAction(WEIGHT);
    menu->addAction(DELETE);
    startTimer(20);
    connect(menu, SIGNAL(triggered(QAction*)), this, SLOT(slotTriggered(QAction*)));
}

void Canvas::paintEvent(QPaintEvent *event) {
    QPainter painter;
    painter.begin(this);
    painter.setBrush(QBrush(Qt::white));
    int width = painter.window().width();
    int height = painter.window().height();
    painter.drawRect(-1, -1, width + 1, height + 1);
    for(auto line : lines) {
        line->draw(&painter, width, height);
    }
    painter.end();
}

void Canvas::mousePressEvent(QMouseEvent *event) {
    switch(event->button()) {
        case Qt::LeftButton:
            activePoint = event->pos();
            break;
        case Qt::RightButton:
            Line::rightButtonPressed = true;
            break;
    }
}

void Canvas::mouseReleaseEvent(QMouseEvent *event) {
    switch(event->button()) {
        case Qt::LeftButton:
            lines.append(new Line(activePoint, event->pos()));
            break;
        case Qt::RightButton:
            Line::rightButtonPressed = false;
            break;
    }
}

void Canvas::mouseMoveEvent(QMouseEvent *event) {
    auto d = 20.;
    for(auto line : lines) {
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

void Canvas::contextMenuEvent(QContextMenuEvent *event) {
    if(Line::active) {
        menu->exec(event->globalPos());
        Line::active = nullptr;
        Line::rightButtonPressed = false;
    }
}

void Canvas::timerEvent(QTimerEvent *event) {
    repaint();
}

void Canvas::slotTriggered(QAction *action) {
    if(action->text() == COLOR) {
        Line::active->setColor(QColorDialog(Line::active->getColor()).getColor());
    } else if(action->text() == WEIGHT) {
        WidthDialog *dialog = new WidthDialog(Line::active->getThickness());
        if(dialog->exec() == QDialog::Accepted) {
            Line::active->setThickness(dialog->width());
        }
        delete dialog;
    } else if(action->text() == DELETE) {
        lines.removeOne(Line::active);
        delete Line::active;
        Line::active = nullptr;
    }
}