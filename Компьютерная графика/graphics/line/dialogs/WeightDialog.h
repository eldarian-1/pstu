#pragma once

#include <QDialog>

class QHBoxLayout;
class QSlider;
class QPushButton;

class WeightDialog : public QDialog {
Q_OBJECT

private:
    QHBoxLayout *lytWidth;
    QSlider *sldWidth;
    QPushButton *btnApply;

public:
    WeightDialog(int width);
    ~WeightDialog();
    int width();

};
