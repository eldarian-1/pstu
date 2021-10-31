#include "Slider.h"

#include <QLabel>
#include <QSlider>
#include <QLineEdit>
#include <QHBoxLayout>

bool changed = false;

Slider::Slider(int from, int to) {
    layout = new QHBoxLayout;
    lineEdit = new QLineEdit(stringOf(from));
    lblFrom = new QLabel(stringOf(from));
    lblTo = new QLabel(stringOf(to));
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
    lineEdit->setText(stringOf(def));
}

Slider::~Slider() {
    delete layout;
}

void Slider::slotValueChanged(int value) {
    if(changed) {
        changed = false;
    } else {
        lineEdit->setText(stringOf(value));
        changed = true;
    }
}

void Slider::slotTextChanged(const QString &text) {
    if(changed) {
        changed = false;
    } else {
        slider->setValue(text.toInt());
        changed = true;
    }
}

QString Slider::stringOf(int value) {
    return QString::asprintf("%d", value);
}
