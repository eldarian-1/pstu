#include "Loader.h"

#include <QJsonObject>
#include <QJsonDocument>
#include <QNetworkReply>
#include <QNetworkAccessManager>

Loader::Loader() {
    manager = new QNetworkAccessManager(this);
    connect(manager, SIGNAL(finished(QNetworkReply*)), SLOT(slotFinished(QNetworkReply*)));
}

void Loader::download(QString query) {
    manager->get(QNetworkRequest(QUrl("http://localhost:8080/?" + query)));
}

void Loader::slotFinished(QNetworkReply* reply) {
    if (reply->error() == QNetworkReply::NoError) {
        QJsonObject json = QJsonDocument::fromJson(reply->readAll()).object();
        done(&json);
    }
    reply->deleteLater();
}