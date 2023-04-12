package main

import "strings"

func Levenshtain(s1 string, s2 string) int {
	n := len(strings.Split(s1, "\n"))
	m := len(strings.Split(s2, "\n"))

	var dp [][]int

	for i := 0; i <= n; i++ {
		var list []int
		for j := 0; j <= m; j++ {
			if i == 0 {
				list = append(list, j)
			} else if j == 0 {
				list = append(list, i)
			} else {
				list = append(list, 0)
			}
		}
		dp = append(dp, list)
	}

	for i, si := range strings.Split(s1, "\n") {
		for j, sj := range strings.Split(s2, "\n") {
			dp[i+1][j+1] = Min(dp[i][j+1], dp[i+1][j]) + 1
			if si == sj {
				dp[i+1][j+1] = Min(dp[i+1][j+1], dp[i][j])
			} else {
				dp[i+1][j+1] = Min(dp[i+1][j+1], dp[i][j]+1)
			}
		}
	}

	return dp[n][m]
}
