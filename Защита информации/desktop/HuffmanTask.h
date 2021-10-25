#pragma once

#include <QWidget>
#include <QLabel>

#include "Task.h"

#include <iostream>
#include <string>
#include <queue>
using namespace std;

class QDataStream;
class QTextStream;
class QVBoxLayout;
class QHBoxLayout;
class QPushButton;

struct HuffmanNode {
    QChar ch;
    int freq;
    HuffmanNode *left, *right;

    static HuffmanNode * get(QChar ch, int freq, HuffmanNode* left, HuffmanNode* right);
    bool operator()(HuffmanNode* l, HuffmanNode* r);

};

void encode(HuffmanNode* root, QString str, QHash<QChar, QString> &huffmanCode);
QString  decode(HuffmanNode* root, int &index, QString str);
QBitArray strToBit(QString text);
QString bitToStr(QBitArray bits);

class HuffmanAlgorithm {
private:
    QHash<QChar, int> freq;
    priority_queue<HuffmanNode*, vector<HuffmanNode*>, HuffmanNode> pq;
    HuffmanNode* root;
    QHash<QChar, QString> huffmanCode;
    QString text;

public:
    HuffmanAlgorithm() {}
    HuffmanAlgorithm(QString text);
    void fillPq();

    QString decode(QString text);

    friend QDataStream& operator >> (QDataStream &in, HuffmanAlgorithm& algorithm);
    friend QDataStream& operator << (QDataStream &out, const HuffmanAlgorithm& algorithm);
    friend QTextStream& operator << (QTextStream &out, const HuffmanAlgorithm& algorithm);

};

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
