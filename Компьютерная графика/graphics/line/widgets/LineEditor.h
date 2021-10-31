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

    Line* line;

public:
    LineEditor(Line *line);
    ~LineEditor();

private slots:
    void weightChanged(int value);
    void colorChanged();
    void aChanged(int value);
    void bChanged(int value);
    void cChanged(int value);
    void alphaChanged(int value);

};
