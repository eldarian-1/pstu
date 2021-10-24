#include "HuffmanTask.h"

#include <QLabel>
#include <QLineEdit>
#include <QJsonObject>
#include <QHBoxLayout>
#include <QPushButton>
#include <QFileDialog>
#include <QMessageBox>

HuffmanNode * HuffmanNode::get(char ch, int freq, HuffmanNode* left, HuffmanNode* right) {
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

void encode(HuffmanNode* root, string str, unordered_map<char, string> &huffmanCode) {
    if (root == nullptr) {
        return;
    }

    if (!root->left && !root->right) {
        huffmanCode[root->ch] = str;
    }

    encode(root->left, str + "0", huffmanCode);
    encode(root->right, str + "1", huffmanCode);
}

string decode(HuffmanNode* root, int &index, string str, string out) {
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

HuffmanAlgorithm::HuffmanAlgorithm(string text) {
    for (char ch: text) {
        freq[ch]++;
    }
    for (auto pair: freq) {
        pq.push(HuffmanNode::get(pair.first, pair.second, nullptr, nullptr));
    }
    while (pq.size() != 1) {
        HuffmanNode *left = pq.top(); pq.pop();
        HuffmanNode *right = pq.top();	pq.pop();

        int sum = left->freq + right->freq;
        pq.push(HuffmanNode::get('\0', sum, left, right));
    }
    root = pq.top();
    ::encode(root, "", huffmanCode);

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
        ::decode(root, index, str);
    }
}

string HuffmanAlgorithm::encode(string text) {
    string str = "";
    for (char ch: text) {
        str += huffmanCode[ch];
    }
    return str;
}

string HuffmanAlgorithm::decode(string text) {
    string str = "";
    for (char ch: text) {
        str += huffmanCode[ch];
    }
    return str;
}

istream& operator << (istream& in, HuffmanAlgorithm& algorithm) {
    return in;
}

ostream& operator >> (ostream& out, HuffmanAlgorithm& algorithm) {
    return out;
}

void HuffmanTask::initWidget(QWidget *wgt) {
    lytMain = new QVBoxLayout;
    lytPackHuff = new QHBoxLayout;
    lytUnpackHuff = new QHBoxLayout;
    lytPackArif = new QHBoxLayout;
    lytUnpackArif = new QHBoxLayout;

    lblName = new QLabel("Алгоритм Хаффмана + Арифметическое кодирование");
    lblPackHuff = new QLabel("Упаковать Хаффманом");
    lblUnpackHuff = new QLabel("Распаковать Хаффманом");
    lblPackArif = new QLabel("Упаковать Арифметикой");
    lblUnpackArif = new QLabel("Распаковать Арифметикой");

    btnPackHuff = new QPushButton("Упаковать Хаффманом");
    btnUnpackHuff = new QPushButton("Распаковать Хаффманом");
    btnPackArif = new QPushButton("Упаковать Арифметикой");
    btnUnpackArif = new QPushButton("Распаковать Арифметикой");

    wgt->setLayout(lytMain);
    lytMain->addWidget(lblName);
    lytMain->addLayout(lytPackHuff);
    lytMain->addLayout(lytPackArif);
    lytMain->addLayout(lytUnpackArif);
    lytMain->addLayout(lytUnpackHuff);

    lytPackHuff->addWidget(lblPackHuff, 4);
    lytPackHuff->addWidget(btnPackHuff, 1);
    lytPackArif->addWidget(lblPackArif, 4);
    lytPackArif->addWidget(btnPackArif, 1);
    lytUnpackHuff->addWidget(lblUnpackHuff, 4);
    lytUnpackHuff->addWidget(btnUnpackHuff, 1);
    lytUnpackArif->addWidget(lblUnpackArif, 4);
    lytUnpackArif->addWidget(btnUnpackArif, 1);

    lytMain->setAlignment(Qt::Alignment::enum_type::AlignTop);

    connect(btnPackHuff, SIGNAL(released()), this, SLOT(packHuff()));
    connect(btnUnpackHuff, SIGNAL(released()), this, SLOT(unpackHuff()));
    connect(btnPackArif, SIGNAL(released()), this, SLOT(packArif()));
    connect(btnUnpackArif, SIGNAL(released()), this, SLOT(unpackArif()));
}

void HuffmanTask::doAnything(QLabel *lbl, QString (*fun)(QString)) {
    QFile source(QFileDialog::getOpenFileName());
    QFile target(QFileDialog::getSaveFileName());
    lbl->setText(QString::asprintf(
                    "From: %s\nTo: %s",
                    source.fileName().toStdString().c_str(),
                    target.fileName().toStdString().c_str()));
    if(!source.open(QIODevice::ReadOnly) || !target.open(QIODevice::WriteOnly)) {
        QMessageBox::warning(nullptr, "Предупреждение", "Исходный файл не выбран или не существует");
        return;
    }
    target.write(fun(source.readAll()).toUtf8());
    source.close();
    target.close();
}

void HuffmanTask::packHuff() {
    doAnything(lblPackHuff, [](QString s) -> QString {
        return HuffmanAlgorithm(s.toStdString()).encode(s.toStdString()).c_str();
    });
}

void HuffmanTask::unpackHuff() {
    doAnything(lblUnpackHuff, [](QString s) -> QString {
        return HuffmanAlgorithm(s.toStdString()).encode(s.toStdString()).c_str();
    });
}

void HuffmanTask::packArif() {
    doAnything(lblPackArif, [](QString s) -> QString {
        return HuffmanAlgorithm(s.toStdString()).encode(s.toStdString()).c_str();
    });
}

void HuffmanTask::unpackArif() {
    doAnything(lblUnpackArif, [](QString s) -> QString {
        return HuffmanAlgorithm(s.toStdString()).encode(s.toStdString()).c_str();
    });
}
