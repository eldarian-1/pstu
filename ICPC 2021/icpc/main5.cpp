#include <iostream>
#include <string>
#include <vector>
using namespace std;

#define frn(a, b, c) for(int a = b; a < c; ++a)

typedef vector<string> vs;
typedef vector<int> vi;
typedef vector<vi> vvi;

/*int n, m;
string name;
vs births;
vs days;
vs months;

vi dayss = vi(32, 0);
vi monthss = vi(13, 0);
vvi errs = vvi(13, vi(32, 0));

int main() {
    cin >> n >> m;
    births = vs(n);
    days = vs(m);
    months = vs(m);
    frn(i, 0, n) cin >> name >> births[i];
    frn(i, 0, m) cin >> days[i] >> months[i];

    frn(i, 0, n) {
        int day = stoi(births[i].substr(0, 2));
        int month = stoi(births[i].substr(3, 2));
        ++dayss[day];
        ++monthss[month];
        ++errs[month][day];
    }

    frn(i, 0, m) {
        int day = stoi(days[i]);
        int month = stoi(months[i]);
        cout << (dayss[day] + monthss[month] - errs[month][day]) << endl;
    }

    return 0;
}
*/