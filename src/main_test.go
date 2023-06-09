package main

import (
	"encoding/json"
	"log"
	"math"
	"os"
	"strings"
	"testing"

	"github.com/stretchr/testify/assert"
)

const EPS_PROSSENT float64 = 2.5
const MaxCountTest = 415416

type testCase struct {
	dataFirst  string
	dataSecond string
	format     string
	matching   float64
}

func TestComment(t *testing.T) {
	for _, input := range []testCase{
		{
			dataFirst:  "#include",
			dataSecond: "#include <iostream>",
			format:     "cpp",
			matching:   100.0,
		},
		{
			dataFirst:  "print(a**2)",
			dataSecond: "print(a**2)#in req",
			format:     "py",
			matching:   100.0,
		},
	} {
		out := Compare(input.dataFirst, input.dataSecond, input.format)
		if math.Abs(out-input.matching) > EPS_PROSSENT {
			t.Errorf("Acc: %v\n Exs: %v\n", out, input.matching)
		}
	}
}

func TestSimpleDataBase(t *testing.T) {
	assert := assert.New(t)
	assert.False(
		boolAnsCloneDetect(
			"../CodeXGLUE/Code-Code/code-refinement/evaluator/predictions.txt",
			"../CodeXGLUE/Code-Code/code-refinement/evaluator/references.txt",
		))
	assert.True(
		boolAnsCloneDetect(
			"../tests/taskCF.cpp",
			"../tests/taskCF_clone.cpp",
		))
	assert.False(
		boolAnsCloneDetect(
			"main.go",
			"simple_update.go",
		))
}

type CodeProgramm struct {
	Code string `json:"func"`
	Idx  string `json:"idx"`
}

type Test struct {
	indFirst  string
	indSecond string
	ans       bool
}

func readJSONL(fileName string) map[string]string {
	dataBase := make(map[string]string)

	data, err := ReadFile(fileName)
	if err != nil {
		log.Println("Wrong data base file:", fileName, err)
		os.Exit(0)
	}

	listJSON := strings.Split(string(data), "\n")
	for _, elem := range listJSON {

		var code CodeProgramm
		json.Unmarshal([]byte(elem), &code)
		dataBase[code.Idx] = code.Code
	}

	return dataBase
}

func readTest(fileName string, maxCountTest int, stringStartPar ...int) []Test {
	var listTest []Test

	data, err := ReadFile(fileName)
	if err != nil {
		log.Println("Wrong test file read:", fileName, err)
		os.Exit(0)
	}

	stringStart := 0
	if len(stringStartPar) > 0 {
		stringStart = stringStartPar[0]
	}

	for i, elem := range strings.Split(string(data), "\n") {

		if i >= stringStart+maxCountTest {
			break
		}

		elems := strings.Fields(elem)

		if len(elems) != 3 {
			log.Println("Wrong size test", elem, " i: ", i)
			os.Exit(0)
		}

		if i >= stringStart {
			oneTest := Test{
				indFirst:  elems[0],
				indSecond: elems[1],
			}

			if elems[2] == "1" {
				oneTest.ans = true
			} else {
				oneTest.ans = false
			}

			listTest = append(listTest, oneTest)
		}
	}

	return listTest
}

func DataBase(t *testing.T, fileName string, maxCountTest int, stringStartPar ...int) {
	dataBase := readJSONL("../CodeXGLUE/Code-Code/Clone-detection-BigCloneBench/dataset/data.jsonl")
	if len(dataBase) < 9127 {
		log.Println("Not read all data base")
		os.Exit(0)
	}

	tests := readTest("../CodeXGLUE/Code-Code/Clone-detection-BigCloneBench/dataset/"+fileName, maxCountTest, stringStartPar...)

	ass := 0
	for _, test := range tests {
		if boolAnsCompare(
			dataBase[test.indFirst],
			dataBase[test.indSecond],
		) == test.ans {
			ass++
		}
	}

	log.Printf("%.2f\n", float64(ass)/float64(len(tests))*100)
}

func DataBaseResearch(t *testing.T, fileName string, maxCountTest int, stringStartPar ...int) {
	dataBase := readJSONL("../CodeXGLUE/Code-Code/Clone-detection-BigCloneBench/dataset/data.jsonl")
	if len(dataBase) < 9127 {
		log.Println("Not read all data base")
		os.Exit(0)
	}

	tests := readTest("../CodeXGLUE/Code-Code/Clone-detection-BigCloneBench/dataset/"+fileName, maxCountTest, stringStartPar...)

	amountTT, amountFF, amountTF, amountFT := 0, 0, 0, 0
	for _, test := range tests {
		ansAlgorithm := boolAnsCompare(
			dataBase[test.indFirst],
			dataBase[test.indSecond],
		)
		switch {
		case ansAlgorithm && test.ans:
			amountTT++
		case !ansAlgorithm && !test.ans:
			amountFF++
		case !ansAlgorithm && test.ans:
			amountFT++
		case ansAlgorithm && !test.ans:
			amountTF++
		}
	}

	log.Printf(
		"\nTT : %.2f\nFF : %.2f\nTF : %.2f\nFT : %.2f\n",
		float64(amountTT)/float64(len(tests))*100,
		float64(amountFF)/float64(len(tests))*100,
		float64(amountTF)/float64(len(tests))*100,
		float64(amountFT)/float64(len(tests))*100,
	)
}

func TestDataBaseTest(t *testing.T) {
	// DataBase(t, "test.txt", MaxCountTest)
	DataBaseResearch(t, "test.txt", MaxCountTest)
}

func TestDataBaseTrain(t *testing.T) {
	// DataBase(t, "train.txt", 700000)
	DataBaseResearch(t, "train.txt", 201000, 700001)
}

func TestDataBaseValid(t *testing.T) {
	DataBaseResearch(t, "valid.txt", MaxCountTest)
}
