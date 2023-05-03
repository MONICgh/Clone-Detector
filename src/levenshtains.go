package main

import "strings"

func Levenshtain(s1 string, s2 string) int {
	m := len(strings.Split(s2, "\n"))

	// init
	var dp [][]int
	var list1 []int
	var list2 []int
	for j := 0; j <= m; j++ {
		list1 = append(list1, j)
	}

	list2 = append(list2, 1)
	for j := 1; j <= m; j++ {
		list2 = append(list2, 0)
	}

	dp = append(dp, list1)
	dp = append(dp, list2)

	for i, si := range strings.Split(s1, "\n") {
		for j, sj := range strings.Split(s2, "\n") {
			dp[1][j+1] = Min(dp[0][j+1], dp[1][j]) + 1
			if si == sj {
				dp[1][j+1] = Min(dp[1][j+1], dp[0][j])
			} else {
				dp[1][j+1] = Min(dp[1][j+1], dp[0][j]+1)
			}
		}

		for j := 0; j <= m; j++ {
			dp[0][j] = dp[1][j]
			dp[1][j] = 0
		}
		dp[1][0] = i + 2
	}

	return dp[0][m]
}
