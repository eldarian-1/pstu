#include "Func.h"

QString Func::stringOf(int value) {
    return QString::asprintf("%d", value);
}

void Func::doIt(const std::function<void(void)>& task, bool &mutex) {
    if(!mutex) {
        mutex = true;
        task();
        mutex = false;
    }
}

int Func::gcd(int a, int b) {
    while(a && b) {
        if(abs(a) > abs(b)) {
            a %= b;
        } else {
            b %= a;
        }
    }
    return a + b;
}

int Func::gcd(int a, int b, int c) {
    return gcd(gcd(a, b), gcd(b, c));
}
