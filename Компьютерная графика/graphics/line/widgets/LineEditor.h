#pragma once

#include <QColor>
#include <QWidget>

class Line;
class Slider;
class QLabel;
class QLineEdit;
class QGridLayout;
class QPushButton;

class LineEditor : public QWidget {
Q_OBJECT

private:
    static bool mutex;

    QGridLayout *lytMain;

    QLabel *lblWeight;
    QLabel *lblRotate;
    QLabel *lblColor;
    QLabel *lblA;
    QLabel *lblB;
    QLabel *lblC;

    Slider *sldWeight;
    Slider *sldRotate;
    QPushButton *btnColor;
    QLineEdit *leA;
    QLineEdit *leB;
    QLineEdit *leC;

    Line* line = nullptr;
    Line* original;

public:
    LineEditor(Line *line);
    ~LineEditor();

    void lineChanged();
    void angleChanged();

protected:
    void closeEvent(QCloseEvent *event) override;

private slots:
    void weightChanged(int value);
    void angleChanged(int value);
    void colorChanged();
    void colorChanged(QColor color);
    void aChanged(const QString &value);
    void bChanged(const QString &value);
    void cChanged(const QString &value);

signals:
    void closed();

private:
    void setTitle();

};
