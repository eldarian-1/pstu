#include "GammaTask.h"

#include <QWidget>
#include <QVBoxLayout>
#include <QLabel>
#include <QLineEdit>
#include <QPushButton>
#include <QTextEdit>

void getBlocks(QString text, u48 *&out, int &n) {
    int N = text.size();
    int m = N + (N % 3 ? 3 - N % 3 : 0);
    n = m / 3;
    out = new u48[n];
    ushort *o = (ushort *) out;
    for (int i = 0; i <= n; ++i) {
        for (int j = 0; j < 3; ++j) {
            int k = i * 3 + j;
            if  (k < N) {
                o[k] = text[k].unicode();
            } else {
                o[k] = 0;
            }
        }
    }
}

void hash(u48 *&in, const int &n, const unsigned long long &key) {
    for(int i = 0; i < n * 3; ++i) {
        ((ushort*)in)[i] ^= key;
    }
}

QString getString(u48 *&in, const int &n) {
    QString out;
    int N = n * 3;
    ushort *o = (ushort *) in;
    for(int i = 0; i < N; ++i) {
        out += QChar(o[i]);
    }
    return out;
}

QString getNumbers(u48 *&in, const int &n) {
    QString out;
    int N = n * 3;
    ushort *o = (ushort *) in;
    for(int i = 0; i < N; i += 3) {
        out += QString::asprintf("%llu\n", ((unsigned long long)o[i] * 256 + o[i + 1]) * 256 + o[i + 2]);
    }
    return out;
}

void GammaTask::initWidget(QWidget *wgt) {
    lytMain = new QVBoxLayout;
    lytKey = new QHBoxLayout;
    lytIn = new QHBoxLayout;
    lblName = new QLabel("Метод однократного гаммирования");
    lblKey = new QLabel("Ключ");
    lblIn = new QLabel("Ввод");
    leResult = new QLineEdit("Результат строкой");
    txtResult = new QTextEdit("Результат в числах");
    leKey = new QLineEdit;
    leIn = new QLineEdit;
    btn = new QPushButton("Выполнить гаммирование");

    wgt->setLayout(lytMain);
    lytMain->addWidget(lblName);
    lytMain->addLayout(lytKey);
    lytKey->addWidget(lblKey);
    lytKey->addWidget(leKey);
    lytMain->addLayout(lytIn);
    lytIn->addWidget(lblIn);
    lytIn->addWidget(leIn);
    lytMain->addWidget(btn);
    lytMain->addWidget(leResult);
    lytMain->addWidget(txtResult);

    lytMain->setAlignment(Qt::Alignment::enum_type::AlignTop);
    connect(btn, SIGNAL(released()), SLOT(generate()));
}

void GammaTask::generate() {
    int n;
    u48 *bytes;
    getBlocks(leIn->text(), bytes, n);
    unsigned long long key = leKey->text().toULongLong();
    hash(bytes, n, key);
    QString str = getString(bytes, n);
    QString nums = getNumbers(bytes, n);
    delete[] bytes;
    leResult->setText(str);
    txtResult->setText(nums);
}
