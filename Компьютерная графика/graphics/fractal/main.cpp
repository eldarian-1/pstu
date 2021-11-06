#include <QApplication>

#include "Canvas.h"

int main(int argc, char** argv) {
    QApplication app(argc, argv);
    Canvas::instance()->show();
    return app.exec();
}
