#include "Slider.h"

#include <QLabel>
#include <QSlider>
#include <QLineEdit>
#include <QHBoxLayout>

#include <Func.h>

Slider::Slider(int from, int to) {
    layout = new QHBoxLayout;
    lineEdit = new QLineEdit(Func::stringOf(from));
    lblFrom = new QLabel(Func::stringOf(from));
    lblTo = new QLabel(Func::stringOf(to));
    slider = new QSlider(Qt::Horizontal);

    setLayout(layout);
    layout->setMargin(0);

    slider->setRange(from, to);
    layout->addWidget(lineEdit, 1);
    layout->addWidget(lblFrom, 1, Qt::AlignRight);
    layout->addWidget(slider, 7);
    layout->addWidget(lblTo, 1);

    connect(slider, SIGNAL(valueChanged(int)), SIGNAL(valueChanged(int)));
    connect(slider, SIGNAL(valueChanged(int)), SLOT(slotValueChanged(int)));
    connect(lineEdit, SIGNAL(textChanged(const QString &)), SLOT(slotTextChanged(const QString &)));
}

Slider::Slider(int from, int to, int def) : Slider(from, to) {
    slider->setValue(def);
    lineEdit->setText(Func::stringOf(def));
}

Slider::~Slider() {
    delete layout;
}

void Slider::slotValueChanged(int value) {
    Func::doIt([&]() -> void {
        lineEdit->setText(Func::stringOf(value));
    });
}

void Slider::slotTextChanged(const QString &text) {
    Func::doIt([&]() -> void {
        slider->setValue(text.toInt());
    });
}
