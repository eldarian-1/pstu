#include <iostream>
#include <vector>
using namespace std;

#define frn(a, b, c) for(int a = b; a < c; ++a)

typedef vector<int> vi;
typedef vector<bool> vb;

int n;
vi a, b;

int res(int x, int i) {
    return (a[i] * x + b[i]);
}

int res(vi paths) {
    int r = 1;
    frn(i, 0, n) {
        if(paths[i] < 0) continue;
        r = res(r, paths[i]);
    }
    return r;
}

vb setBusy(vb busy, int i) {
    busy[i] = true;
    return busy;
}

vi setPath(vi paths, int i, int p) {
    paths[i] = p;
    return paths;
}

vi f(int i, vb busy, vi path) {
    if(i == n) return path;
    vi r;
    int s = 0;
    frn(j, 0, n) {
        if(busy[j]) {
            continue;
        }
        vi tpath = f(i + 1, setBusy(busy, j), setPath(path, i, j));
        int tsum = res(tpath);
        if(s < tsum) {
            s = tsum;
            r = tpath;
        }
    }
    return r;
}

int main() {
    cin >> n;
    a = vi(n);
    b = vi(n);
    frn(i, 0, n) cin >> a[i] >> b[i];
    vi r = f(0, vb(n, false), vi(n, -1));
    frn(i, 0, n) cout << (r[i] + 1) << " ";
    return 0;
}
