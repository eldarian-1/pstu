#pragma once

#include <QWidget>
#include <QHBoxLayout>
#include <QVBoxLayout>
#include <QPushButton>

#include "TaskManager.h"
#include "GronsfeldTask.h"
#include "RsaTask.h"
#include "ElgamalTask.h"
#include "DesTask.h"
#include "CicleTask.h"
#include "HuffmanTask.h"
#include "HashTask.h"
#include "GammaTask.h"

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
        wgtRight = new QWidget();

        this->setLayout(hLyt);
        hLyt->setSpacing(10);
        vLytMenu->setSpacing(10);
        vLytMenu->setAlignment(Qt::Alignment::enum_type::AlignTop);
        hLyt->addLayout(vLytMenu, 1);
        hLyt->addWidget(wgtRight, 5);

        tm = (new TaskManager(vLytMenu, wgtRight))
                ->add("Защита информации")
                ->add(new GronsfeldTask())
                ->add(new RsaTask())
                ->add(new ElgamalTask())
                ->add(new DesTask())
                ->add(new CicleTask())
                ->add(new HuffmanTask())
                ->add(new HashTask())
                ->add(new GammaTask())
                ->start();

        resize(1000, 500);
    }

    ~Window() {
        delete hLyt;
        delete vLytMenu;
        delete wgtRight;
        delete tm;
    }

};