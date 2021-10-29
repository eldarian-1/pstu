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
    QTextEdit *teSource;
    QLabel *lblEncoded;
    QTextEdit *teEncoded;
    QLabel *lblDecoded;
    QTextEdit *teDecoded;
    QLineEdit *leDecoded;
    QPushButton *btnCorrect;

public:
    CicleTask(): Task("Метод циклических кодов") {}

    void initWidget(QWidget *wgt) override;

    void run() const override { }

private slots:
    void sourceChanged(const QString &text);
    void encodedChanged();
    void correctReleased();

private:
    static QBitArray stringToBits(const QString &text);
    static QString bitsToString(const QBitArray &bits);
    static QString bitsAsString(const QBitArray &bits);
    static QBitArray stringAsBits(const QString &text);
    static QBitArray correct(const QBitArray &bits);

    static QBitArray encode(const QBitArray &bits);
    static QBitArray decode(const QBitArray &bits);

    static QVector<QBitArray> divide(const QBitArray &bits, int denominator);
    static QBitArray sum(const QVector<QBitArray> &bits, int denominator);
    static QBitArray bit4to7(const QBitArray &bits);
    static QBitArray bit7to4(const QBitArray &bits);

};
