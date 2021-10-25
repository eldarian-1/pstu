#include "Huffman.h"

#include <QHash>
#include <QBitArray>

#include <iostream>
using namespace std;

/**HuffmanNode * HuffmanNode::get(char ch, int freq, HuffmanNode* left, HuffmanNode* right) {
    HuffmanNode* node = new HuffmanNode();
    node->ch = ch;
    node->freq = freq;
    node->left = left;
    node->right = right;
    return node;
}

bool HuffmanNode::operator()(HuffmanNode* l, HuffmanNode* r) {
    return l->freq > r->freq;
}

void encode(HuffmanNode* root, QString str, QHash<char, QString> &huffmanCode) {
    if (root == nullptr) {
        return;
    }
    if (!root->left && !root->right) {
        huffmanCode[root->ch] = str;
    }
    encode(root->left, str + "0", huffmanCode);
    encode(root->right, str + "1", huffmanCode);
}

char decode(HuffmanNode* root, int &index, QString str) {
    if (root == nullptr) {
        return '\0';
    }
    if (!root->left && !root->right) {
        return root->ch;
    }
    index++;
    if (str[index] =='0') {
        decode(root->left, index, str);
    } else {
        decode(root->right, index, str);
    }
}

QBitArray strToBit(QString text) {
    int n = text.size();
    QBitArray result(n);
    for(int i = 0; i < n; ++i) {
        result.setBit(i, text[i] == "1");
    }
    return result;
}

QString bitToStr(QBitArray bits) {
    int n = bits.size();
    QString result;
    for(int i = 0; i < n; ++i) {
        result += bits.at(i) ? "1" : "0";
    }
    return result;
}

QDataStream& operator >> (QDataStream &in, HuffmanEncoder& encoder) {
    in >> encoder.ba;
    cout << encoder.ba.toStdString() << endl;
    return in;
}

QDataStream& operator << (QDataStream &out, const HuffmanEncoder& encoder) {
    QHash<char, int> freq;
    for (char ch: encoder.ba) {
        freq[ch]++;
    }
    out << freq.size();
    for (auto pair = freq.begin(); pair != freq.end(); ++pair) {
        out << pair.key() << pair.value();
    }

    priority_queue<HuffmanNode*, vector<HuffmanNode*>, HuffmanNode> pq;
    for (auto pair = freq.begin(); pair != freq.end(); ++pair) {
        pq.push(HuffmanNode::get(pair.key(), pair.value(), nullptr, nullptr));
    }
    while (pq.size() != 1) {
        HuffmanNode *left = pq.top(); pq.pop();
        HuffmanNode *right = pq.top();	pq.pop();
        int sum = left->freq + right->freq;
        pq.push(HuffmanNode::get('\0', sum, left, right));
    }

    HuffmanNode* root = pq.top();
    QHash<char, QString> huffmanCode;
    encode(root, "", huffmanCode);
    out << huffmanCode.size();
    for (auto pair = huffmanCode.begin(); pair != huffmanCode.end(); ++pair) {
        out << pair.key() << pair.value();
    }

    QString packed;
    for (char ch: encoder.ba) {
        packed += huffmanCode[ch];
    }
    out << strToBit(packed);

    return out;
}

QDataStream& operator >> (QDataStream &in, HuffmanDecoder& decoder) {
    int n;
    in >> n;
    QHash<char, int> freq;
    for (int i = 0; i < n; ++i) {
        byte key;
        int value;
        in >> key >> value;
        freq[(char)key] = value;
    }

    priority_queue<HuffmanNode*, vector<HuffmanNode*>, HuffmanNode> pq;
    for (auto pair = freq.begin(); pair != freq.end(); ++pair) {
        pq.push(HuffmanNode::get(pair.key(), pair.value(), nullptr, nullptr));
    }
    while (pq.size() != 1) {
        HuffmanNode *left = pq.top(); pq.pop();
        HuffmanNode *right = pq.top();	pq.pop();
        int sum = left->freq + right->freq;
        pq.push(HuffmanNode::get('\0', sum, left, right));
    }
    HuffmanNode* root = pq.top();

    in >> n;
    QHash<char, QString> huffmanCode;
    for (int i = 0; i < n; ++i) {
        byte key;
        QString value;
        in >> key >> value;
        huffmanCode[(char)key] = value;
    }

    QBitArray bits;
    in >> bits;
    decoder.ba = decoder.decode(bitToStr(bits), root).toUtf8();

    return in;
}

QString HuffmanDecoder::decode(QString text, HuffmanNode* root) {
    QString str = "";
    int index = -1;
    while (index < (int)text.size() - 2) {
        str += ::decode(root, index, text);
    }
    return str;
}

QDataStream& operator << (QDataStream &out, const HuffmanDecoder& decoder) {
    out << decoder.ba;
    cout << decoder.ba.toStdString() << endl;
    return out;
}*/
