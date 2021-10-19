#include <QApplication>
#include "Dz6.h"

int main(int argc, char **argv) {
    QApplication app(argc, argv);
    Dz6 d;
    d.show();
    app.exec();
    return 0;
}
