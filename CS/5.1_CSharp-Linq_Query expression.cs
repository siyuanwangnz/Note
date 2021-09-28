//Linq Query
//
using System.Linq

int[] numbers = new int[]{1,34,56,76,2,5,7};

IEnumerable<int> result = numbers.Take(3);

foreach(var item in result)
{
    Console.WriteLine(item.ToString());
}
//printout 1 34 56

Console.WriteLine($"Average: {numbers.Take(4).Average():F2}");
//print out average of 1 34 56 76 

//from
var result = 
    from a in numbers
    where a>50 && a<70
    select a+100;//or $"{a}"
foreach (var item in result)
{
    Console.WriteLine($"{item}");
}
//printout 156 
var result = 
    from a in numbers//source
    where a>50//condition
    orderby a ascending//ordering
    select a;//return
foreach (var item in result)
{
    Console.WriteLine($"{item}");
}
//printout 56 76

//Usage
var animals = new[]
{
    new{Name="Dog",Age=3,Type="Home"},
    new{Name="Cat",Age=1,Type="Home"},
    new{Name="Wolf",Age=2,Type="Wild"},
    new{Name="Monkey",Age=4,Type="wild"},
};

var result = 
    from a in animals
    where a.Type == "Wild"
    orderby a.Age descending
    select $"{a.Name}, Age{a.Age}"

foreach (var item in result)
{
    Console.WriteLine(item);
}
//printout Monkey, 4 Wolf, 2