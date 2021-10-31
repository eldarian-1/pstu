#pragma once

#include <vector>

class Matrix {
private:
    std::vector<std::vector<double>> _m;

public:
    Matrix(Matrix& matrix);
    Matrix(const int &n, const int &m);
    Matrix(std::initializer_list<std::initializer_list<double>> matrix);
    ~Matrix();

    int n();
    int m();

    Matrix normalize();
    Matrix to2D(double zc);
    Matrix to2D(double t, double f, double zc);
    Matrix vanishingPoints();

    std::vector<double> & operator [] (const int &i);
    double & operator [] (const std::pair<int, int> &pair);

    friend Matrix operator * (Matrix left, Matrix right);

    static Matrix transfer2D(double m, double n);
    static Matrix rotate2D(double alpha);
    static Matrix scale2D(double a, double d);
    static Matrix mirror2D(bool horizontal, bool vertical);
    static Matrix project2D(double p, double q);

    static Matrix transfer3D(double m, double n, double l);
    static Matrix rotateOx(double t);
    static Matrix rotateOy(double f);
    static Matrix rotate3D(double t, double f);
    static Matrix scale3D(double a, double d, double e);
    static Matrix mirror3D(bool horizontal, bool vertical, bool frontal);
    static Matrix project3D(double p, double q, double r);

private:
    static int safeIndex(const int &n, const int &i);

};
