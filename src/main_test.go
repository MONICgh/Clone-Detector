package main

import (
	"math"
	"testing"

	"github.com/stretchr/testify/assert"
)

const EPS_PROSSENT float64 = 2.5

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
	assert.True(
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
