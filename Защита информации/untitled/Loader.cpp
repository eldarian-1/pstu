#include "Loader.h"

#include <QJsonObject>
#include <QJsonDocument>
#include <QNetworkReply>
#include <QNetworkAccessManager>

void LoadTask::run() {
    Loader::getInstance()->download(this);
}

Loader *Loader::instance = nullptr;

Loader *Loader::getInstance() {
    if(!instance) {
        instance = new Loader();
    }
    return instance;
}

Loader::Loader() {
    manager = new QNetworkAccessManager(this);
    connect(manager, SIGNAL(finished(QNetworkReply*)), SLOT(slotFinished(QNetworkReply*)));
}

void Loader::download(LoadTask *task) {
    if(this->task) {
        delete this->task;
    }
    this->task = task;
    manager->get(QNetworkRequest(QUrl("http://localhost:8080/" + task->query())));
}

void Loader::slotFinished(QNetworkReply* reply) {
    if (reply->error() == QNetworkReply::NoError) {
        QJsonObject json = QJsonDocument::fromJson(reply->readAll()).object();
        task->done(json);
    }
    reply->deleteLater();
}