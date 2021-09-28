//Abstract
//

public abstract class A
{
    public abstract void Run();

    public void Stop()
    {
        Console.WriteLine("I am not A")
    }

}

public class A_1: A
{
    public override void Run()
    {
        Console.WriteLine("I am A_1")
    }

}

A a = new A_1();
a.Stop();//printout: I am not A
a.Run(); //printout: I am A_1

//Interface
//

interface IA //interface -> abstract -> virtual ->override（instance）, they can also modifies property
{
    public int MyProperty { get; set; }
    void Run(); //must be public
    void Stop();
}

abstract class A : IA
{
    void Run()
    {
        Console.WriteLine("I am A")
    }

    abstract void Stop(); //must be not private
}

public class A_1:A
{
    public override void Stop()
    {
        Console.WriteLine("I am not A_1")
    }
}

A a = new A_1();
a.Run(); //printout: I am A
a.Stop();//printout: I am A_1

//Using
//

int[] nums1 = new int[]{1,2,3,4,5};
ArrayList nums2 = new ArrayList{1,2,3,4,5};

static int Sum(IEnumerable nums)
{
    int sum =0;
    foreach（var n in nums) sum +=(int)n;
    retuen sum;
}

static double Avg(IEnumerable nums)
{
    int sum =0; double count = 0;
    foreach(var n in nums) {sum += (int)n;count++}
    retuen sum/count;
}

Console.WriteLine(Sum(nums1));
Console.WriteLine(Avg(nums2));

//Declare interface to use
//

interface IPhone
{
    void Call();
    void Message();
}

public class IOSPhone:IPhone
{
    public void Call()
    {
        Console.WriteLine("Call from IOSPhone");
    }
}

public class AndroidPhone:IPhone
{
    public void Call()
    {
        Console.WriteLine("Call from AndroidPhone");
    }
}

public class PhoneUser
{
    private Iphone _phone;
    public PhoneUser(IPhone phone)
    {
        _phone = phone;
    }

    public void UsePhone()
    {
        _phone.Call();
        _phone.Message();
    }
}

PhoneUser phoneuser = new PhoneUser(new IOSPhone());
phoneuser.UsePhone(); //printout: Call from IOSPhone