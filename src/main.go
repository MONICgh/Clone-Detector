package main

import (
	"fmt"
	"io"
	"log"
	"os"
	"strings"
)

const FILE_SIZE = 10 << 15

func readFile(fileName string) ([]byte, error) {

	f, err := os.Open(fileName)

	if err != nil {
		return nil, err
	}
	defer f.Close()
	buf := make([]byte, FILE_SIZE)
	for {
		n, err := f.Read(buf)
		switch err {
		case io.EOF:
			break
		case nil:
			return buf[:n], nil
		default:
			fmt.Println(err)
			continue
		}
	}
}

var (
	format   string
	matching float64 = 0.0
)

func main() {

	if len(os.Args) < 3 {
		log.Println("Need two file data")
		os.Exit(0)
	}

	dataA, err := readFile(os.Args[1])
	if err != nil {
		log.Println("Wrong read first file:", os.Args[1], err)
	}
	dataB, err := readFile(os.Args[2])
	if err != nil {
		log.Println("Wrong read second file:", os.Args[2], err)
	}

	formatA := strings.Split(os.Args[1], ".")[1]
	formatB := strings.Split(os.Args[2], ".")[1]

	if formatA != formatB {
		log.Println("Wrong languges:", formatA, "not equale", formatB)
		os.Exit(0)
	}
	format = formatA

	Compare(string(dataA), string(dataB), format)
}

func Compare(dataA string, dataB string, format string) float64 {

	// if dataA == dataB {
	// 	matching = 100.0
	// }

	matching = detectTwoBlocks(dataA, dataB) * 100

	fmt.Println("Match Probability: ", matching, "%")
	return matching
}

func splitCodeByBlocks(code string) []string {
	panic("Split code on blocs")
}

// prosent: len(match)/len(block)
// s, t -- string: code clone
func detectTwoBlocks(s string, t string) float64 {

	var notSee map[rune]bool = map[rune]bool{
		' ':  true,
		'\n': true,
		'\t': true,
	}

	var dp [][]int
	// add normal inisalisation
	for i := 0; i <= len(s); i++ {
		var list []int
		for j := 0; j <= len(t); j++ {
			list = append(list, 0)
		}
		dp = append(dp, list)
	}

	for i, symFirst := range s {
		for j, symSec := range t {
			dp[i+1][j+1] = max(dp[i][j+1], dp[i+1][j])
			if symFirst == symSec && !notSee[symFirst] {
				dp[i+1][j+1] = max(dp[i+1][j+1], dp[i][j]+1)
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

func max(a int, b int) int {
	if a > b {
		return a
	}
	return b
}

func min(a int, b int) int {
	return -max(-a, -b)
}
