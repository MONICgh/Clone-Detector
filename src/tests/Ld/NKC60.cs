/*var list = new List<int> { 16, 26, 34 };

var Items = list.GetEnumerator();
Console.WriteLine(Items.Current);
Items.MoveNext();
Console.WriteLine(Items.Current);
*/

var x = new
{
    Items = new List<int> { 16, 26, 34 }.GetEnumerator()
};
while (x.Items.MoveNext())
    Console.WriteLine(x.Items.Current);

/*
 
Эта программа будет писать только нули, то есть то, что находится перед первым символом.
Так как new List<int> { 1, 2, 3 } будет стерт из кучи гарбадж коллектором, так как мы не храним ссылок на него.
Теперь MoveNext() не определён и выдаёт True, а указатель не сдвигается с пространства перед первым символом.



 */
