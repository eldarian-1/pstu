#include <QApplication>

#include "Canvas.h"
#include "widgets/LineEditor.h"

int main(int argc, char** argv) {
    QApplication app(argc, argv);
    Canvas canvas;
    canvas.show();
    LineEditor editor(nullptr);
    editor.show();
    return app.exec();
}
