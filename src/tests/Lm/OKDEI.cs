using System.Diagnostics;
using Task2;

// Я понимаю, что именование переменных здесь - не по кодстайлу, но делаю это осознанно, чтобы наглядно показать тесты
var Denis = new Person("Denis", 21);
var denis = new Person("denis", 21);
var Alla = new Person("Alla", 22);
var SOFIA = new Person("SOFIA", 12);

var persons = new List<Person>
{
    Denis,
    denis,
    Alla,
    SOFIA
};

persons.Sort(new ComparerName());

Debug.Assert(persons[3] == SOFIA);
Debug.Assert(persons[0] == Alla);

persons.Sort(new ComparerAge());

Debug.Assert(persons[0] == SOFIA);
Debug.Assert(persons[3] == Alla);

Console.WriteLine("All is Okay!");