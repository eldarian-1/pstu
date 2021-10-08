#pragma once

#include "Task.h"
#include "Loader.h"

class QLabel;
class QLineEdit;
class QPushButton;
class QVBoxLayout;
class QHBoxLayout;
class QJsonObject;

class DesClient;

class DesTask: public QObject, public Task {
Q_OBJECT

private:
    DesClient *client = nullptr;

    QVBoxLayout *lytMain;
    QHBoxLayout *lytInput;
    QHBoxLayout *lytSource;
    QHBoxLayout *lytCrypt;
    QHBoxLayout *lytDecrypt;

    QLabel *lblName;
    QLabel *lblBlock;
    QLabel *lblKey;
    QLabel *lblSource;
    QLabel *lblCrypt;
    QLabel *lblDecrypt;

    QPushButton *btnGenerate;
    QPushButton *btnSource;
    QPushButton *btnCrypt;
    QPushButton *btnDecrypt;

public:
    DesTask(): Task("Методика Des") {}

    void initWidget(QWidget *wgt) override;
    void setKey(const QString& key);

public slots:
    void generate();
    void source();
    void crypt();
    void decrypt();

private:
    void crypt(QLabel *source, QLabel *target, bool d);

};

class DesLoader : public LoadTask {
private:
    DesTask* task;

public:
    explicit DesLoader(DesTask* task) : task(task) {}
    QString query() override { return "des"; }
    void done(QJsonObject& json) override;

};

class DesClient {
private:
    long long key;

public:
    explicit DesClient(long long key) : key(key) {}

    QString crypt(QString text, bool d) const;
    QChar crypt(QChar symbol, bool d) const;

};
