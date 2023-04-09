#include <bits/stdc++.h>
       
using namespace std;
 
const int N = 2e5 + 15;
int t[4 * N];
int a[N];

void make(int v, int tl, int tr) {
    if (tl + 1 == tr) {
        t[v] = a[tl];
    } else {
        int tm = (tl + tr) / 2;
        make(v * 2 + 1, tl, tm);
        make(v * 2 + 2, tm, tr);
        t[v] = __gcd(t[v * 2 + 1], t[v * 2 + 2]);
    }        
}
        
int get(int v, int tl, int tr, int l, int r) {
    if (tl == l && tr == r) {
        return t[v];
    }
    if (l >= r) return 0;
        
    int tm = (tl + tr) / 2;
    return __gcd(get(v * 2 + 1, tl, tm, l, min(r, tm)), get(v * 2 + 2, tm, tr, max(l, tm), r));
}

    
int main() {

    freopen("in.txt", "r", stdin);
    freopen("out.txt", "w", stdout);

    int n;
    cin >> n;
    for (int i = 0; i < n; i++) {
        cin >> a[i];
    }
    make(0, 0, n);
    int last = -1;
    int cur = 0;
    for (int i = 0; i < n; i++) {
        
        int x = a[i];
        if (x == 1) {
            last = i;
            cur++;
            cout << cur << ' ';
            continue;
        }

        int l = last, r = i;
        while (r - l > 1) {
            int m = (l + r) / 2;
            if (get(0, 0, n, m, i + 1) >= i - m + 1) r = m;
            else l = m;
        }

        if (get(0, 0, n, r, i + 1) == i - r + 1) {
            last = i;
            cur++;
        }
        cout << cur << ' ';
    }
    return 0;        
}