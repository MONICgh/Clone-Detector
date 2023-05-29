using System.Diagnostics;
using Task3;

Debug.Assert(StringDifference.Apply("a", "a"));
Debug.Assert(StringDifference.Apply("ab", "a"));
Debug.Assert(StringDifference.Apply("a", "ab"));
Debug.Assert(StringDifference.Apply("ab", "ab"));
Debug.Assert(StringDifference.Apply("ba", "a"));
Debug.Assert(StringDifference.Apply("a", "ba"));
Debug.Assert(StringDifference.Apply("aba", "aba"));
Debug.Assert(StringDifference.Apply("aba", "aa"));
Debug.Assert(StringDifference.Apply("aa", "aba"));
Debug.Assert(StringDifference.Apply("aba", "aca"));
Debug.Assert(StringDifference.Apply("aba", "abc"));
Debug.Assert(StringDifference.Apply("abc", "aba"));
Debug.Assert(!StringDifference.Apply("aba", "aab"));
Debug.Assert(!StringDifference.Apply("aba", "a"));
Debug.Assert(!StringDifference.Apply("a", "aab"));
Debug.Assert(!StringDifference.Apply("aba", "cbc"));
Debug.Assert(!StringDifference.Apply("aba", "abaaa"));

Console.WriteLine("All is Okay!");