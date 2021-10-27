#pragma once

#include <QObject>

#include "Task.h"

class QLabel;
class QLineEdit;
class QTextEdit;
class QPushButton;
class QVBoxLayout;

class CicleTask: public QObject, public Task {
Q_OBJECT

private:
    QVBoxLayout *lytMain;
    QLabel *lblName;
    QLabel *lblSource;
    QLineEdit *leSource;
    QLabel *lblReceived;
    QTextEdit *teTarget;
    QLabel *lblTarget;
    QPushButton *btnCorrect;

public:
    CicleTask(): Task("Метод циклических кодов") {}

    void initWidget(QWidget *wgt) override;

    void run() const override { }

private slots:
    void sourceChanged(const QString &text);
    void targetChanged();
    void correctReleased();

private:
    static QBitArray stringToBits(const QString &text);
    static QString bitsToString(const QBitArray &bits);
    static QString bitsAsString(const QBitArray &&bits);
    static QBitArray stringAsBits(const QString &text);
    static QBitArray correct(const QBitArray &&bits);

};
