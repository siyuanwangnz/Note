//Dependency injection and Reflections
//

public interface IVehicle
{
    void Run();
}

public class Car:IVehicle
{
    public void Run()
    {
        Console.WriteLine("car is running")
    }
}

public class Driver
{
    private IVehicle _vehicle;
    public Driver(IVehicle vehicle)
    {
        _vehicle = vehicle;
    }
    public void Drive()
    {
        _vehicle.Run();
    }
}

IVehicle car = new Car();
//++++++++++++++++dependency injection++++++++++++++++
var t = car.GetType();  //get type
object o = Activator.CreateInstance(t); //create instrance of type
MethodInfo RunMi = t.GetMethod("Run"); //get method
RunMi.Invoke(o,null);

//or install dependency injection dependencies
using Microsoft.Extensions.DependencyInjection;
//register
var sc = new ServiceCollection();
sc.AddScoped(typeof(IVehicle),typeof(Car)); //similar to IVehicle car = new Car();
sc.AddScoped<Driver>(); //similar to IVehicle car = new Car(); then var driver = new Driver(car);
var sp = sc.BuilServiceProvider();
//using 
IVehicle car = sp.GetService<IVehicle>();
car.Run();

//or
var driver = sp.GetService<Driver>(); //create a instance of Driver and then look for instance of Ivehicle type for constructor which already registered by Car 
driver.Drive();
