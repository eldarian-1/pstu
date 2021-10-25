#pragma once

#include <QHash>
#include <QString>
#include <QTextStream>

#include <vector>
#include <queue>
using namespace std;

struct HuffmanNode {
    QChar ch;
    int freq;
    HuffmanNode *left, *right;

    static HuffmanNode* node(QChar ch, int freq, HuffmanNode* left, HuffmanNode* right);
    static HuffmanNode* tree(QHash<QChar, int> freq);

    bool operator()(HuffmanNode* l, HuffmanNode* r);

};

void encode(HuffmanNode* root, QString str, QHash<QChar, QString> &huffmanCode);
QChar decode(HuffmanNode* root, int &index, QString str);

class HuffmanEncoder {
private:
    QString text;

public:
    friend QTextStream& operator >> (QTextStream &in, HuffmanEncoder& encoder);
    friend QTextStream& operator << (QTextStream &out, const HuffmanEncoder& encoder);

};

class HuffmanDecoder {
private:
    QString text;

    QString decode(QString text, HuffmanNode* root);

public:
    friend QTextStream& operator >> (QTextStream &in, HuffmanDecoder& decoder);
    friend QTextStream& operator << (QTextStream &out, const HuffmanDecoder& decoder);
};
