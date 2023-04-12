package main

import (
	"fmt"
	"io"
	"log"
	"os"
	"strings"
)

const FILE_SIZE = 10 << 21
const MinMatching = 90.0

func ReadFile(fileName string) ([]byte, error) {

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

	mainFiles(os.Args[1], os.Args[2])
}

func boolAnsCloneDetect(fileA string, fileB string) bool {
	if mainFiles(fileA, fileB) >= MinMatching {
		return true
	}
	return false
}

func boolAnsCompare(dataA string, dataB string) bool {
	if Compare(dataA, dataB, "") >= MinMatching {
		return true
	}
	return false
}

func mainFiles(fileA string, fileB string) float64 {

	dataA, err := ReadFile(fileA)
	if err != nil {
		log.Println("Wrong read first file:", fileA, err)
		os.Exit(0)
	}

	dataB, err := ReadFile(fileB)
	if err != nil {
		log.Println("Wrong read second file:", fileB, err)
		os.Exit(0)
	}

	formatA := strings.Split(fileA, ".")[1]
	formatB := strings.Split(fileB, ".")[1]

	if formatA != formatB {
		log.Println("Wrong languges:", formatA, "not equale", formatB)
		os.Exit(0)
	}
	format = formatA

	return Compare(string(dataA), string(dataB), format)
}

func Compare(dataA string, dataB string, format string) float64 {

	// dataA = DeleteComments(dataA)
	// dataB = DeleteComments(dataB)

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
		// log.Printf("%v: %.2f\n", m.nameDetect, m.prosent*100)
		res *= (1 - m.prosent)
	}
	matching = (1 - res) * 100

	// log.Printf("Match Probability: %.2f\n", matching)
	return matching
}
