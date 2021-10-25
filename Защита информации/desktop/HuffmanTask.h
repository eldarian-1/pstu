#pragma once

#include <QWidget>
#include <QLabel>

#include "Task.h"

class QVBoxLayout;
class QHBoxLayout;
class QPushButton;

class HuffmanTask: public QObject, public Task {
Q_OBJECT

private:
    QVBoxLayout *lytMain;
    QHBoxLayout *lytPackHuff;
    QHBoxLayout *lytUnpackHuff;
    QHBoxLayout *lytPackArif;
    QHBoxLayout *lytUnpackArif;

    QLabel *lblName;
    QLabel *lblPackHuff;
    QLabel *lblUnpackHuff;
    QLabel *lblPackArif;
    QLabel *lblUnpackArif;

    QPushButton *btnPackHuff;
    QPushButton *btnUnpackHuff;
    QPushButton *btnPackArif;
    QPushButton *btnUnpackArif;

public:
    HuffmanTask(): Task("Алгоритм Хаффмана") {}
    void initWidget(QWidget *wgt) override;

private slots:
    void packHuff();
    void unpackHuff();
    void packArif();
    void unpackArif();

private:
    template<class TIn, class TOut>
    void doAnything(QLabel *lbl, void (*fun)(TIn&, TOut&));

};
