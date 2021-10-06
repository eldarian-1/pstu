#pragma once

#include <QWidget>

#include "Task.h"
#include "Loader.h"
#include "BigInt.h"

class QLabel;
class QLineEdit;
class QPushButton;
class QVBoxLayout;
class QHBoxLayout;

class ElgamalClient;

class ElgamalTask: public QObject, public Task {
Q_OBJECT

private:
    ElgamalClient* client = nullptr;

    QVBoxLayout *lytMain;
    QHBoxLayout *lytPair;

    QLabel *lblName;
    QLabel *lblPrivate;
    QLabel *lblPublic;
    QLabel *lblSession;
    QLabel *lblMessage;
    QLabel *lblR;
    QLabel *lblS;
    QLabel *lblVerdict;

    QLineEdit *leMessage;
    QLineEdit *leR;
    QLineEdit *leS;

    QPushButton *btnGenerate;
    QPushButton *btnCrypt;
    QPushButton *btnCheck;


public:
    ElgamalTask(): Task("Метод Эль-Гамаля") {}

    void initWidget(QWidget *wgt) override;
    void setElgamal(const BigInt &p, const BigInt &g, const BigInt &x, const BigInt &y, const BigInt &k);

public slots:
    void getElgamal();
    void crypt();
    void check();

};

class ElgamalLoader : public LoadTask {
private:
    ElgamalTask* task;

public:
    explicit ElgamalLoader(ElgamalTask* task) : task(task) {}
    QString query() override { return "elgamal"; }
    void done(QJsonObject& json) override;

};

class ElgamalClient {
private:
    BigInt p, g, x, y, k;

public:
    ElgamalClient(BigInt p, BigInt g, BigInt x, BigInt y, BigInt k) : p(p), g(g), x(x), y(y), k(k) {}
    void generate(QString m, BigInt &r, BigInt &s);
    bool check(BigInt r, BigInt s);

};