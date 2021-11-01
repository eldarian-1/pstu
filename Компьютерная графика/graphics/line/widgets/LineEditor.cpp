#include "LineEditor.h"

#include <QColor>
#include <QLabel>
#include <QSlider>
#include <QPalette>
#include <QLineEdit>
#include <QPushButton>
#include <QGridLayout>
#include <QColorDialog>

#include "../figures/Line.h"
#include "Slider.h"

#include <Func.h>

bool LineEditor::mutex = false;

LineEditor::LineEditor(Line *line) : QWidget(), line(line) {
    setTitle();
    setFixedSize(450, 100);

    lytMain = new QGridLayout();
    lytMain->setColumnStretch(2, 8);

    lblWeight = new QLabel("Толщина");
    lblColor = new QLabel("Цвет");
    lblA = new QLabel("A");
    lblB = new QLabel("B");
    lblC = new QLabel("C");

    sldWeight = new Slider(1, 100, line->getWeight());
    btnColor = new QPushButton;
    leA = new QLineEdit(Func::stringOf(line->A()));
    leB = new QLineEdit(Func::stringOf(line->B()));
    leC = new QLineEdit(Func::stringOf(line->C()));

    setLayout(lytMain);
    colorChanged(line->getColor());

    lytMain->addWidget(lblWeight, 0, 0, Qt::AlignRight);
    lytMain->addWidget(sldWeight, 0, 1, 1, 7);

    lytMain->addWidget(lblColor, 1, 0, Qt::AlignRight);
    lytMain->addWidget(btnColor, 1, 1, 1, 7);

    lytMain->addWidget(lblA, 2, 0, Qt::AlignRight);
    lytMain->addWidget(leA, 2, 1);

    lytMain->addWidget(lblB, 2, 2, Qt::AlignRight);
    lytMain->addWidget(leB, 2, 3);

    lytMain->addWidget(lblC, 2, 4, Qt::AlignRight);
    lytMain->addWidget(leC, 2, 5);

    connect(sldWeight, SIGNAL(valueChanged(int)), SLOT(weightChanged(int)));
    connect(btnColor, SIGNAL(released()), SLOT(colorChanged()));
    connect(leA, SIGNAL(textChanged(const QString &)), SLOT(aChanged(const QString &)));
    connect(leB, SIGNAL(textChanged(const QString &)), SLOT(bChanged(const QString &)));
    connect(leC, SIGNAL(textChanged(const QString &)), SLOT(cChanged(const QString &)));

    show();
}

LineEditor::~LineEditor() {
    delete lytMain;
}

void LineEditor::closeEvent(QCloseEvent *event) {
    emit closed();
}

void LineEditor::weightChanged(int value) {
    line->setWeight(value);
}

void LineEditor::colorChanged() {
    colorChanged(QColorDialog::getColor(line->getColor()));
}

void LineEditor::colorChanged(QColor color) {
    btnColor->setPalette(QPalette(color));
    line->setColor(color);
}

void LineEditor::aChanged(const QString &value) {
    Func::doIt([&]() {
        line->A(value.toInt());
        setTitle();
    }, mutex);
}

void LineEditor::bChanged(const QString &value) {
    Func::doIt([&]() {
        line->B(value.toInt());
        setTitle();
    }, mutex);
}

void LineEditor::cChanged(const QString &value) {
    Func::doIt([&]() {
        line->C(value.toInt());
        setTitle();
    }, mutex);
}

void LineEditor::lineChanged() {
    Func::doIt([&](){
        leA->setText(Func::stringOf(line->A()));
        leB->setText(Func::stringOf(line->B()));
        leC->setText(Func::stringOf(line->C()));
        setTitle();
    }, mutex);
}

void LineEditor::setTitle() {
    setWindowTitle("Настройка линии " + line->toString());
}
