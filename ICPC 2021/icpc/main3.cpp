#include <iostream>
#include <vector>
using namespace std;

#define frn(a, b, c) for(int a = b; a < c; ++a)

typedef vector<int> vi;
typedef vector<bool> vb;

/*int n, c = 0, j;
vi a;
vb b;

int main() {
    cin >> n;
    a = vi(n);
    b = vb(n, false);
    frn(i, 0, n) {
        cin >> a[i];
    }

    frn(i, 0, n) {
        if (b[i]) {
            continue;
        }

        int tc = c;
        for(j = i; ; j = a[j] - 1) {
            b[j] = true;
            if(++c > n || j == (a[j] - 1)) break;
        }

        if(tc != c - 1 && i == j) {
            b[0] = false;
            break;
        }

        if(c > n) {
            break;
        }
    }

    frn(i, 0, n)  if(!b[i]) {
        cout << "Poor Polina";
        return 0;
    }
    cout << "She can do everything";
    return 0;
}
*/