#pragma once

#include <QHash>
#include <QString>
#include <QDataStream>

#include <vector>
#include <queue>
using namespace std;

/*struct HuffmanNode {
    char ch;
    int freq;
    HuffmanNode *left, *right;

    static HuffmanNode * get(char ch, int freq, HuffmanNode* left, HuffmanNode* right);
    bool operator()(HuffmanNode* l, HuffmanNode* r);

};

void encode(HuffmanNode* root, QString str, QHash<char, QString> &huffmanCode);
char decode(HuffmanNode* root, int &index, QString str);
QBitArray strToBit(QString text);
QString bitToStr(QBitArray bits);

class HuffmanEncoder {
private:
    QByteArray ba;

public:
    friend QDataStream& operator >> (QDataStream &in, HuffmanEncoder& encoder);
    friend QDataStream& operator << (QDataStream &out, const HuffmanEncoder& encoder);

};

class HuffmanDecoder {
private:
    QByteArray ba;

    QString decode(QString text, HuffmanNode* root);

public:
    friend QDataStream& operator >> (QDataStream &in, HuffmanDecoder& decoder);
    friend QDataStream& operator << (QDataStream &out, const HuffmanDecoder& decoder);
};*/
