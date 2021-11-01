#pragma once

#include <QWidget>

class Line;
class Canvas;
class QVBoxLayout;
class QPushButton;
class QListWidget;
class QListWidgetItem;

class LineCleaner : public QWidget {
Q_OBJECT

private:
    Canvas *canvas;
    QVBoxLayout* lytMain;
    QPushButton* btnRemoveAll;
    QListWidget* listWidget;

public:
    LineCleaner(Canvas *canvas);
    ~LineCleaner();

signals:
    void closed();

protected:
    void fillList();
    void closeEvent(QCloseEvent *event) override;

private slots:
    void removeAll();
    void itemClicked(QListWidgetItem* item);

};
