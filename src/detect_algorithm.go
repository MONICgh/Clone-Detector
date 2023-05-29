package main

import "strings"

// prosent: len(match)/len(block)
// s, t -- string: code clone
func detectTwoBlocks(s string, t string) float64 {

	var notSee map[rune]bool = map[rune]bool{
		' ':  true,
		'\n': true,
		'\t': true,
	}

	var dp [][]int
	// var dp [len(s)+1][len(t)+1]int
	for i := 0; i <= len(s); i++ {
		var list []int
		for j := 0; j <= len(t); j++ {
			list = append(list, 0)
		}
		dp = append(dp, list)
	}

	for i, symFirst := range s {
		for j, symSec := range t {
			dp[i+1][j+1] = Max(dp[i][j+1], dp[i+1][j])
			if symFirst == symSec && !notSee[symFirst] {
				dp[i+1][j+1] = Max(dp[i+1][j+1], dp[i][j]+1)
			}
		}
	}

	var minStr string
	if len(s) < len(t) {
		minStr = s
	} else {
		minStr = t
	}
	lenNotBlank := 0
	for _, sym := range minStr {
		if !notSee[sym] {
			lenNotBlank++
		}
	}

	return float64(dp[len(s)][len(t)]) / float64(lenNotBlank)
}

func detectCloneLines(s string, t string) float64 {

	linesA := strings.Split(s, "\n")
	linesB := strings.Split(t, "\n")

	res := 0
	all := 0
	for _, lineA := range linesA {
		if lineA != "" {
			all++
		}
		for _, lineB := range linesB {
			if lineA == lineB && lineA != "" {
				res++
				continue
			}
		}
	}

	return float64(res) / float64(all)
}

func detectCloneLineWithLevenshtain(s string, t string) float64 {
	numClone := Levenshtain(s, t)
	return float64(numClone) /
		float64(Max(len(strings.Split(s, "\n")), len(strings.Split(t, "\n"))))
}
