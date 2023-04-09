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

type Detect struct {
	prosent    float64
	isClone    bool
	nameDetect string
}

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

	var diffMatching []Detect
	diffMatching = append(diffMatching,
		Detect{
			prosent:    detectTwoBlocks(dataA, dataB),
			nameDetect: "Detect dp",
		})

	diffMatching = append(diffMatching,
		Detect{
			prosent:    detectCloneLines(dataA, dataB),
			nameDetect: "Dublicate line",
		})
	if diffMatching[len(diffMatching)-1].prosent > 0.7 {
		diffMatching[len(diffMatching)-1].isClone = true
	}

	var res float64 = 1.0
	for _, m := range diffMatching {
		fmt.Println(m.nameDetect, ":", m.prosent*100, "%")
		res *= (1 - m.prosent)
	}
	matching = (1 - res) * 100

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

func max(a int, b int) int {
	if a > b {
		return a
	}
	return b
}

func min(a int, b int) int {
	return -max(-a, -b)
}
