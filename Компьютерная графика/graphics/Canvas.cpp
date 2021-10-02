#include <QWidget>
#include <QPainter>
#include <QPaintEvent>
#include <QMenu>
#include <QColorDialog>

#include "Canvas.h"
#include "Line.h"
#include "WidthDialog.h"
#include "common.h"

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
    connect(menu, SIGNAL(triggered(QAction*)), this, SLOT(slotTriggered(QAction*)));
}

void Canvas::paintEvent(QPaintEvent *event) {
    QPainter painter;
    painter.begin(this);
    painter.setBrush(QBrush(Qt::white));
    painter.drawRect(3, 3, 994, 494);
    for(auto line : lines) {
        line->draw(&painter);
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
            repaint();
            break;
    }
}

void Canvas::mouseReleaseEvent(QMouseEvent *event) {
    switch(event->button()) {
        case Qt::LeftButton:
            lines.append(new Line(activePoint, event->pos()));
            repaint();
            break;
        case Qt::RightButton:
            Line::rightButtonPressed = false;
            repaint();
            break;
    }
}

void Canvas::mouseMoveEvent(QMouseEvent *event) {
    double d = 10.;
    for(auto line : lines) {
        auto td = d + line->getWidth() / 2;
        auto t = distance(*line, event->pos());
        if(t < td) {
            d = td - t;
            line->activize();
        }
    }
    if(d == 10. && Line::active) {
        Line::active = nullptr;
        repaint();
    } else if(d < 10.) {
        repaint();
    }
}

void Canvas::contextMenuEvent(QContextMenuEvent *event) {
    if(Line::active) {
        menu->exec(event->globalPos());
        Line::active = nullptr;
        Line::rightButtonPressed = false;
        repaint();
    }
}

void Canvas::slotTriggered(QAction *action) {
    if(action->text() == COLOR) {
        Line::active->setColor(QColorDialog(Line::active->getColor()).getColor());
    } else if(action->text() == WEIGHT) {
        WidthDialog *dialog = new WidthDialog(Line::active->getWidth());
        if(dialog->exec() == QDialog::Accepted) {
            Line::active->setWidth(dialog->width());
        }
        delete dialog;
    } else if(action->text() == DELETE) {
        lines.removeOne(Line::active);
        delete Line::active;
        Line::active = nullptr;
    }
}