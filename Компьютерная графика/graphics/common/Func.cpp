#include "Func.h"

QString Func::stringOf(int value) {
    return QString::asprintf("%d", value);
}

void Func::doIt(std::function<void(void)> task, bool &mutex) {
    if(!mutex) {
        mutex = true;
        task();
        mutex = false;
    }
}
