#include <QApplication>
#include "Splines.h"

int main(int argc, char **argv) {
    QApplication app(argc, argv);
    Splines d;
    d.show();
    app.exec();
    return 0;
}
