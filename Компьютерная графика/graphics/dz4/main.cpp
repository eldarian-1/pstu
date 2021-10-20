#include <QApplication>
#include "Dz4.h"

int main(int argc, char **argv) {
    QApplication app(argc, argv);
    Dz4 d;
    d.show();
    app.exec();
    return 0;
}
