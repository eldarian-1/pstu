#pragma once

#include <QPoint>
#include <QLine>
#include <QWidget>

class QPainter;
class QPaintEvent;
class FractalEditor;
class QContextMenuEvent;

class Canvas : public QWidget {
Q_OBJECT

private:
    static Canvas *_instance;

    FractalEditor *editor = nullptr;

    Canvas();

public:
    static Canvas *instance();
    void clearEditor();

protected:
    void contextMenuEvent(QContextMenuEvent* event) override;
    void paintEvent(QPaintEvent* event) override;
    void paint(QPainter* painter, QPoint begin, QPoint end, int i);
    static QPoint rotate(QPoint begin, QPoint end, double angle);

};
