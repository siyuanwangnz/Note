//Class Over Ride: polymorphism
//

public class A
{
    private int myA;
    public virtual int MyProperty  //virtual and override can be used for property
    {
        get { return myA; }
        set { myA = value; }
    }

    public virtual void Run()
    {
        Console.WriteLine("I am A")
        myA = 100;
    }
}

public class A_1: A
{
    private int myA_1;
    public override int MyProperty
    {
        get { return myA_1; }
        set { myA_1 = value; }
    }
    
    public override void Run()
    {
        Console.WriteLine("I am A_1")
        myA_1 = 200;
    }
}

public class A_1_1: A_1
{
    private int myA_1_1;
    public override int MyProperty
    {
        get { return myA_1_1; }
        set { myA_1_1 = value; }
    }

    public override void Run()
    {
        Console.WriteLine("I am A_1_1")
        myA_1_1 = 300;
    }
}

A a = new A_1();
a.Run(); //printout: I am A_1
Console.WriteLine(a.MyProperty);//printout: 200

A a = new A_1_1();
a.Run(); //printout: I am A_1_1    
Console.WriteLine(a.MyProperty);//printout: 300