#include "Huffman.h"

#include <QHash>
#include <QBitArray>

#include <iostream>

HuffmanNode * HuffmanNode::node(QChar ch, int freq, HuffmanNode* left, HuffmanNode* right) {
    HuffmanNode* node = new HuffmanNode();
    node->ch = ch;
    node->freq = freq;
    node->left = left;
    node->right = right;
    return node;
}

HuffmanNode* HuffmanNode::tree(QHash<QChar, int> freq) {
    priority_queue<HuffmanNode*, vector<HuffmanNode*>, HuffmanNode> pq;
    for (auto pair = freq.begin(); pair != freq.end(); ++pair) {
        pq.push(node(pair.key(), pair.value(), nullptr, nullptr));
    }
    while (pq.size() != 1) {
        HuffmanNode *left = pq.top(); pq.pop();
        HuffmanNode *right = pq.top();	pq.pop();
        int sum = left->freq + right->freq;
        pq.push(node('\0', sum, left, right));
    }
    return pq.top();
}

bool HuffmanNode::operator()(HuffmanNode* l, HuffmanNode* r) {
    return l->freq > r->freq;
}

void encode(HuffmanNode* root, QString str, QHash<QChar, QString> &huffmanCode) {
    if (root == nullptr) {
        return;
    }
    if (!root->left && !root->right) {
        huffmanCode[root->ch] = str;
    }
    encode(root->left, str + "0", huffmanCode);
    encode(root->right, str + "1", huffmanCode);
}

QChar decode(HuffmanNode* root, int &index, QString str) {
    if (root == nullptr) {
        return '\0';
    }
    if (!root->left && !root->right) {
        return root->ch;
    }
    index++;
    if (str[index] == '0') {
        return decode(root->left, index, str);
    } else {
        return decode(root->right, index, str);
    }
}

QTextStream& operator >> (QTextStream &in, HuffmanEncoder& encoder) {
    encoder.text = in.readAll();
    return in;
}

QTextStream& operator << (QTextStream &out, const HuffmanEncoder& encoder) {
    QHash<QChar, int> freq;
    for (QChar ch: encoder.text) {
        freq[ch]++;
    }
    HuffmanNode* root = HuffmanNode::tree(freq);
    QHash<QChar, QString> huffmanCode;
    encode(root, "", huffmanCode);
    out << huffmanCode.size();
    for (auto pair = freq.begin(); pair != freq.end(); ++pair) {
        out << pair.key() << " " << pair.value() << " " << huffmanCode[pair.key()] << "\n";
    }

    for (QChar ch: encoder.text) {
        out << huffmanCode[ch];
    }

    return out;
}

QTextStream& operator >> (QTextStream &in, HuffmanDecoder& decoder) {
    int n;
    in >> n;
    QHash<QChar, int> freq;
    QHash<QChar, QString> huffmanCode;
    for (int i = 0; i < n; ++i) {
        QChar key, space, nl;
        int fq;
        QString code;
        in >> key >> space >> fq >> space >> code >> nl;
        freq[key] = fq;
        huffmanCode[key] = code;
    }

    QString packed;
    in >> packed;

    decoder.text = decoder.decode(packed, HuffmanNode::tree(freq));

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

QTextStream& operator << (QTextStream &out, const HuffmanDecoder& decoder) {
    out << decoder.text;
    return out;
}
