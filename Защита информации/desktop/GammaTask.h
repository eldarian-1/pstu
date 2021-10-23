#pragma once

#include <QWidget>

#include "Task.h"

class QVBoxLayout;
class QHBoxLayout;
class QLabel;
class QLineEdit;
class QPushButton;
class QTextEdit;

struct u48 {
    ushort s[3];
};

void getBlocks(QString text, u48 *&out, int &n);

QString getString(u48 *&in, const int &n);

class GammaTask: public QWidget, public Task {
Q_OBJECT

private:
    QVBoxLayout *lytMain;
    QHBoxLayout *lytKey;
    QHBoxLayout *lytIn;
    QLabel *lblName;
    QLabel *lblKey;
    QLabel *lblIn;
    QLineEdit *leKey;
    QLineEdit *leIn;
    QPushButton *btn;
    QLineEdit *leResult;
    QTextEdit *txtResult;

public:
    GammaTask() : Task("Метод однократного гаммирования") {}

    void initWidget(QWidget *wgt) override;

    void run() const override {}

private slots:
    void generate();

};