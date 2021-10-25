#include "Huffman.h"

#include <QHash>
#include <QBitArray>

#include <iostream>

Huffman::Node* Huffman::node(QChar ch, int freq, Node* left, Node* right) {
    Node* node = new Node;
    node->ch = ch;
    node->freq = freq;
    node->left = left;
    node->right = right;
    return node;
}

Huffman::Node* Huffman::tree(QHash<QChar, int> freq) {
    priority_queue<Node*, vector<Node*>, Node> pq;
    for (auto pair = freq.begin(); pair != freq.end(); ++pair) {
        pq.push(node(pair.key(), pair.value(), nullptr, nullptr));
    }
    while (pq.size() != 1) {
        Node *left = pq.top(); pq.pop();
        Node *right = pq.top();	pq.pop();
        int sum = left->freq + right->freq;
        pq.push(node('\0', sum, left, right));
    }
    return pq.top();
}

bool Huffman::Node::operator()(Node* l, Node* r) {
    return l->freq > r->freq;
}

void Huffman::encode(Node* root, QString text, QHash<QChar, QString> &huffmanCode) {
    if (root == nullptr) {
        return;
    }
    if (!root->left && !root->right) {
        huffmanCode[root->ch] = text;
    }
    encode(root->left, text + "0", huffmanCode);
    encode(root->right, text + "1", huffmanCode);
}

QString Huffman::decode(QString text, Node* root) {
    QString str = "";
    int index = -1;
    while (index < (int)text.size() - 2) {
        str += decode(root, index, text);
    }
    return str;
}

QChar Huffman::decode(Node* root, int &index, QString str) {
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

QTextStream& Huffman::operator >> (QTextStream &in, Encoder& encoder) {
    encoder.text = in.readAll();
    return in;
}

QTextStream& Huffman::operator << (QTextStream &out, const Encoder& encoder) {
    QHash<QChar, int> freq;
    for (QChar ch: encoder.text) {
        freq[ch]++;
    }
    Node* root = tree(freq);
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

QTextStream& Huffman::operator >> (QTextStream &in, Decoder& decoder) {
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

    decoder.text = decode(packed, tree(freq));

    return in;
}

QTextStream& Huffman::operator << (QTextStream &out, const Decoder& decoder) {
    out << decoder.text;
    return out;
}
