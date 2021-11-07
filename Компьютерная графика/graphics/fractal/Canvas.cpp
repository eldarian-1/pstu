#include "Canvas.h"

#include <QMenu>
#include <QAction>
#include <QPainter>
#include <QPaintEvent>

#include "FractalEditor.h"

#include <Graphic.h>

const char *SETTINGS = "Настройки";

Canvas *Canvas::_instance = nullptr;

Canvas::Canvas() : QWidget() {
    setWindowTitle("Фрактальное дерево");
    setFixedSize(1200, 700);
}

Canvas *Canvas::instance() {
    if(!_instance) {
        _instance = new Canvas;
    }
    return _instance;
}

void Canvas::clearEditor() {
    if(editor) {
        delete editor;
        editor = nullptr;
    }
}

void Canvas::contextMenuEvent(QContextMenuEvent* event) {
    if(editor) {
        return;
    }
    QMenu menu;
    menu.addAction(SETTINGS);
    QAction *action = menu.exec(event->globalPos());
    if(action && action->text() == SETTINGS) {
        editor = new FractalEditor();
        editor->show();
    }
}

void Canvas::paintEvent(QPaintEvent* event) {
    QPainter painter;
    painter.begin(this);
    painter.setBrush(Qt::white);
    painter.drawRect(-1, -1, 1202, 702);
    FractalSettings *set = FractalSettings::instance();
    paint(&painter, set->first, set->second, 0);
    painter.end();
}

void Canvas::paint(QPainter* painter, QPoint begin, QPoint end, int i) {
    FractalSettings *set = FractalSettings::instance();
    if(i == set->iterations) {
        return;
    }
    Level &level = i < set->levels.size() ? set->levels[i] : set->levels.back();
    painter->setPen(QPen(level.color, level.weight));
    painter->drawLine(begin.x(), 700 - begin.y(), end.x(), 700 - end.y());
    QPoint target = Graphic::continuation(begin, end, level.multiplier);
    for(int j = 0, n = set->angles.size(); j < n; ++j) {
        paint(painter, end, rotate(end, target, set->angles[j]), i + 1);
    }
}

QPoint Canvas::rotate(QPoint begin, QPoint end, double angle) {
    double a = Graphic::degreesToRadians(angle);
    double c = Graphic::angle(begin, end);
    double l = Graphic::distance(begin, end);
    QPoint target = Graphic::rotate(QPoint(l, 0), c + a);
    target.rx() += begin.x();
    target.ry() += begin.y();
    return target;
}
