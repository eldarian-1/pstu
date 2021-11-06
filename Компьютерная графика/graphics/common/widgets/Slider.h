#pragma once

#include <QWidget>

class QLabel;
class QSlider;
class QLineEdit;
class QHBoxLayout;

class Slider : public QWidget {
Q_OBJECT

private:
    static bool mutex;

    QHBoxLayout* layout;
    QLineEdit* lineEdit;
    QLabel* lblFrom;
    QLabel* lblTo;
    QSlider* slider;

public:
    Slider(int from, int to);
    Slider(int from, int to, int def);
    ~Slider();

signals:
    void valueChanged(int value);

private slots:
    void slotValueChanged(int value);
    void slotTextChanged(const QString &text);

};
