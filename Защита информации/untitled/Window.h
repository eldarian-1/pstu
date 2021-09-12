#pragma once

#include <QWidget>
#include <QHBoxLayout>
#include <QVBoxLayout>
#include <QPushButton>

#include "TaskManager.h"
#include "PickTask.h"
#include "GronsfeldTask.h"

class Window: public QWidget {
private:
    const char *title = "РИС-19-1б | Эльдар Миннахметов";

    QHBoxLayout* hLyt;
    QVBoxLayout* vLytMenu;
    QWidget* wgtRight;

    TaskManager *tm;

public:
    Window() {
        setWindowTitle(title);

        hLyt = new QHBoxLayout();
        vLytMenu = new QVBoxLayout();

        this->setLayout(hLyt);
        hLyt->addLayout(vLytMenu);

        wgtRight = new QWidget();
        wgtRight->setGeometry(0, 0, 360, 480);

        tm = (new TaskManager(vLytMenu, wgtRight))
                ->add(new PickTask())
                ->add(new GronsfeldTask());

        hLyt->addWidget(wgtRight);
        resize(720, 480);
    }

    ~Window() {
        delete hLyt;
        delete vLytMenu;
        delete wgtRight;
        delete tm;
    }

};