﻿var x = new
{
    Items = new List<int> { 1, 2, 3 }.GetEnumerator()
   
};

while (x.Items.MoveNext())
    Console.WriteLine(x.Items.Current);


/* Данный код будет бесконечно выводить 0. Свойство Items имеет модификатор readonly, 
каждый раз при обращении к Items будет создаваться новоя копия структуры List<int>.Enumerator. Строка 7: создается коопия,
перечислитель изначально располагается перед первым элементом коллекции, поэтому MoveNext() возвращает True. Строка 8: опять создается
новая копия, перечислитель перед первым элементом, значение свойства Current не определено, и в него присваивается значение по умолчанию
для int, т.е. 0. Итог: получаем бесконечную последоватеьность нулей. Ниже представлен корректный код.*/

var m = x.Items;
while (m.MoveNext())
    Console.WriteLine(m.Current); // 1, 2, 3


