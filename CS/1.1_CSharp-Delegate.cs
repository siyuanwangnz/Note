//Delegate:
//

//Declare a delegate type
public delegate int Calc(int a, int b);

//Declare a Generic delegate type
public delegate T GenCalc<T>(T a, T b);

//Example:
class Calculator
{
    public void Report() 
    { 
        Console.WriteLine("Hello World")
    }

    public int Add(int a, int b)
    {
        int result = a + b;
        return result;
    }

    public int Sub(int a, int b)
    {
        int result = a - b;
        return result;
    }

    public double DoubleAdd(double a, double b)
    {
        return a + b;
    }

}

Calculator calculator = new Calculator();

//Action:
Action action = new Action(calculator.Report);
action.Invoke();  // or action();

//Func:
Func<int, int, int> /*var*/ func = new Func<int, int, int>(calculator.Add); // front two int types is parameter, last int type is return//Func<int, int, int> could change to var
//or
var func = Func<int, int, int>((/*int*/ a ,/*int*/ b) => { resturn a + b }); //lambda
//or
Func<int, int, int> func = (a, b) => { resturn a +b };

int result = func.Invoke(1, 2); // or func(1,2);

//Calc:
Calc calc = new Calc(calculator.Add); //declare a delegate field
calc += calculator.Sub; //delegate is able to include multi function
calc.Invoke(1, 2);

//Generic GenCalc:
GenCalc<double> gencalc = new GenCalc<double>(calculator.DoubleAdd);
gencalc.Invoke(2.3, 5.6);

//Using: as template and callback //Conclusion: use delegate as paramater of function and then run delegate (xxx.invoke) in the fucntion;
//
class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
}

class Box
{
    public Product Product { get; set; }
}

class WrapFactory
{
    public Box WrapProduct(Func<Product> getProduct, Action<Product> callback) //delegate as parameter
    {
        Box box = new Box();
        Product product = getProduct.Invoke(); //run delegate

        if (product.Price > 50)
        {
            callback.Invoke(product); //run delegate
        }

        box.Product = product;
        return box;
    }
}

class ProductFactory
{ 
    public Product Apple ()
    {
        Product product = new Product();
        product.Name = "Apple";
        product.Price = 20;
        return Product;
    }

    public Product Banana()
    {
        Product product = new Product();
        product.Name = "Banana";
        product.Price = 100;
        return Product;
    }
}

class Caller
{
    public void Call(Product product)
    {
        Console.WriteLine($"{product.Name}");
    }
}

ProductFactory productFactory = new ProductFactory();
WrapFactory wrapFactory = new WrapFactory();
Caller caller = new Caller();

Func<Product> func1 = new Func<Product>(productFactory.Apple);
Func<Product> func2 = new Func<Product>(productFactory.Banana);
Action<Product> action = new Action<Product>(Caller.Call);

Box box1 = wrapFactory.WrapProduct(func1, action);
Box box2 = wrapFactory.WrapProduct(func2, action);

//Lambda and generic
//
Function/* <int> */((/*int*/ a, /*int*/ b) => { return a + b}, 100, 200);

static void Function<T>(Func<T,T,T> func,T x, T y)
{
    T result = func(x, y);
}
