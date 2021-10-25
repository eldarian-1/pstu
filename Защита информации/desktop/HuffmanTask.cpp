#include "HuffmanTask.h"
#include "Huffman.h"
#include "Arithmetic.h"

#include <QLabel>
#include <QLineEdit>
#include <QBitArray>
#include <QTextStream>
#include <QDataStream>
#include <QHBoxLayout>
#include <QPushButton>
#include <QFileDialog>
#include <QMessageBox>

HuffmanNode * HuffmanNode::get(QChar ch, int freq, HuffmanNode* left, HuffmanNode* right) {
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

QString decode(HuffmanNode* root, int &index, QString str) {
    if (root == nullptr) {
        return "";
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

HuffmanAlgorithm::HuffmanAlgorithm(QString text) {
    for (QChar ch: text) {
        freq[ch]++;
    }
    fillPq();
    ::encode(root, "", huffmanCode);
    this->text = text;
}

void HuffmanAlgorithm::fillPq() {
    for (auto pair = freq.begin(); pair != freq.end(); ++pair) {
        pq.push(HuffmanNode::get(pair.key(), pair.value(), nullptr, nullptr));
    }
    while (pq.size() != 1) {
        HuffmanNode *left = pq.top(); pq.pop();
        HuffmanNode *right = pq.top();	pq.pop();
        int sum = left->freq + right->freq;
        pq.push(HuffmanNode::get('\0', sum, left, right));
    }
    root = pq.top();
}

QString HuffmanAlgorithm::decode(QString text) {
    QString str = "";
    int index = -1;
    while (index < (int)text.size() - 2) {
        str += ::decode(root, index, text);
    }
    return str;
}

QDataStream& operator >> (QDataStream &in, HuffmanAlgorithm& a) {
    int n;
    in >> n;
    for (int i = 0; i < n; ++i) {
        QChar key;
        int value;
        in >> key >> value;
        a.freq[key] = value;
    }
    a.fillPq();
    in >> n;
    for (int i = 0; i < n; ++i) {
        QChar key;
        QString value;
        in >> key >> value;
        a.huffmanCode[key] = value;
    }

    //Binary
    QBitArray bits;
    in >> bits;
    a.text = a.decode(bitToStr(bits));

    return in;
}

QDataStream& operator << (QDataStream &out, const HuffmanAlgorithm& a) {
    out << (int)a.freq.size();
    for (auto pair = a.freq.begin(); pair != a.freq.end(); ++pair) {
        out << pair.key() << pair.value();
    }
    out << (int)a.huffmanCode.size();
    for (auto pair = a.huffmanCode.begin(); pair != a.huffmanCode.end(); ++pair) {
        out << pair.key() << pair.value();
    }

    //Binary
    QString packed;
    for (QChar ch: a.text) {
        packed += a.huffmanCode[ch];
    }
    out << strToBit(packed);

    return out;
}

QTextStream& operator << (QTextStream &out, const HuffmanAlgorithm& a) {
    out << a.text;
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

void HuffmanTask::packHuff() {
    /*doAnything<QDataStream, QDataStream>(lblPackHuff, [](QDataStream &in, QDataStream &out) -> void {
        HuffmanEncoder encoder;
        in >> encoder;
        out << encoder;
    });*/
    doAnything<QTextStream, QDataStream>(lblPackHuff, [](QTextStream &in, QDataStream &out) -> void {
        out << HuffmanAlgorithm(in.readAll());
    });
}

void HuffmanTask::unpackHuff() {
    doAnything<QDataStream, QTextStream>(lblUnpackHuff, [](QDataStream &in, QTextStream &out) -> void {
        HuffmanAlgorithm a;
        in >> a;
        out << a;
    });
    /*doAnything<QDataStream, QDataStream>(lblUnpackHuff, [](QDataStream &in, QDataStream &out) -> void {
        HuffmanDecoder decoder;
        in >> decoder;
        out << decoder;
    });*/
}

void HuffmanTask::packArif() {
    /*doAnything<QTextStream, QDataStream>(lblPackArif, [](QTextStream &in, QDataStream &out) -> void {
        out << HuffmanAlgorithm(in.readAll());
    });**/
}

void HuffmanTask::unpackArif() {
    /*doAnything<QDataStream, QTextStream>(lblUnpackArif, [](QDataStream &in, QTextStream &out) -> void {
        HuffmanAlgorithm a;
        in >> a;
        out << a;
    });*/
}

template<class TIn, class TOut>
void HuffmanTask::doAnything(QLabel *lbl, void (*fun)(TIn&, TOut&)) {
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
    TIn in(&source);
    TOut out(&target);
    fun(in, out);
    source.close();
    target.close();
}
