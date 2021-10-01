#pragma once

#include <QWidget>
#include <QLabel>
#include <utility>
#include <QNetworkAccessManager>
#include <QNetworkReply>
#include <QJsonObject>
#include <QJsonDocument>
#include <QHBoxLayout>
#include <QLineEdit>
#include <QPushButton>

#include "Task.h"
#include "BigInt.h"

class RsaClient {
private:
    BigInt e, n;
    int k;

    QString crypt(const BigInt &c);

public:
    RsaClient(const BigInt& e, const BigInt& n);
    QString crypt(const QString &in);

    const BigInt &E() { return e; }
    const BigInt &N() { return n; }
};

class RsaTask;

class RsaLoader : public QObject {
Q_OBJECT
private:
    QNetworkAccessManager* manager;
    RsaTask* task;
    BigInt p, q, e, n, d;

public:
    explicit RsaLoader(RsaTask* task);
    void download(QString capacity);

private:
    void done(const QUrl& url, const QByteArray& array);

private slots:
    void slotFinished(QNetworkReply* reply);

};

class RsaTask: public QObject, public Task {
Q_OBJECT
private:
    QHBoxLayout *lytMain;
    QVBoxLayout *lytAlice;
    QHBoxLayout *lytCapacity;
    QVBoxLayout *lytBob;
    QHBoxLayout *lytABtns;
    QHBoxLayout *lytEN;
    QHBoxLayout *lytBBtns;

    QLabel *lblAlice;
    QLabel *lblBob;
    QLabel *lblCapacity;
    QLabel *lblE;
    QLabel *lblN;
    QLabel *lblInput;
    QLabel *lblPrivate;
    QLabel *lblPublic;
    QLabel *lblAIn;
    QLabel *lblAOut;
    QLabel *lblBIn;
    QLabel *lblBOut;

    QLineEdit *txtCapacity;
    QLineEdit *txtE;
    QLineEdit *txtN;
    QLineEdit *txtAIn;
    QLineEdit *txtAOut;
    QLineEdit *txtBIn;
    QLineEdit *txtBOut;

    QPushButton *btnLoad;
    QPushButton *btnACrypt;
    QPushButton *btnADecrypt;
    QPushButton *btnBCrypt;
    QPushButton *btnBDecrypt;

    RsaClient *alice = nullptr;
    RsaClient *bob = nullptr;
    RsaLoader *loader;

public slots:
    void getRsa();
    void aCrypt();
    void aDecrypt();
    void bCrypt();
    void bDecrypt();

public:
    RsaTask();
    void setRsa(const BigInt &p, const BigInt &q, const BigInt &e, const BigInt &n, const BigInt &d);
    void initWidget(QWidget *wgt) override;
    void run() const override;

};