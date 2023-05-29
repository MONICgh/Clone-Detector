using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab_7_ThreeSumProblem
{
    public class ThreeSumTask
    {
        public List<List<int>> DoThreeSumTask(int[] nums)
        {
            var found = false;
            List<int> triples = null;
            List<int> list = null;
            var tripleList = new List<List<int>>();
            
            for (var i = 0; i < nums.Length - 1; i++) {         
                list = new List<int>();
                for (var j = i + 1; j < nums.Length; j++) {
                    found = false;
                    var x = -(nums[i] + nums[j]);
                    if (list.Contains(x)) {
                        int [] temp = {x,nums[i],nums[j]};
                        Array.Sort(temp);
                        triples = new List<int>() {temp[0], temp[1], temp[2]};
                        found = true;
                    } 
                    else list.Add(nums[j]);
                    
                    if (!found) continue;

                    triples.Sort(delegate(int val1, int val2)
                    {
                        var ind1 = Array.IndexOf(nums, val1);
                        var ind2 = Array.IndexOf(nums, val2);
                        return ind1.CompareTo(ind2);
                    });
                    
                    if (!ContainsTriple(tripleList, triples))
                    {
                        tripleList.Add(triples);
                    }
                }
            }
            
            tripleList.Sort((list1, list2) => list1[0].CompareTo(list2[0]));

            return tripleList;
        }

        private bool ContainsTriple(List<List<int>> triples, List<int> myTriple)
        {
            var answer = false;
            foreach (var triple in triples)
            {
                var isThisTripleTheSame = true;
                for (var i = 0; i < 3; i++)
                {
                    if (triple[i] != myTriple[i])
                    {
                        isThisTripleTheSame = false;
                        break;
                    }
                }

                if (isThisTripleTheSame)
                {
                    answer = true;
                }
            }

            return answer;
        }
    }
}