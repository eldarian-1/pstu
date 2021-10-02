#pragma once

#include <QDialog>

class QHBoxLayout;
class QLineEdit;
class QPushButton;

class WidthDialog : public QDialog {
Q_OBJECT
private:
    QHBoxLayout *lytWidth;
    QLineEdit *leWidth;
    QPushButton *btnApply;

public:
    WidthDialog(int width);
    ~WidthDialog();
    int width();
};