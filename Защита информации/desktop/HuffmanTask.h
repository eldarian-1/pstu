#pragma once

#include <QWidget>
#include <QLabel>

#include "Task.h"

#include <iostream>
#include <string>
#include <queue>
#include <unordered_map>
using namespace std;

class QVBoxLayout;
class QHBoxLayout;
class QPushButton;

struct HuffmanNode {
    char ch;
    int freq;
    HuffmanNode *left, *right;

    static HuffmanNode * get(char ch, int freq, HuffmanNode* left, HuffmanNode* right);
    bool operator()(HuffmanNode* l, HuffmanNode* r);

};

void encode(HuffmanNode* root, string str, unordered_map<char, string> &huffmanCode);
string decode(HuffmanNode* root, int &index, string str, string out = "");

class HuffmanAlgorithm {
private:
    unordered_map<char, int> freq;
    priority_queue<HuffmanNode*, vector<HuffmanNode*>, HuffmanNode> pq;
    HuffmanNode* root;
    unordered_map<char, string> huffmanCode;

public:
    HuffmanAlgorithm() {}
    HuffmanAlgorithm(string text);

    string encode(string text);
    string decode(string text);

    friend istream& operator << (istream& in, HuffmanAlgorithm& algorithm);
    friend ostream& operator >> (ostream& out, HuffmanAlgorithm& algorithm);

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

private:
    void doAnything(QLabel *lbl, QString (*)(QString));

private slots:
    void packHuff();
    void unpackHuff();
    void packArif();
    void unpackArif();

};