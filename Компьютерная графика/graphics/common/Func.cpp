#include "Func.h"

QString Func::stringOf(int value) {
    return QString::asprintf("%d", value);
}

void Func::doIt(std::function<void(void)> task) {
    static bool isDone = false;
    if(isDone) {
        isDone = false;
    } else {
        task();
        isDone = true;
    }
}
