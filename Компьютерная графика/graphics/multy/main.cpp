#include <QApplication>
#include "Multy.h"

int main(int argc, char **argv) {
    QApplication app(argc, argv);
    Multy m;
    m.show();
    return app.exec();
}