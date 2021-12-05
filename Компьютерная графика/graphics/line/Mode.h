#pragma once

#include <QObject>

class Line;
class Canvas;
class EditMode;
class CreateMode;
class ProjectMode;
class RemoveMode;
class GroupMode;
class QPainter;
class QPaintEvent;
class QMouseEvent;
class QContextMenuEvent;

class Mode {
public:
    static Canvas *canvas;

protected:
    static EditMode *editInstance;
    static CreateMode *createInstance;
    static ProjectMode *projectInstance;
    static RemoveMode *removeInstance;
    static GroupMode *groupInstance;

    template<class TMode>
    static TMode *instance(TMode *&mode, const std::function<void(void)>& task = nullptr);

public:
    virtual void paintEvent(QPaintEvent *event) = 0;
    virtual void mousePressEvent(QMouseEvent *event) = 0;
    virtual void mouseReleaseEvent(QMouseEvent *event) = 0;
    virtual void mouseMoveEvent(QMouseEvent *event) = 0;
    virtual void contextMenuEvent(QContextMenuEvent *event) = 0;

    static Mode* create();
    static Mode* edit(Line* line);
    static Mode* project(Line* line);
    static Mode* remove();
    static Mode* group();

    static QString menu(QPoint position, std::vector<QString> actions);

    static bool focusLine(Line *line, QPoint point, double &d);

    template<class T>
    static void remove(T*& ptr);

};

template<class T>
void Mode::remove(T*& ptr) {
    if(ptr) {
        delete ptr;
        ptr = nullptr;
    }
}

class ModeImpl : public Mode {
protected:
    virtual void paint(QPainter *painter);
    virtual bool isActive(Line *line);
    virtual bool isFocused(Line *line);

public:
    void paintEvent(QPaintEvent *event) override;

};

class StateMode : public Mode {
private:
    Mode* state;

public:
    StateMode(Canvas *canvas);

    void setState(Mode* state);

    void paintEvent(QPaintEvent *event) override;
    void mousePressEvent(QMouseEvent *event) override;
    void mouseReleaseEvent(QMouseEvent *event) override;
    void mouseMoveEvent(QMouseEvent *event) override;
    void contextMenuEvent(QContextMenuEvent *event) override;

};
