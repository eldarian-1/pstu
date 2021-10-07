#include "DesTask.h"

#include <QLabel>
#include <QLineEdit>
#include <QJsonObject>
#include <QHBoxLayout>
#include <QPushButton>
#include <QFileDialog>
#include <QMessageBox>

void DesTask::initWidget(QWidget *wgt) {
    lytMain = new QVBoxLayout;
    lytInput = new QHBoxLayout;
    lytSource = new QHBoxLayout;
    lytCrypt = new QHBoxLayout;
    lytDecrypt = new QHBoxLayout;

    lblName = new QLabel("Блочное шифрование по методике DES");
    lblBlock = new QLabel("Блок 16 бит");
    lblKey = new QLabel("Ключ 32 бита: ...");
    lblSource = new QLabel("Исходный файл");
    lblCrypt = new QLabel("Зашифрованный файл");
    lblDecrypt = new QLabel("Расшифрованный файл");

    btnGenerate = new QPushButton("Сгенерировать");
    btnSource = new QPushButton("Обзор");
    btnCrypt = new QPushButton("Зашифровать");
    btnDecrypt = new QPushButton("Расшифровать");

    wgt->setLayout(lytMain);
    lytMain->addWidget(lblName);
    lytMain->addLayout(lytInput);
    lytInput->addWidget(lblBlock);
    lytInput->addWidget(lblKey);
    lytInput->addWidget(btnGenerate);
    lytMain->addWidget(lblSource);
    lytMain->addLayout(lytSource);
    lytSource->addWidget(lblSource, 4);
    lytSource->addWidget(btnSource, 1);
    lytMain->addLayout(lytCrypt);
    lytCrypt->addWidget(lblCrypt, 4);
    lytCrypt->addWidget(btnCrypt, 1);
    lytMain->addLayout(lytDecrypt);
    lytDecrypt->addWidget(lblDecrypt, 4);
    lytDecrypt->addWidget(btnDecrypt, 1);

    lytMain->setAlignment(Qt::Alignment::enum_type::AlignTop);

    connect(btnGenerate, SIGNAL(released()), this, SLOT(generate()));
    connect(btnSource, SIGNAL(released()), this, SLOT(source()));
    connect(btnCrypt, SIGNAL(released()), this, SLOT(crypt()));
    connect(btnDecrypt, SIGNAL(released()), this, SLOT(decrypt()));
}

void DesTask::setKey(const QString& key) {
    if (client) {
        delete client;
    }
    client = new DesClient(key.toLongLong());
    lblKey->setText("Ключ 32 бита: " + key);
}

void DesTask::generate() {
    (new DesLoader(this))->run();
}

void DesTask::source() {
    lblSource->setText(QFileDialog::getOpenFileName());
}

void DesTask::crypt() {
    crypt(lblSource, lblCrypt);
}

void DesTask::decrypt() {
    crypt(lblCrypt, lblDecrypt);
}

void DesTask::crypt(QLabel *source, QLabel *target) {
    QFile flSource(source->text());
    QFile flTarget(QFileDialog::getSaveFileName());
    if(!flSource.open(QIODevice::ReadOnly) || !flTarget.open(QIODevice::WriteOnly)) {
        QMessageBox::warning(nullptr, "Предупреждение", "Исходный файл не выбран или не существует");
        return;
    }
    target->setText(flTarget.fileName());
    QString sourceStr(flSource.readAll());
    flTarget.write(client->crypt(sourceStr).toUtf8());
    flSource.close();
    flTarget.close();
}

void DesLoader::done(QJsonObject& json) {
    task->setKey(json["key"].toString());
}

QString DesClient::crypt(QString text) const {
    int n = text.length();
    QString r;
    for(int i = 0; i < n; ++i) {
        r.append(crypt(text[i]));
    }
    return r;
}

QChar DesClient::crypt(QChar symbol) const {
    return {ushort(symbol.unicode() ^ key)};
}
