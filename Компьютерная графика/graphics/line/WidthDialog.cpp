#include "WidthDialog.h"

#include <QHBoxLayout>
#include <QSlider>
#include <QPushButton>

WidthDialog::WidthDialog(int width) {
    lytWidth = new QHBoxLayout;
    sldWidth = new QSlider();
    btnApply = new QPushButton("Применить");
    sldWidth->setMinimum(1);
    sldWidth->setMaximum(100);
    sldWidth->setOrientation(Qt::Horizontal);
    sldWidth->setTickInterval(10);
    sldWidth->setValue(width);
    sldWidth->setTickPosition(QSlider::TicksAbove);
    setLayout(lytWidth);
    lytWidth->addWidget(sldWidth);
    lytWidth->addWidget(btnApply);
    setFixedWidth(500);
    setWindowTitle("Редактирование толщины линии");
    connect(btnApply, SIGNAL(clicked()), SLOT(accept()));
}

WidthDialog::~WidthDialog() {
    delete lytWidth;
    delete sldWidth;
    delete btnApply;
}

int WidthDialog::width() {
    return sldWidth->value();
}
