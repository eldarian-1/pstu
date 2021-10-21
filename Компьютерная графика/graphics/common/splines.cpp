#include "splines.h"

using namespace std;

extern const double PI = 3.1415926535;

double get(vector<double> v, int p) {
    if(p >= 0 && p < v.size()) {
        return v[p];
    } else if(p < 0) {
        return v[v.size() + p];
    } else {
        return v[p - v.size()];
    }
}

double a0(vector<double> v, int i) {
    return (get(v, i - 1) + 4 * get(v, i) + get(v, i + 1)) / 6;
}

double a1(vector<double> v, int i) {
    return (-get(v, i - 1) + get(v, i + 1)) / 2;
}

double a2(vector<double> v, int i) {
    return (get(v, i - 1) - 2 * get(v, i) + get(v, i + 1)) / 2;
}

double a3(vector<double> v, int i) {
    return (-get(v, i - 1) + 3 * get(v, i) - 3 * get(v, i + 1) + get(v, i + 2)) / 6;
}

double f(vector<double> v, int i, double t) {
    return ((a3(v, i) * t + a2(v, i)) * t + a1(v, i)) * t + a0(v, i);
}

Point calc(vector<double> xs, vector<double> ys, int i, double t) {
    double x = f(xs, i, t);
    double y = f(ys, i, t);
    return {x, y};
}