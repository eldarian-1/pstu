#include "LineCleaner.h"

#include <QVBoxLayout>
#include <QPushButton>
#include <QListWidget>
#include <QMessageBox>

#include "../Canvas.h"
#include "../figures/Line.h"

LineCleaner::LineCleaner(Canvas *canvas) : canvas(canvas) {
    lytMain = new QVBoxLayout;
    btnRemoveAll = new QPushButton("Удалить все линии");
    listWidget = new QListWidget;

    setLayout(lytMain);
    lytMain->addWidget(btnRemoveAll);
    lytMain->addWidget(listWidget);
    fillList();

    connect(btnRemoveAll, SIGNAL(released()), SLOT(removeAll()));
    connect(listWidget, SIGNAL(itemClicked(QListWidgetItem*)), SLOT(itemClicked(QListWidgetItem*)));

    setWindowTitle("Удаление линий");
    show();
}

LineCleaner::~LineCleaner() {
    delete listWidget;
}

void LineCleaner::fillList() {
    listWidget->clear();
    for(auto item : canvas->getLines()) {
        QListWidgetItem *itemList = new QListWidgetItem(item->toString());
        listWidget->addItem(itemList);
    }
}

void LineCleaner::closeEvent(QCloseEvent *event) {
    emit closed();
}

void LineCleaner::removeAll() {
    auto mes = QMessageBox(
            QMessageBox::Information, "Предупреждение",
            "Вы действительно хотите удалить все прямые линии?",
            QMessageBox::Yes | QMessageBox::No);
    if(mes.exec() == QMessageBox::Yes) {
        canvas->getLines().clear();
        listWidget->clear();
    }
}

void LineCleaner::itemClicked(QListWidgetItem* item) {
    auto mes = QMessageBox(
            QMessageBox::Information,
            "Предупреждение",
            QString::asprintf("Вы действительно хотите удалить прямую линию %s?",
                              item->text().toStdString().c_str()),
            QMessageBox::Yes | QMessageBox::No);
    if(mes.exec() == QMessageBox::Yes) {
        for (auto iter = canvas->getLines().begin(); iter != canvas->getLines().end(); ++iter) {
            if (item->text() == (*iter)->toString()) {
                canvas->getLines().erase(iter);
                break;
            }
        }
        delete item;
    }
}
