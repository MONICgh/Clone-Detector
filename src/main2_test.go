package main

import (
	"io/ioutil"
	"log"
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

func TestDataL(t *testing.T) {
	for _, dir := range directory {
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
				//ToDo nameA, nameB
			}
		}
	}
}
