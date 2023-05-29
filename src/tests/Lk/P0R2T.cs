// See https://aka.ms/new-console-template for more information

using Task2;

ImplClass implClass = new ImplClass();

Console.WriteLine(implClass.Info());
Console.WriteLine(((Interface1) implClass).Info());
Console.WriteLine(((Interface2) implClass).Info());