#pragma once

#include <QWidget>
#include <QHBoxLayout>
#include <QVBoxLayout>
#include <QPushButton>

#include "TaskManager.h"
#include "GronsfeldTask.h"
#include "RSATask.h"
#include "ElgamalTask.h"
#include "DESTask.h"
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
        hLyt->addWidget(wgtRight, 6);

        tm = (new TaskManager(vLytMenu, wgtRight))
                ->add(new GronsfeldTask())
                ->add(new RSATask())
                ->add(new ElgamalTask())
                ->add(new DESTask())
                ->add(new CicleTask())
                ->add(new HuffmanTask())
                ->add(new HashTask())
                ->add(new GammaTask())
                ->start();

        resize(700, 320);
    }

    ~Window() {
        delete hLyt;
        delete vLytMenu;
        delete wgtRight;
        delete tm;
    }

};