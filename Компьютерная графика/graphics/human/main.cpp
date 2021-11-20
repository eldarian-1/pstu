#include <QApplication>
#include "Human.h"

int main(int argc, char **argv) {
    QApplication app(argc, argv);
    Point d;
    d.show();
    app.exec();
    return 0;
}
