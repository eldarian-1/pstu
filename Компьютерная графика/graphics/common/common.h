#pragma once

#include <vector>

extern const double PI;

struct Point {
    double x, y;
};

double get(std::vector<double> v, int p);

double a0(std::vector<double> v, int i);

double a1(std::vector<double> v, int i);

double a2(std::vector<double> v, int i);

double a3(std::vector<double> v, int i);

double f(std::vector<double> v, int i, double t);

Point calc(std::vector<double> xs, std::vector<double> ys, int i, double t);
