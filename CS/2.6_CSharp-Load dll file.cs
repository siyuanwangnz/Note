//using reflection to load class in dll file
using System.IO;
using System.Runtime.Loader;

var folder = Path.Combine(Environment.CurrentDirectory,"Animals"); // get path of folder named animals
var files = Directory.GetFiles(folder);//get all dll file
var animalsTypes = new List<Type>();//declare a Tpye type list to store type of class
foreach (var file in files)//get each file
{
    var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(file);
    var types = assembly.GetTypes();//get all type of class
    foreach (var t in types)// get all class that have Voice funciton
    {
        if(t.GetMethod("Voice")!=null)
        {
            animalsType.Add(t);
        }
    }
}

int times = 10;
var t = animalsTypes[0];//get #0 class
var m = t. GetMethod("Voice");//get Vocie funciton
var o = Activator.CreateInstance(t);//create a instance object by #0 class
m.Invoke(o,new object[]{times});

//dll file created by class library 
//add two class
public class Sheep
{
    public void Voice(int times)
    {
        for(int i = 0; i < times; i++)
        {
            Console.WriteLine("Baa...")
        }
    }
}

public class Dog
{
    public void Voice(int times)
    {
        for(int i = 0; i < times; i++)
        {
            Console.WriteLine("Woof...")
        }
    }
}

//using SDK and interface 
//

//interface in created class llibrary
public interface IAnimal
{
    void Voice(int times);
}
//class in created class llibrary
public UnfinishedAttribute:Attribute
{

}

//Change class using interface in dll
public class Sheep:IAnimal
{
    public void Voice(int times)
    {
        for(int i = 0; i < times; i++)
        {
            Console.WriteLine("Baa...")
        }
    }
}

public class Dog:IAnimal
{
    [Unfinished]
    public void Voice(int times)
    {
        for(int i = 0; i < times; i++)
        {
            Console.WriteLine("Woof...")
        }
    }
}

//change foreach (var t in types) to
foreach (var t in types)
{
    if(t.GetInterfaces().Contains(typeof(IAnimal)))
    {
        var isUnfinished = t.GetCustomAttribute(false).Any(a=>a.GetType() == typeof(UnfinishedAttribute));
        if(isUnfinished)continue;
        animalsTypes.Add(t);
    }
}

//change m.Invoke(o,new object[]{times}); to 
var a = o as IAnimal;
a.Voice(times);