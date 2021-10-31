#pragma once

#include "../Mode.h"

class Line;
class LineEditor;

class EditMode : public ModeImpl {
private:
    Line *line;
    LineEditor* editor;

public:
    EditMode();
    void setLine(Line *line);

protected:
    void paint(QPainter *painter) override;

public:
    void mousePressEvent(QMouseEvent *event) override;
    void mouseReleaseEvent(QMouseEvent *event) override;
    void mouseMoveEvent(QMouseEvent *event) override;
    void contextMenuEvent(QContextMenuEvent *event) override;

};
