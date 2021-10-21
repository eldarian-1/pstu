#include "Matrix.h"

#include <cmath>
#include <iostream>

Matrix::Matrix(Matrix &mx) {
    int _n = mx.n(), _m = mx.m();
    this->_m = matrix(_n, vector(_m));
    for(int i = 0; i < _n; ++i) {
        for(int j = 0; j < _m; ++j) {
            (*this)[i][j] = mx[i][j];
        }
    }
}

Matrix::Matrix(const int &n, const int &m) {
    _m = matrix(n, vector(m, 0.));
}

Matrix::Matrix(std::initializer_list<std::initializer_list<double>> mx) {
    int n = mx.size(), m = begin(mx)->size();
    _m = matrix(n, vector(m));
    for(int i = 0; i < n; ++i) {
        for(int j = 0; j < m; ++j) {
            _m[i][j] = begin(begin(mx)[i])[j];
        }
    }
}

Matrix::~Matrix() {
    for(int i = 0, _n = n(); i < _n; ++i) {
        (*this)[i].clear();
    }
    _m.clear();
}

int Matrix::n() {
    return _m.size();
}

int Matrix::m() {
    return begin(_m)->size();;
}

void Matrix::out() {
    std::cout << "Matrix\n";
    for(int i = 0, n = this->n(); i < n; ++i) {
        for(int j = 0, m = this->m(); j < m; ++j) {
            std::cout << (*this)[i][j] << " ";
        }
        std::cout << "\n";
    }
    std::cout << "\n";
}

double min(double a, double b) {
    return (a < b ? a : b);
}

double Matrix::min(int i) {
    double m = (*this)[0][i];
    for(int j = 1, n = this->n(); j < n; ++j) {
        m = ::min(m, (*this)[j][i]);
    }
    return m;
}

Matrix Matrix::normalize() {
    int _n = n(), _m = m();
    Matrix result(*this);
    for(int i = 0; i < _n; ++i) {
        double last = (*this)[i][_m - 1];
        for(int j = 0; j < _m; ++j) {
            result[i][j] /= last;
        }
    }
    return result;
}

Matrix Matrix::to2D(double zc) {
    for(int i = 0, _n = (*this).n(), last = (*this).m() - 1; i < _n; ++i) {
        (*this)[i][last] = -(*this)[i][last] / zc;
    }
    return *this;
}

Matrix Matrix::to2D(double t, double f, double zc) {
    Matrix r = rotate3D(t, f);
    Matrix m = (*this) * r;
    Matrix res = m.to2D(zc);
    return res;
}

Matrix Matrix::vanishingPoints() {
    Matrix ones {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
    };
    return (ones * (*this)).normalize();
}

vector & Matrix::operator [] (const int &i) {
    return begin(_m)[i];
}

Matrix operator * (Matrix left, Matrix right) {
    int n = left.n(), m = left.m();
    Matrix result(n, m);
    for(int i = 0; i < n; ++i) {
        for(int j = 0; j < m; ++j) {
            for(int k = 0; k < m; ++k) {
                result[i][j] += left[i][k] * right[k][j];
            }
        }
    }
    return result;
}

Matrix transfer2D(double m, double n) {
    return Matrix{
            {1, 0, 0},
            {0, 1, 0},
            {m, n, 1},
    };
}

Matrix rotate2D(double alpha) {
    return Matrix{
            {cos(alpha),    sin(alpha), 0},
            {-sin(alpha),   cos(alpha), 0},
            {0,             0,          1},
    };
}

Matrix scale2D(double a, double d) {
    return Matrix{
            {a, 0, 0},
            {0, d, 0},
            {0, 0, 1},
    };
}

Matrix mirror2D(bool horizontal, bool vertical) {
    return scale2D(horizontal ? -1 : 1, vertical ? -1 : 1);
}

Matrix project2D(double p, double q) {
    return Matrix{
            {1, 0, p},
            {0, 1, q},
            {0, 0, 1},
    };
}

Matrix transfer3D(double m, double n, double l) {
    return Matrix{
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {m, n, l, 1},
    };
}

Matrix rotateOx(double t) {
    return Matrix{
            {1, 0,      0,      0},
            {0, cos(t), sin(t), 0},
            {0, -sin(t),cos(t), 0},
            {0, 0,      0,      1},
    };
}

Matrix rotateOy(double f) {
    return Matrix{
            {cos(f),0, -sin(f), 0},
            {0,     1, 0,       0},
            {sin(f),0, cos(f),  0},
            {0,     0, 0,       1},
    };
}

Matrix rotate3D(double t, double f) {
    Matrix x = rotateOx(t);
    Matrix y = rotateOy(f);
    return (x * y);
}

Matrix scale3D(double a, double d, double e) {
    return Matrix{
            {a, 0, 0, 0},
            {0, d, 0, 0},
            {0, 0, e, 0},
            {0, 0, 0, 1},
    };
}

Matrix mirror3D(bool horizontal, bool vertical, bool frontal) {
    return scale3D(horizontal ? -1 : 1, vertical ? -1 : 1, frontal ? -1 : 1);
}

Matrix project3D(double p, double q, double r) {
    return Matrix{
            {1, 0, 0, p},
            {0, 1, 0, q},
            {0, 0, 1, r},
            {0, 0, 0, 1},
    };
}
