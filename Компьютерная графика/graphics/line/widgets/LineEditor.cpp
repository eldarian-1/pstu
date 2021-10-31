#include "LineEditor.h"

#include <QColor>
#include <QLabel>
#include <QSlider>
#include <QPalette>
#include <QLineEdit>
#include <QPushButton>
#include <QGridLayout>
#include <QColorDialog>

#include "../Line.h"
#include "Slider.h"

LineEditor::LineEditor(Line *line) : line(line) {
    setWindowTitle("Настройка линии " + line->toString());
    setFixedSize(450, 200);

    lytMain = new QGridLayout();
    lytMain->setColumnStretch(2, 8);

    lblWeight = new QLabel("Толщина");
    lblColor = new QLabel("Цвет");
    lblA = new QLabel("A");
    lblB = new QLabel("B");
    lblC = new QLabel("C");
    lblAlpha = new QLabel("Угол");

    sldWeight = new Slider(1, 100);
    btnColor = new QPushButton;
    sldA = new Slider(-1000, 1000);
    sldB = new Slider(-1000, 1000);
    sldC = new Slider(-1000, 1000);
    sldAlpha = new Slider(0, 360);

    setLayout(lytMain);

    lytMain->addWidget(lblWeight, 0, 0, Qt::AlignRight);
    lytMain->addWidget(sldWeight, 0, 1, 1, 7);

    lytMain->addWidget(lblColor, 1, 0, Qt::AlignRight);
    lytMain->addWidget(btnColor, 1, 1, 1, 7);

    lytMain->addWidget(lblA, 2, 0, Qt::AlignRight);
    lytMain->addWidget(sldA, 2, 1, 1, 7);

    lytMain->addWidget(lblB, 3, 0, Qt::AlignRight);
    lytMain->addWidget(sldB, 3, 1, 1, 7);

    lytMain->addWidget(lblC, 4, 0, Qt::AlignRight);
    lytMain->addWidget(sldC, 4, 1, 1, 7);

    lytMain->addWidget(lblAlpha, 5, 0, Qt::AlignRight);
    lytMain->addWidget(sldAlpha, 5, 1, 1, 7);

    connect(sldWeight, SIGNAL(valueChanged(int)), SLOT(weightChanged(int)));
    connect(btnColor, SIGNAL(release()), SLOT(colorChanged()));
    connect(sldA, SIGNAL(valueChanged(int)), SLOT(aChanged(int)));
    connect(sldB, SIGNAL(valueChanged(int)), SLOT(bChanged(int)));
    connect(sldC, SIGNAL(valueChanged(int)), SLOT(cChanged(int)));
    connect(sldAlpha, SIGNAL(valueChanged(int)), SLOT(alphaChanged(int)));
}

LineEditor::~LineEditor() {
    delete lytMain;
}

void LineEditor::weightChanged(int value) {
    line->setWeight(value);
}

void LineEditor::colorChanged() {
    QColor color = QColorDialog(Line::active->getColor()).getColor();
    btnColor->setPalette(QPalette(color));
    line->setColor(color);
}

void LineEditor::aChanged(int value) {
    line->A(value);
}

void LineEditor::bChanged(int value) {
    line->B(value);
}

void LineEditor::cChanged(int value) {
    line->C(value);
}

void LineEditor::alphaChanged(int value) {
    line->A(value);
}
