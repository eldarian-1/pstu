#include "WidthDialog.h"

#include <QHBoxLayout>
#include <QLineEdit>
#include <QPushButton>

#include <cstdlib>

WidthDialog::WidthDialog(int width) {
    lytWidth = new QHBoxLayout;
    leWidth = new QLineEdit(QString::number(width));
    btnApply = new QPushButton("Применить");
    setLayout(lytWidth);
    lytWidth->addWidget(leWidth);
    lytWidth->addWidget(btnApply);
    setWindowTitle("Редактирование толщины линии");

    connect(btnApply, SIGNAL(clicked()), SLOT(accept()));
}

WidthDialog::~WidthDialog() {
    delete lytWidth;
    delete leWidth;
    delete btnApply;
}

int WidthDialog::width() {
    return leWidth->text().toInt();
}
