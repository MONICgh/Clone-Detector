package main

func Levenshtain(s1 string, s2 string) int {
	n := len(s1)
	m := len(s2)

	return Max(n, m) - Min(n, m)
}
