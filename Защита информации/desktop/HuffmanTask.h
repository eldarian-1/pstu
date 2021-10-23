#pragma once

#include <QWidget>
#include <QLabel>

#include "Task.h"

#include <iostream>
#include <string>
#include <queue>
#include <unordered_map>
using namespace std;

/*struct Node {
    char ch;
    int freq;
    Node *left, *right;

    static Node * get(char ch, int freq, Node* left, Node* right) {
        Node* node = new Node();
        node->ch = ch;
        node->freq = freq;
        node->left = left;
        node->right = right;
        return node;
    }

    bool operator()(Node* l, Node* r) {
        return l->freq > r->freq;
    }
};

void encode(Node* root, string str, unordered_map<char, string> &huffmanCode) {
    if (root == nullptr) {
        return;
    }

    if (!root->left && !root->right) {
        huffmanCode[root->ch] = str;
    }

    encode(root->left, str + "0", huffmanCode);
    encode(root->right, str + "1", huffmanCode);
}

string decode(Node* root, int &index, string str, string out = "") {
    if (root == nullptr) {
        return "";
    }

    if (!root->left && !root->right) {
        return (out + root->ch);
    }

    index++;

    if (str[index] == '0') {
        return decode(root->left, index, str);
    } else {
        return decode(root->right, index, str);
    }
}

void buildHuffmanTree(string text) {
    unordered_map<char, int> freq;
    for (char ch: text) {
        freq[ch]++;
    }

    priority_queue<Node*, vector<Node*>, Node> pq;

    for (auto pair: freq) {
        pq.push(Node::get(pair.first, pair.second, nullptr, nullptr));
    }

    while (pq.size() != 1) {
        Node *left = pq.top(); pq.pop();
        Node *right = pq.top();	pq.pop();

        int sum = left->freq + right->freq;
        pq.push(Node::get('\0', sum, left, right));
    }

    Node* root = pq.top();

    unordered_map<char, string> huffmanCode;
    encode(root, "", huffmanCode);

    cout << "Huffman Codes are :\n" << '\n';
    for (auto pair: huffmanCode) {
        cout << pair.first << " " << pair.second << '\n';
    }

    cout << "\nOriginal string was :\n" << text << '\n';

    string str = "";
    for (char ch: text) {
        str += huffmanCode[ch];
    }

    cout << "\nEncoded string is :\n" << str << '\n';

    int index = -1;
    cout << "\nDecoded string is: \n";
    while (index < (int)str.size() - 2) {
        decode(root, index, str);
    }
}*/

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

public slots:
    void packHuff();
    void unpackHuff();
    void packArif();
    void unpackArif();

};