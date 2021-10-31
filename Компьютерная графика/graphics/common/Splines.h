#pragma once

#include "Matrix.h"

namespace Splines {
    typedef std::pair<std::vector<std::pair<double, int>>, double> equation_t;

    extern const equation_t a0;
    extern const equation_t a1;
    extern const equation_t a2;
    extern const equation_t a3;

    double solve(Matrix &v, int i, int j, equation_t equation);
    double f(Matrix &v, int i, int j, double t);
    Matrix get(Matrix &m, int parts);

}
