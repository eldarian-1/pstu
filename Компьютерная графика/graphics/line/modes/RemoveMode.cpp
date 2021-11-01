#include "RemoveMode.h"

#include "../Canvas.h"
#include "../widgets/LineCleaner.h"

void RemoveMode::start() {
    if(cleaner) {
        delete cleaner;
    }
    cleaner = new LineCleaner(canvas);
    connect(cleaner, SIGNAL(closed()), SLOT(slotClosed()));
}

void RemoveMode::mouseMoveEvent(QMouseEvent *event) {

}

void RemoveMode::slotClosed() {
    canvas->setMode(Mode::create());
}
