#pragma once

class QWidget;

class Task {
private:
    const char *_title;

protected:
    Task(const char *title) : _title(title) {}

public:
    virtual void initWidget(QWidget *wgt) = 0;

    virtual void run() const = 0;

    const char *title() const { return _title; }

};