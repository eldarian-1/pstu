#pragma once

#include <QObject>

class QNetworkReply;
class QNetworkAccessManager;

class LoadTask {
public:
    void run();
    virtual QString query() = 0;
    virtual void done(QJsonObject* json) = 0;

};

class Loader: public QObject {
Q_OBJECT

private:
    static Loader *instance;

    QNetworkAccessManager* manager;
    LoadTask *task = nullptr;

public:
    static Loader *getInstance();

    Loader();

    void download(LoadTask *task);

private slots:
    void slotFinished(QNetworkReply* reply);

};