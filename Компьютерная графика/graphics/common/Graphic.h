#pragma once

#include "Matrix.h"

class QPoint;

namespace Graphic {
    QPoint* getPoints(Matrix matrix);
    QPoint* getPoints(Matrix matrix, int &size);

}
