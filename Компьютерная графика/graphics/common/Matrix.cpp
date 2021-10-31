#include "Matrix.h"

#include <cmath>

Matrix::Matrix(Matrix &mx) {
    int _n = mx.n(), _m = mx.m();
    this->_m = std::vector<std::vector<double>>(_n, std::vector<double>(_m));
    for(int i = 0; i < _n; ++i) {
        for(int j = 0; j < _m; ++j) {
            (*this)[i][j] = mx[i][j];
        }
    }
}

Matrix::Matrix(const int &n, const int &m) {
    _m = std::vector<std::vector<double>>(n, std::vector<double>(m, 0.));
}

Matrix::Matrix(std::initializer_list<std::initializer_list<double>> mx) {
    int n = mx.size(), m = begin(mx)[0].size();
    _m = std::vector<std::vector<double>>(n, std::vector<double>(m));
    for(int i = 0; i < n; ++i) {
        for(int j = 0; j < m; ++j) {
            _m[i][j] = begin(begin(mx)[i])[j];
        }
    }
}

Matrix::~Matrix() {
    _m.clear();
}

int Matrix::n() {
    return _m.size();
}

int Matrix::m() {
    return _m[0].size();
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

std::vector<double> & Matrix::operator [] (const int &i) {
    return _m[safeIndex(n(), i)];
}


double & Matrix::operator [] (const std::pair<int, int> &pair) {
    return (*this)[pair.first][safeIndex(m(), pair.second)];
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

Matrix Matrix::transfer2D(double m, double n) {
    return Matrix {
            {1, 0, 0},
            {0, 1, 0},
            {m, n, 1},
    };
}

Matrix Matrix::rotate2D(double alpha) {
    return Matrix {
            {cos(alpha),    sin(alpha), 0},
            {-sin(alpha),   cos(alpha), 0},
            {0,             0,          1},
    };
}

Matrix Matrix::scale2D(double a, double d) {
    return Matrix {
            {a, 0, 0},
            {0, d, 0},
            {0, 0, 1},
    };
}

Matrix Matrix::mirror2D(bool horizontal, bool vertical) {
    return scale2D(horizontal ? -1 : 1, vertical ? -1 : 1);
}

Matrix Matrix::project2D(double p, double q) {
    return Matrix {
            {1, 0, p},
            {0, 1, q},
            {0, 0, 1},
    };
}

Matrix Matrix::transfer3D(double m, double n, double l) {
    return Matrix {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {m, n, l, 1},
    };
}

Matrix Matrix::rotateOx(double t) {
    return Matrix {
            {1, 0,      0,      0},
            {0, cos(t), sin(t), 0},
            {0, -sin(t),cos(t), 0},
            {0, 0,      0,      1},
    };
}

Matrix Matrix::rotateOy(double f) {
    return Matrix {
            {cos(f),0, -sin(f), 0},
            {0,     1, 0,       0},
            {sin(f),0, cos(f),  0},
            {0,     0, 0,       1},
    };
}

Matrix Matrix::rotate3D(double t, double f) {
    Matrix x = rotateOx(t);
    Matrix y = rotateOy(f);
    return (x * y);
}

Matrix Matrix::scale3D(double a, double d, double e) {
    return Matrix {
            {a, 0, 0, 0},
            {0, d, 0, 0},
            {0, 0, e, 0},
            {0, 0, 0, 1},
    };
}

Matrix Matrix::mirror3D(bool horizontal, bool vertical, bool frontal) {
    return scale3D(horizontal ? -1 : 1, vertical ? -1 : 1, frontal ? -1 : 1);
}

Matrix Matrix::project3D(double p, double q, double r) {
    return Matrix {
            {1, 0, 0, p},
            {0, 1, 0, q},
            {0, 0, 1, r},
            {0, 0, 0, 1},
    };
}

int Matrix::safeIndex(const int &n, const int &i) {
    if(i >= 0 && i < n) {
        return i;
    } else if(i < 0) {
        return n + i;
    } else {
        return i - n;
    }
}