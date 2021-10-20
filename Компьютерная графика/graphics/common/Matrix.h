#pragma once

#include <vector>
#include <memory>

class Matrix;
typedef std::vector<double> vector;
typedef std::vector<vector> matrix;

class Matrix {
private:
    matrix _m;

public:
    Matrix(Matrix& matrix);
    Matrix(const int &n, const int &m);
    Matrix(std::initializer_list<std::initializer_list<double>> matrix);
    ~Matrix();

    int n();
    int m();

    void out();
    double min(int i);
    Matrix normalize();
    Matrix to2D(double zc);
    Matrix to2D(double t, double f, double zc);

    vector & operator [] (const int &i);

    friend Matrix operator * (Matrix &left, Matrix &right);

};

Matrix transfer2D(double m, double n);
Matrix rotate2D(double alpha);
Matrix scale2D(double a, double d);
Matrix mirror2D(bool horizontal, bool vertical);
Matrix project2D(double p, double q);

Matrix transfer3D(double m, double n, double l);
Matrix rotateOx(double t);
Matrix rotateOy(double f);
Matrix rotate3D(double t, double f);
Matrix scale3D(double a, double d, double e);
Matrix mirror3D(bool horizontal, bool vertical, bool frontal);
Matrix project3D(double p, double q, double r);
