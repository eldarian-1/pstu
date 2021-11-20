#include <QApplication>
#include "Home.h"

int main(int argc, char **argv) {
    QApplication app(argc, argv);
    Home d;
    d.show();
    app.exec();
    return 0;
}
