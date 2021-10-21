#include <QApplication>
#include "Dz5.h"

int main(int argc, char **argv) {
    QApplication app(argc, argv);
    Dz5 d;
    d.show();
    app.exec();
    return 0;
}
