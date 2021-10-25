#pragma once

#include <QHash>
#include <QString>
#include <QTextStream>

#include <vector>
#include <queue>
using namespace std;

namespace Huffman {
    struct Node {
        QChar ch;
        int freq;
        Node *left, *right;

        bool operator()(Node *l, Node *r);

    };

    Node *node(QChar ch, int freq, Node *left, Node *right);
    Node *tree(QHash<QChar, int> freq);

    void encode(Node *root, QString text, QHash<QChar, QString> &huffmanCode);
    QString decode(QString text, Node *root);
    QChar decode(Node *root, int &index, QString str);

    class Encoder {
    private:
        QString text;
    public:
        friend QTextStream &operator>>(QTextStream &in, Encoder &encoder);
        friend QTextStream &operator<<(QTextStream &out, const Encoder &encoder);

    };

    class Decoder {
    private:
        QString text;
    public:
        friend QTextStream &operator>>(QTextStream &in, Decoder &decoder);
        friend QTextStream &operator<<(QTextStream &out, const Decoder &decoder);
    };

}
