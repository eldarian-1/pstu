#pragma once

#include <QObject>

class QNetworkReply;
class QNetworkAccessManager;

class Loader: public QObject {
Q_OBJECT

private:
    QNetworkAccessManager* manager;

public:
    Loader();
    virtual void download(QString query);

private slots:
    void slotFinished(QNetworkReply* reply);

protected:
    virtual void done(QJsonObject* json) = 0;

};