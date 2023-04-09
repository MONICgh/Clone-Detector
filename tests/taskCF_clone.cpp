#include <iostream>
#include <algorithm>
       
using namespace std;

const int N = 2e5 + 20;
int a[N];
int t[4 * N];
char blank = ' ';

void copy(int v, int tr, int tl) {
    if (tr + 1 == tl) {
        t[v] = a[tr];
    } else {
        int tm = (tr + tl) / 2;
        copy(v * 2 + 1, tr, tm);
        copy(v * 2 + 2, tm, tl);
        t[v] = __gcd(t[v * 2 + 2], t[v * 2 + 1]);
    } 
}

int get(int v, int tr, int tl, int l, int r) {
    if (tr == l && tl == r) return t[v];
    if (l >= r) {
        return 0;
    }
        
    int tm = (tr + tl) / 2;
    return __gcd(get(v * 2 + 1, tr, tm, l, min(r, tm)), get(v * 2 + 2, tm, tl, max(l, tm), r));
}

int main() {

    freopen("in.txt", "r", stdin);
    freopen("out.txt", "w", stdout);

    int n;
    cin >> n;
    for (int i = 0; i < n; i++) {
        cin >> a[i];
    }
    copy(0, 0, n);
    int cur = 0;
    int last = -1;
    for (int i = 0; i < n; i++) {
        
        int x = a[i];
        if (x != 1) {
            int l = last, r = i;
            while (r - l > 1) {
                int m = (l + r) / 2;
                if (get(0, n, 0, m, i + 1) < i - m + 1) {
                    l = m;
                } else {
                    r = m;
                }
            }

            if (get(0, n, 0, r, i + 1) == i - r + 1) {
                cur++;
                last = i;
            }
            cout << cur << blank;
        } else {
            last = i;
            cur++;
            cout << cur << blank;
        }
    }
    return 0;        
}