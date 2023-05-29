using System;
using System.Collections.Generic;

namespace TwoLinkedLists;

public class TwoLinkedLists<T> where T: IComparable
{
    public static LinkedListNode<T>? FindFirstIntersection(LinkedList<T> firstList, LinkedList<T> secondList)
    {
        var invertedFirstList = new LinkedList<T>();
        var invertedSecondList = new LinkedList<T>();
        foreach (var item in firstList)
        {
            invertedFirstList.AddFirst(item);
        }
        foreach (var item in secondList)
        {
            invertedSecondList.AddFirst(item);
        }

        LinkedListNode<T>? result = null;
        while (true)
        {
            if (invertedFirstList.Count == 0 || invertedSecondList.Count == 0)
            {
                return result;
            }
            
            if (Equals(invertedFirstList.First!.ValueRef, invertedSecondList.First!.ValueRef))
            {
                result = invertedFirstList.First;
                invertedFirstList.RemoveFirst();
                invertedSecondList.RemoveFirst();
            }
            else
            {
                return result;
            }
        }
    }
}
