package main

import (
	"io/ioutil"
	"log"
	"os"
	"syscall"
	"testing"
)

var directory []string = []string{
	"La", "Lc", "Ld",
	"Lg", "Li", "Lk",
	"Lm", "Ln", "Lo",
	"Lp", "Lq", "Lu",
	"Lv", "Lw", "Lx",
	"Lz",
}

func connectConsole() {
	err := syscall.Exec("cd preprocessing", nil, nil)
	err = syscall.Exec("make", nil, nil)
	err = syscall.Exec(
		"./preprocessing",
		[]string{"input.txt", "output.txt"},
		nil,
	)

	if err != nil {
		panic(err)
	}
}

func writerTest(fileName string) {

	data, err := ReadFile(fileName)
	if err != nil {
		log.Fatal(err)
	}

	f, err := os.Create("preprocessing/input.txt")
	if err != nil {
		log.Fatal(err)
	}
	defer f.Close()
	f.Write(data)
}

func readerTest() []byte {
	data, err := ReadFile("preprocessing/output.txt")
	if err != nil {
		log.Fatal(err)
	}
	return data
}

func TestDataL(t *testing.T) {

	for _, dir := range directory {

		ass := 0

		files, err := ioutil.ReadDir("tests/" + dir)
		if err != nil {
			log.Fatal(err)
		}

		for _, fileA := range files {
			for _, fileB := range files {
				nameA, nameB := fileA.Name(), fileB.Name()
				if nameA == nameB || nameA[len(nameA)-1] != 's' || nameB[len(nameB)-1] != 's' {
					continue
				}

				writerTest("tests/" + dir + "/" + nameA)
				dataA := readerTest()

				writerTest("tests/" + dir + "/" + nameB)
				dataB := readerTest()

				if boolAnsCompare(string(dataA), string(dataB)) {
					ass++
				}

			}
		}

		log.Printf(
			"In derectory %s: %v clones found\n",
			dir,
			ass,
		)
	}
}
