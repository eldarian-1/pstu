#pragma once

#include <QWidget>

class Line;
class QLabel;
class QLineEdit;
class QPushButton;
class QVBoxLayout;
class QHBoxLayout;

class LineProjector : public QWidget {
Q_OBJECT

private:
    Line *original, *current;

    QVBoxLayout *lytMain;
    QHBoxLayout *lytP;
    QHBoxLayout *lytQ;
    QLabel *lblP;
    QLabel *lblQ;
    QLineEdit *leP;
    QLineEdit *leQ;
    QPushButton *btnApply;

protected:
    void closeEvent(QCloseEvent *event) override;

public:
    LineProjector(Line *line);

private slots:
    void apply();

signals:
    void closed();

};
