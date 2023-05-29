using System;
using System.Collections.Generic;

namespace CSDotNet.Lab3
{
    internal class WhatIsHappening
    {
        //static void Main(string[] args)
        //{
        //    var x = new
        //    {
        //        Items = new List<int> { 1, 2, 3 }.GetEnumerator() // структура, только для чтения
        //    };
        //    while (x.Items.MoveNext()) // Здесь берётся новый энумератор и двигается вперёд
        //        Console.WriteLine(x.Items.Current); // Здесь снова берётся новый энумератор и даёт элемент перед нулевым

        //    // Вывод - бесконечные строки нулей.
        //    // x.Items каждый раз передаётся по значению, потому x.Items.MoveNext() модифицирует лишь значение внутри условия цикла.
        //    // В теле цикла снова берётся исходное значение, не сдвинувшееся вперёд, потому пишется 0.
        //    // Каждый раз проверка условия в цикле даёт true, т.к. MoveNext() всегда двигает новый энумератор на нулевой элемент списка.
        //}
    }
}
