#pragma once

#include "../Mode.h"

class Line;
class LineEditor;

class EditMode : public QObject, public ModeImpl {
Q_OBJECT

private:
    Line *line = nullptr;
    LineEditor* editor = nullptr;

public:
    EditMode();
    EditMode(Line *line);
    void setLine(Line *line);

protected:
    void paint(QPainter *painter) override;

public:
    void mousePressEvent(QMouseEvent *event) override;
    void mouseReleaseEvent(QMouseEvent *event) override;
    void mouseMoveEvent(QMouseEvent *event) override;
    void contextMenuEvent(QContextMenuEvent *event) override;

private slots:
    void slotClosed();

};
