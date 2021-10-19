#include <iostream>
#include <string>
using namespace std;

#define frn(a, b, c) for(int a = b; a < c; ++a)

int c = 0;
bool caps = false;
string s;

/*int main() {
    cin >> s;
    frn(i, 0, s.length()) {
        if('a' <= s[i] && s[i] <= 'z' && caps) {
            ++c;
            caps = false;
        } else if('A' <= s[i] && s[i] <= 'Z' && !caps) {
            ++c;
            caps = true;
        }
    }
    cout << c;
    return 0;
}*/
