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
    QGridLayout *lytMain;

    QLabel *lblWeight;
    QLabel *lblColor;
    QLabel *lblA;
    QLabel *lblB;
    QLabel *lblC;

    Slider *sldWeight;
    QPushButton *btnColor;
    QLineEdit *leA;
    QLineEdit *leB;
    QLineEdit *leC;

    Line* line = nullptr;

public:
    LineEditor(Line *line);
    ~LineEditor();

protected:
    void closeEvent(QCloseEvent *event) override;

private slots:
    void weightChanged(int value);
    void colorChanged();
    void colorChanged(QColor color);
    void aChanged(const QString &value);
    void bChanged(const QString &value);
    void cChanged(const QString &value);

signals:
    void closed();

};
