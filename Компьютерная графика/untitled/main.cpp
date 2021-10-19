#include <iostream>
#include <vector>
using namespace std;

struct Point {
    double x, y;
};

double get(vector<double> v, int i, int j = 0) {
    int p = i + j;
    if(p > 0 && p < v.size()) {
        return v[p];
    } else if(p < 0) {
        return v[v.size() + p];
    } else {
        return v[p - v.size()];
    }
}

double a0(vector<double> v, int i) {
    return (get(v, i - 1) + 4 * get(v, i) + get(v, i, 1)) / 6;
}

double a1(vector<double> v, int i) {
    return (-get(v, i - 1) + get(v, i, 1)) / 2;
}

double a2(vector<double> v, int i) {
    return (get(v, i - 1) - 2 * get(v, i) + get(v, i, 1)) / 2;
}

double a3(vector<double> v, int i) {
    return (-get(v, i - 1) + 3 * get(v, i) - 3 * get(v, i, 1) + get(v, i, 2)) / 6;
}

Point calc(vector<double> xs, vector<double> ys, int i, double t) {
    double x = a0(xs, i) + a1(xs, i) * t + a2(xs, i) * t * t + a3(xs, i) * t * t * t;
    t = 1 -t;
    double y = a0(ys, i) + a1(ys, i) * t + a2(ys, i) * t * t + a3(ys, i) * t * t * t;
    return {x, y};
}

int main() {
    vector<double> xs = {2, 5, 7, 9, 11, 13, 16, 13, 11, 9, 7, 5};
    vector<double> ys = {7, 9, 12, 9, 12, 9, 7, 5, 2, 5, 2, 5};
    double d = 0.1;
    cout << "<table>";
    for(int i = 0, n = xs.size(); i < n; ++i) {
        for(double t = 0.; t <= 1.; t += d) {
            Point p = calc(xs, ys, i, t);
            cout << "<tr><td>" << p.x << "</td><td>" << p.y << "</td></tr>";
        }
    }
    cout << "</table>";
    return 0;
}
