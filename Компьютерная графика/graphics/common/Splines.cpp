#include "Splines.h"

extern const Splines::equation_t Splines::a0 = {
        {
            {1, -1},
            {4, 0},
            {1, 1}
        }, 6};
extern const Splines::equation_t Splines::a1 = {
        {
            {-1, -1},
            {1, 1}
        }, 2};
extern const Splines::equation_t Splines::a2 = {
        {
            {1, -1},
            {-2, 0},
            {1, 1}
        }, 2};
extern const Splines::equation_t Splines::a3 = {
        {
            {-1, -1},
            {3, 0},
            {-3, 1},
            {1, 2}
        }, 6};

double Splines::solve(Matrix &m, int i, int j, equation_t equation) {
    double result = 0;
    for(int k = 0, n = equation.first.size(); k < n; ++k) {
        std::pair p = equation.first[k];
        result += p.first * m[{i + p.second, j}];
    }
    return result / equation.second;
}

double Splines::f(Matrix &v, int i, int j, double t) {
    return ((
            solve(v, i, j, a3) * t +
            solve(v, i, j, a2)) * t +
            solve(v, i, j, a1)) * t +
            solve(v, i, j, a0);
}

Matrix Splines::get(Matrix &m, int parts) {
    int n = m.n();
    Matrix result(n * parts, 2);
    for(int i = 0; i < n; ++i) {
        double t = 0., d = 1. / parts;
        for(int j = 0; j < parts; ++j, t += d) {
            result[{i * parts + j, 0}] = f(m, i, 0, t);
            result[{i * parts + j, 1}] = f(m, i, 1, t);
        }
    }
    return result;
}
