#pragma once

#include <QString>

namespace Func {
    QString stringOf(int value);
    void doIt(std::function<void(void)> task);

}
