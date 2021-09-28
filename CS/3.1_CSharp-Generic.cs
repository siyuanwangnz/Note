//Generic class
//

public class Box<TCargo>
{
    public TCargo Cargo { get; set; }
}

public class Apple
{
    public string Color { get; set; }
}

Apple apple = new Apple(){Color = "Red"};

Box<Apple> box = new Box<Apple>(){Cargo = apple};

Console.WriteLine(box.Cargo.Color);//printout Red

//Generic interface
//

public interface INumber<T>
{
    T ID { get; set; }
}

public class Student<T>:INumber<T>
{
    public T ID { get; set; }
    public string Name { get; set; }
}

public class Student1:INumber<double>
{
    public double ID { get; set; }
    public string Name { get; set; }
}

Student<int> student = new Student<int>(){ID = 101, Name = "Tony"};
Student student1 = new Student(){ID = 101.101, Name = "Tom"};