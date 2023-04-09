package main

import (
	"math"
	"testing"
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
