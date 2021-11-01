#pragma once

#include <QString>

namespace Func {
    QString stringOf(int value);
    void doIt(const std::function<void(void)>& task, bool &mutex);
    int gcd(int a, int b);
    int gcd(int a, int b, int c);

}
