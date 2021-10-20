#include "Matrix.h"

#include <cmath>
#include <iostream>
using namespace std;

Matrix_ptr Matrix::multiply(Matrix_ptr left, Matrix_ptr right) {
    int n = left->n(), m = left->m();
    Matrix_ptr result(new Matrix(n, m));
    for(int i = 0; i < n; ++i) {
        for(int j = 0; j < m; ++j) {
            for(int k = 0; k < m; ++k) {
                (*result)[i][j] = (*left)[i][k] * (*right)[k][j];
            }
        }
    }

    for(int i = 0; i < n; ++i) {
        for(int j = 0; j < m; ++j) {
            std::cout << (*result)[i][j] << " ";
        }
        std::cout << "\n";
    }

    return result;
}

Matrix::Matrix(Matrix_ptr matrix) {
    int _n = matrix->n(), _m = matrix->m();
    for(int i = 0; i < _n; ++i) {
        for(int j = 0; j < _m; ++j) {
            (*this)[i][j] = (*matrix)[i][j];
        }
        (*this)[i][_m - 1] = -(*matrix)[i][_m - 1] / 3;
    }
}

Matrix::Matrix(const int &n, const int &m) {
    _matrix = vector<vector<double>>(n, vector<double>(m, 0.));
}

Matrix::Matrix(initializer_list<initializer_list<double>> matrix) {
    int n = matrix.size(), m = begin(matrix)->size();
    _matrix = vector<vector<double>>(n, vector<double>(m));
    for(int i = 0; i < n; ++i) {
        for(int j = 0; j < m; ++j) {
            _matrix[i][j] = begin(begin(matrix)[i])[j];
        }
    }
}

/*Matrix & Matrix::operator = (Matrix &&matrix) {
    this->_matrix = matrix._matrix;
    return *this;
}*/

Matrix::~Matrix() {
    for(int i = 0, _n = n(); i < _n; ++i) {
        (*this)[i].clear();
    }
    _matrix.clear();
}

int Matrix::n() {
    return _matrix.size();
}

int Matrix::m() {
    return begin(_matrix)->size();;
}

Matrix Matrix::normalize() {
    int _n = n(), _m = m();
    Matrix result(_n, _m);
    for(int i = 0; i < _n; ++i) {
        double last = (*this)[i][_m - 1];
        for(int j = 0; j < _m; ++j) {
            result[i][j] /= last;
        }
    }
    return result;
}

Matrix_ptr Matrix::to2D(double zc) {
    Matrix_ptr result(new Matrix(*this));
    for(int i = 0, _n = result->n(), last = result->m() - 1; i < _n; ++i) {
        (*result)[i][last] = -(*result)[i][last] / zc;
    }
    return result;
}

Matrix_ptr Matrix::to2D(double t, double f, double zc) {
    return multiply(Matrix_ptr(this), Matrix3D::rotate(t, f))->to2D(zc);
}

vector<double> & Matrix::operator [] (const int &i) {
    return begin(_matrix)[i];
}

Matrix_ptr Matrix2D::transfer(double m, double n) {
    return Matrix_ptr(new Matrix{
            {1, 0, 0},
            {0, 1, 0},
            {m, n, 1},
    });
}

Matrix_ptr Matrix2D::rotate(double alpha) {
    return Matrix_ptr(new Matrix{
            {cos(alpha),    sin(alpha), 0},
            {-sin(alpha),   cos(alpha), 0},
            {0,             0,          1},
    });
}

Matrix_ptr Matrix2D::scale(double a, double d) {
    return Matrix_ptr(new Matrix{
            {a, 0, 0},
            {0, d, 0},
            {0, 0, 1},
    });
}

Matrix_ptr Matrix2D::mirror(bool horizontal, bool vertical) {
    return scale(horizontal ? -1 : 1, vertical ? -1 : 1);
}

Matrix_ptr Matrix2D::project(double p, double q) {
    return Matrix_ptr(new Matrix{
            {1, 0, p},
            {0, 1, q},
            {0, 0, 1},
    });
}

Matrix_ptr Matrix3D::transfer(double m, double n, double l) {
    return Matrix_ptr(new Matrix{
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {m, n, l, 1},
    });
}

Matrix_ptr Matrix3D::rotateOx(double t) {
    return Matrix_ptr(new Matrix{
            {1, 0,      0,      0},
            {0, cos(t), sin(t), 0},
            {0, -sin(t),cos(t), 0},
            {0, 0,      0,      1},
    });
}

Matrix_ptr Matrix3D::rotateOy(double f) {
    return Matrix_ptr(new Matrix{
            {cos(f),0, -sin(f), 0},
            {0,     1, 0,       0},
            {sin(f),0, cos(f),  0},
            {0,     0, 0,       1},
    });
}

Matrix_ptr Matrix3D::rotate(double t, double f) {
    return multiply(rotateOx(t), rotateOy(f));
}

Matrix_ptr Matrix3D::scale(double a, double d, double e) {
    return Matrix_ptr(new Matrix{
            {a, 0, 0, 0},
            {0, d, 0, 0},
            {0, 0, e, 0},
            {0, 0, 0, 1},
    });
}

Matrix_ptr Matrix3D::mirror(bool horizontal, bool vertical, bool frontal) {
    return scale(horizontal ? -1 : 1, vertical ? -1 : 1, frontal ? -1 : 1);
}

Matrix_ptr Matrix3D::project(double p, double q, double r) {
    return Matrix_ptr(new Matrix{
            {1, 0, 0, p},
            {0, 1, 0, q},
            {0, 0, 1, r},
            {0, 0, 0, 1},
    });
}
