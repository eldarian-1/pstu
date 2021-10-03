#pragma once

#include <QDialog>

class QHBoxLayout;
class QSlider;
class QPushButton;

class WidthDialog : public QDialog {
Q_OBJECT

private:
    QHBoxLayout *lytWidth;
    QSlider *sldWidth;
    QPushButton *btnApply;

public:
    WidthDialog(int width);
    ~WidthDialog();
    int width();

};
