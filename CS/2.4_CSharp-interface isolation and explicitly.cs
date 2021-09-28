//interface inheritance and isolation
//

public interface IVehicle
{
    void Run();
}

public interface IWeapon
{
    void fire();
}

public class Car:IVehicle
{
    public void Run()
    {
        Console.WriteLine("car is running")
    }
}

public class Tank:IVehicle,IWeapon
{
    public void Run()
    {
        Console.WriteLine("tank is running")
    }

    public void fire()
    {
        Console.WriteLine("tank is firing")
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

var driver = new Driver(new Car());
driver.Drive();//printout car is running
var driver1 = new Driver(new Tank());
driver1.Drive();//printout tank is running

//interface explicitly
//

public class Tank_explicity:IVehicle,IWeapon
{
    public void Run()
    {
        Console.WriteLine("tank_explicitly is running")
    }

    public void IWeapon.Fire() //explicitly
    {
        Console.WriteLine("tank_explicitly is firing")
    }
}

var tank_explicitly = new Tank_explicity();
tank_explicitly.Run();//printout tank_explicitly is running //Fire() is not allow to use

IWeapon weapon_tank = tank_explicitly;
weapon_tank.Fire();//printout tank_explicitly is firing

IWeapon weapon_tank1 = new Tank_explicity();
weapon_tank1.Fire();//printout tank_explicitly is firing

//or
var weapon_tank2 = weapon_tank1 as Tank_explicity;
weapon_tank2.Run();//printout tank_explicitly is running