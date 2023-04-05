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
	matching float32 = 0.0
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

func Compare(dataA string, dataB string, format string) float32 {

	if dataA == dataB {
		matching = 100.0
	}

	fmt.Println("Match Probability: ", matching, "%")
	return matching
}
