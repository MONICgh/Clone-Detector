// See https://aka.ms/new-console-template for more information

using Task3;

var id = new F(x => x);
var sq = new F(x => x * x);
var sin = new F(Math.Sin);

Console.WriteLine("int_0^1 x dx = ~" + Integrator.Integrate(id, 0, 1));
Console.WriteLine("int_0^1 x^2 dx = ~" + Integrator.Integrate(sq, 0, 1));
Console.WriteLine("int_0^1 sin(x) dx = ~" + Integrator.Integrate(sin, 0, 1));