package main

import (
	"math"
	"testing"
)

const EPS_PROSSENT = 2.5

type testCase struct {
	dataFirst string, 
	dataSecond string, 
	format string,
	matching float32,
}

func TestComment(t *testing.T) {
	for _, input := range []testCase{
		{
			dataFirst: "#include <iostream>

			using namespace std;
			
			int main (){
			
				int a, b = 0;
				cout << a + b;
			
				return 0;
			}",
			dataSecond: "#include <iostream>

			using namespace std;
			
			int main (){
			
				int a, b = 0;//lalala
				cout << a + b;
				//lololo
				return 0;
			}",
			format: "cpp",
			matching: 100.0,
		},
		{
			dataFirst: "
			a = int(input())
			a += 1
			print(a**2)",
			dataSecond: "
			a = int(input())#input data
			a += 1#plus one
			print(a**2)#in req",
			format: "py",
			matching: 100.0,
		},
	} {
		out := Compare(input.dataFirst, input.dataSecond, input.format)
		if abs(out - input.matching) > EPS_PROSSENT {
			t.Errorf("Acc: %d\n Exs: %d\n", out, input.matching)
		}
	}
}
