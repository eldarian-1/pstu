#include <QApplication>
#include "Dz4.h"
#include "Dz6.h"

int main(int argc, char **argv) {
    QApplication app(argc, argv);
    Dz4 d4;
    d4.show();
    Dz6 d6;
    d6.show();
    app.exec();
    return 0;
}
