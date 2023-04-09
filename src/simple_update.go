package main

import (
	"strings"
)

var langComment = map[string]string{
	"cpp": "//",
	"go":  "//",
	"py":  "#",
}

var (
	format   string
	matching float32 = 0.0
)

func deleteComments(block string) string {

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
