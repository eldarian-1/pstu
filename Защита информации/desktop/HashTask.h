#pragma once

#include <QWidget>

#include "Task.h"
#include "Loader.h"

class QLabel;
class QTextEdit;
class QPushButton;
class QVBoxLayout;

class HashTask: public QObject, public Task {
Q_OBJECT

private:
    QVBoxLayout *lytMain;
    QLabel *lblName;
    QLabel *lblEnter;
    QTextEdit *teIn;
    QTextEdit *teOut;
    QPushButton *btnHash;

public:
    HashTask(): Task("Хеширование") {}

    void initWidget(QWidget *wgt) override;

    void run() const override { }
    void setHash(QString text);

private slots:
    void hash();

};

class HashLoader : public PostLoadTask {
private:
    HashTask* task;
    QString text;

public:
    explicit HashLoader(HashTask* task, QString text) : task(task), text(text) {}
    QString query() override;
    QJsonDocument request() override;
    void done(QJsonObject& json) override;

};
