#pragma once

#include <vector>
using namespace std;

struct Point {
    double x, y;
};

double get(vector<double> v, int p);

double a0(vector<double> v, int i);

double a1(vector<double> v, int i);

double a2(vector<double> v, int i);

double a3(vector<double> v, int i);

double f(vector<double> v, int i, double t);

Point calc(vector<double> xs, vector<double> ys, int i, double t);
