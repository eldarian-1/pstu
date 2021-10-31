#pragma once

#include "../Mode.h"

class MoveMode : public ModeImpl {
private:
    Line* line = nullptr;
    bool focused = false;

protected:
    void paint(QPainter *painter) override;

public:
    MoveMode();
    void setLine(Line *line);

    void mousePressEvent(QMouseEvent *event) override;
    void mouseReleaseEvent(QMouseEvent *event) override;
    void mouseMoveEvent(QMouseEvent *event) override;
    void contextMenuEvent(QContextMenuEvent *event) override;

};
