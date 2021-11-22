#pragma once

#include "../Mode.h"
#include "../widgets/LineProjector.h"

class ProjectMode : public QObject, public ModeImpl {
Q_OBJECT

private:
    Line *line;
    LineProjector* projector;

public:
    ProjectMode();
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
