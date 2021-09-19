#pragma once

#include <vector>

#include <QObject>
#include <QPushButton>
#include <QWidget>
#include <QVBoxLayout>

#include "Task.h"

class TaskManager : public QObject {
    Q_OBJECT
private:
    std::vector<Task*> *_tasks;
    std::vector<QPushButton*> *_buttons;
    std::vector<QWidget*> *_widgets;
    QVBoxLayout *_menu;
    QWidget *_wgt;

    void setActiveTask(int iActive) {
        for(int i = 0; i < _widgets->size(); ++i) {
            (*_widgets)[i]->setHidden(i != iActive);
        }
    }

public slots:
    void onclick() {
        QString btnText = ((QPushButton*)sender())->text();
        for(int i = 0; i < _tasks->size(); ++i) {
            Task *task = (*_tasks)[i];
            if(btnText == QString(task->title())) {
                setActiveTask(i);
                task->run();
                break;
            }
        }
    }

public:
    TaskManager(QVBoxLayout *menu, QWidget *wgt) {
        _tasks = new std::vector<Task*>;
        _buttons = new std::vector<QPushButton*>;
        _widgets = new std::vector<QWidget*>;
        _menu = menu;
        _wgt = wgt;
    }

    TaskManager *add(Task *task) {
        QPushButton *btnTemp = new QPushButton(task->title());
        QWidget *wgtTemp = new QWidget(_wgt);
        wgtTemp->setGeometry(0,0, 220, 270);
        wgtTemp->setHidden(!_tasks->empty());
        task->initWidget(wgtTemp);
        _tasks->push_back(task);
        _buttons->push_back(btnTemp);
        _widgets->push_back(wgtTemp);
        _menu->addWidget(btnTemp);
        connect(btnTemp, SIGNAL(released()), this, SLOT(onclick()));
        return this;
    }

    TaskManager *start() {
        setActiveTask(0);
        (*_tasks)[0]->run();
        return this;
    }

    ~TaskManager() {
        for(Task *task : *_tasks) {
            delete task;
        }
        for(QPushButton *button : *_buttons) {
            delete button;
        }
        for(QWidget *widget : *_widgets) {
            delete widget;
        }
        delete _tasks;
        delete _buttons;
        delete _widgets;
    }

};