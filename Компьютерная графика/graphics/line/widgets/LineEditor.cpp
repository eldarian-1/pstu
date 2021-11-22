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
#include "../Mode.h"
#include "../Canvas.h"

#include <Func.h>
#include <widgets/Slider.h>

bool LineEditor::mutex = false;

LineEditor::LineEditor(Line *line) : QWidget(), line(line), original(new Line(*line)) {
    setTitle();
    setFixedSize(450, 100);

    lytMain = new QGridLayout();
    lytMain->setColumnStretch(2, 8);

    lblWeight = new QLabel("Толщина");
    lblRotate = new QLabel("Вращение");
    lblColor = new QLabel("Цвет");
    lblA = new QLabel("A");
    lblB = new QLabel("B");
    lblC = new QLabel("C");

    sldWeight = new Slider(1, 100, line->getWeight());
    sldRotate = new Slider(0, 360, line->getAngle());
    btnColor = new QPushButton;
    leA = new QLineEdit(Func::stringOf(line->A()));
    leB = new QLineEdit(Func::stringOf(line->B()));
    leC = new QLineEdit(Func::stringOf(line->C()));

    setLayout(lytMain);
    colorChanged(line->getColor());

    lytMain->addWidget(lblWeight, 0, 0, Qt::AlignRight);
    lytMain->addWidget(sldWeight, 0, 1, 1, 7);

    lytMain->addWidget(lblRotate, 1, 0, Qt::AlignRight);
    lytMain->addWidget(sldRotate, 1, 1, 1, 7);

    lytMain->addWidget(lblColor, 2, 0, Qt::AlignRight);
    lytMain->addWidget(btnColor, 2, 1, 1, 7);

    lytMain->addWidget(lblA, 3, 0, Qt::AlignRight);
    lytMain->addWidget(leA, 3, 1);

    lytMain->addWidget(lblB, 3, 2, Qt::AlignRight);
    lytMain->addWidget(leB, 3, 3);

    lytMain->addWidget(lblC, 3, 4, Qt::AlignRight);
    lytMain->addWidget(leC, 3, 5);

    connect(sldWeight, SIGNAL(valueChanged(int)), SLOT(weightChanged(int)));
    connect(sldRotate, SIGNAL(valueChanged(int)), SLOT(angleChanged(int)));
    connect(btnColor, SIGNAL(released()), SLOT(colorChanged()));
    connect(leA, SIGNAL(textChanged(const QString &)), SLOT(aChanged(const QString &)));
    connect(leB, SIGNAL(textChanged(const QString &)), SLOT(bChanged(const QString &)));
    connect(leC, SIGNAL(textChanged(const QString &)), SLOT(cChanged(const QString &)));

    show();
}

LineEditor::~LineEditor() {
    delete lytMain;
    delete original;
}

void LineEditor::closeEvent(QCloseEvent *event) {
    emit closed();
}

void LineEditor::weightChanged(int value) {
    line->setWeight(value);
}

void LineEditor::angleChanged(int value) {
    Line temp = original->forAngle(value);
    line->rebuild(temp.top(), temp.bottom());
    lineChanged();
    Mode::canvas->setStatus(line->toString());
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

void LineEditor::angleChanged() {
    Func::doIt([&](){
        delete original;
        original = new Line(*line);
        //sldRotate->setValue(line->getAngle());
        setTitle();
    }, mutex);
}

void LineEditor::setTitle() {
    setWindowTitle("Настройка линии " + line->toString());
}
