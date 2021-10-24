#include <QJsonObject>
#include <QJsonDocument>
#include <QByteArray>
#include <QVBoxLayout>
#include <QTextEdit>
#include <QPushButton>
#include <QLabel>

#include "HashTask.h"

void HashTask::initWidget(QWidget *wgt) {
    lytMain = new QVBoxLayout;
    lblName = new QLabel("Хеширование блоков DES", wgt);
    lblEnter = new QLabel("Введите пароль", wgt);
    teIn = new QTextEdit;
    teOut = new QTextEdit;
    btnHash = new QPushButton("Получить хеш");

    wgt->setLayout(lytMain);
    lytMain->addWidget(lblName);
    lytMain->addWidget(lblEnter);
    lytMain->addWidget(teIn);
    lytMain->addWidget(btnHash);
    lytMain->addWidget(teOut);

    connect(btnHash, SIGNAL(released()), SLOT(hash()));
}

void HashTask::setHash(QString text) {
    teOut->setText(text);
}

void HashTask::hash() {
    (new HashLoader(this, teIn->toPlainText()))->run();
}

QString HashLoader::query() {
    return "hash";
}

QJsonDocument HashLoader::request() {
    QJsonObject obj;
    obj["text"] = text;
    QJsonDocument doc(obj);
    return doc;
}

void HashLoader::done(QJsonObject& json) {
    task->setHash(json["hash"].toString());
}
