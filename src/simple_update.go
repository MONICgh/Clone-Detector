package main

import (
	"strings"
)

var langComment = map[string]string{
	"cpp": "//",
	"go":  "//",
	"py":  "#",
}

func DeleteComments(block string) string {

	lines := strings.Split(block, "\n")
	res := ""
	for _, s := range lines {
		i := strings.Index(s, langComment[format])
		if i != -1 {
			res += s[:i] + "\n"
		} else {
			res += s + "\n"
		}
	}
	return res
}

func AddComments(blockA []byte, blockB []byte) bool {

	return false
}

func Max(a int, b int) int {
	if a > b {
		return a
	}
	return b
}

func Min(a int, b int) int {
	return -Max(-a, -b)
}
