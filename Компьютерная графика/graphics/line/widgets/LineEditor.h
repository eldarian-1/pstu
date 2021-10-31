#pragma once

#include <QWidget>
#include <QColor>

class Line;
class Slider;
class QLabel;
class QLineEdit;
class QGridLayout;
class QPushButton;

class LineEditor : public QWidget {
Q_OBJECT

private:
    QGridLayout *lytMain;

    QLabel *lblWeight;
    QLabel *lblColor;
    QLabel *lblA;
    QLabel *lblB;
    QLabel *lblC;
    QLabel *lblAlpha;

    Slider *sldWeight;
    QPushButton *btnColor;
    Slider *sldA;
    Slider *sldB;
    Slider *sldC;
    Slider *sldAlpha;

    Line* line = nullptr;

public:
    LineEditor(Line *line, QWidget *wgt = nullptr);
    ~LineEditor();

private slots:
    void weightChanged(int value);
    void colorChanged();
    void colorChanged(QColor color);
    void aChanged(int value);
    void bChanged(int value);
    void cChanged(int value);
    void alphaChanged(int value);

};
