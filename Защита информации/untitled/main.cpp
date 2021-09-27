#include <QApplication>
#include "Window.h"

int main(int argc, char **argv)
{
    setlocale(LC_ALL, "Russian");
    QApplication app(argc, argv);
    Window window;
    window.show();
    return app.exec();
}
