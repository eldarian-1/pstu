#pragma once

#include <vector>
#include <memory>
using namespace std;

class Matrix;
typedef shared_ptr<Matrix> Matrix_ptr;

class Matrix {
private:
    vector<vector<double>> _matrix;

public:
    static Matrix_ptr multiply(Matrix_ptr left, Matrix_ptr right);

    Matrix(Matrix_ptr matrix);
    Matrix(const int &n, const int &m);
    Matrix(initializer_list<initializer_list<double>> matrix);
    //Matrix & operator = (Matrix &&);
    ~Matrix();

    int n();
    int m();

    Matrix normalize();

    Matrix_ptr to2D(double zc);
    Matrix_ptr to2D(double t, double f, double zc);

    vector<double> & operator [] (const int &i);

};

class Matrix2D : public Matrix {
public:
    static Matrix_ptr transfer(double m, double n);
    static Matrix_ptr rotate(double alpha);
    static Matrix_ptr scale(double a, double d);
    static Matrix_ptr mirror(bool horizontal, bool vertical);
    static Matrix_ptr project(double p, double q);

    Matrix2D() : Matrix(3, 3) {}
    Matrix2D(Matrix_ptr matrix) : Matrix(matrix) {}

};

class Matrix3D : public Matrix {
public:
    static Matrix_ptr transfer(double m, double n, double l);
    static Matrix_ptr rotateOx(double t);
    static Matrix_ptr rotateOy(double f);
    static Matrix_ptr rotate(double t, double f);
    static Matrix_ptr scale(double a, double d, double e);
    static Matrix_ptr mirror(bool horizontal, bool vertical, bool frontal);
    static Matrix_ptr project(double p, double q, double r);

    Matrix3D() : Matrix(4, 4) {}
    Matrix3D(Matrix_ptr matrix) : Matrix(matrix) {}

};