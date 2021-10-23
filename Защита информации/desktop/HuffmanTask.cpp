#include "HuffmanTask.h"

#include <QLabel>
#include <QLineEdit>
#include <QJsonObject>
#include <QHBoxLayout>
#include <QPushButton>
#include <QFileDialog>

void HuffmanTask::initWidget(QWidget *wgt) {
    lytMain = new QVBoxLayout;
    lytPackHuff = new QHBoxLayout;
    lytUnpackHuff = new QHBoxLayout;
    lytPackArif = new QHBoxLayout;
    lytUnpackArif = new QHBoxLayout;

    lblName = new QLabel("Алгоритм Хаффмана + Арифметическое кодирование");
    lblPackHuff = new QLabel("Упаковать Хаффманом");
    lblUnpackHuff = new QLabel("Распаковать Хаффманом");
    lblPackArif = new QLabel("Упаковать Арифметикой");
    lblUnpackArif = new QLabel("Распаковать Арифметикой");

    btnPackHuff = new QPushButton("Упаковать Хаффманом");
    btnUnpackHuff = new QPushButton("Распаковать Хаффманом");
    btnPackArif = new QPushButton("Упаковать Арифметикой");
    btnUnpackArif = new QPushButton("Распаковать Арифметикой");

    wgt->setLayout(lytMain);
    lytMain->addWidget(lblName);
    lytMain->addLayout(lytPackHuff);
    lytMain->addLayout(lytPackArif);
    lytMain->addLayout(lytUnpackArif);
    lytMain->addLayout(lytUnpackHuff);

    lytPackHuff->addWidget(lblPackHuff, 4);
    lytPackHuff->addWidget(btnPackHuff, 1);
    lytPackArif->addWidget(lblPackArif, 4);
    lytPackArif->addWidget(btnPackArif, 1);
    lytUnpackHuff->addWidget(lblUnpackHuff, 4);
    lytUnpackHuff->addWidget(btnUnpackHuff, 1);
    lytUnpackArif->addWidget(lblUnpackArif, 4);
    lytUnpackArif->addWidget(btnUnpackArif, 1);

    lytMain->setAlignment(Qt::Alignment::enum_type::AlignTop);

    connect(btnPackHuff, SIGNAL(released()), this, SLOT(packHuff()));
    connect(btnUnpackHuff, SIGNAL(released()), this, SLOT(unpackHuff()));
    connect(btnPackArif, SIGNAL(released()), this, SLOT(packArif()));
    connect(btnUnpackArif, SIGNAL(released()), this, SLOT(unpackArif()));
}

void HuffmanTask::packHuff() {

}

void HuffmanTask::unpackHuff() {

}

void HuffmanTask::packArif() {

}

void HuffmanTask::unpackArif() {

}
