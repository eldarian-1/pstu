#include "FractalEditor.h"

#include "Canvas.h"

FractalSettings *FractalSettings::_instance = nullptr;

FractalSettings *FractalSettings::instance() {
    if(!_instance) {
        _instance = new FractalSettings {
            QPoint(600, 0),
            QPoint(600, 350),
            {-120, -60, 0, 60, 120},
            {
                {7, 0.5, QColor("#704b23")},
                {5, 0.5, QColor("#704b23")},
                {3, 0.5, QColor("#704b23")},
                {1, 0.5, QColor("#704b23")},
                {3, 0.5, QColor("#007d34")},
                {5, 1, QColor("#007d34")},
                }
        };
    }
    return _instance;
}

FractalEditor::FractalEditor() {

}

void FractalEditor::closeEvent(QCloseEvent *event) {
    Canvas::instance()->clearEditor();
}
