//Parameter
//

//Value type: int, double, emum, struct, null
//Reference type: class, interface, array, delegate

//value parameter 
//
//Value type by value parameter 
int Value = 10;

static void AddOne(int value)//copy value to new memory
{
    value = value + 1;
}

Add(Value);
Console.WriteLine(Value);//Value is still 10

//Reference type as value parameters (new)
public class Student
{
    public string Name { get; set; }     
}

static void ChangeName(Student student)//copy pointer to new memory
{
    student = new Student();//new memory point to new object
    student.Name = "Tom";
}

Student student = new Student(){Name = "Mike"};
ChangeName(student);
Console.WriteLine(student.Name);//student.Name is still Mike

//Reference type as value parameters 
public class Student
{
    public string Name { get; set; }     
}

static void ChangeName(Student student) //copy pointer to new memory
{
    student.Name = "Tom";//new memory still point to old object
}

Student student = new Student(){Name = "Mike"};
ChangeName(student);
Console.WriteLine(student.Name);//student.Name is Tom

//Reference parameter
//
//Value type by reference parameter 
int Value = 10;

static void AddOne(ref int value)//true memory of value
{
    value = value + 1;
}

Add(ref Value);
Console.WriteLine(Value);//Value is 11

//Reference type as reference parameters (new)
public class Student
{
    public string Name { get; set; }     
}

static void ChangeName(ref Student student)//true memory of pointer
{
    student = new Student();//true memory pointer to new object
    student.Name = "Tom";
}

Student student = new Student(){Name = "Mike"};
ChangeName(ref student);
Console.WriteLine(student.Name);//student.Name is Tom

//Reference type as reference parameters 
public class Student
{
    public string Name { get; set; }     
}

static void ChangeName(ref Student student) //true pointer
{
    student.Name = "Tom";
}

Student student = new Student(){Name = "Mike"};
ChangeName(ref student);
Console.WriteLine(student.Name);//student.Name is Tom

//Output parameter
//
//Value type by output parameter 
static bool TryParse(string input, out double result)//true memory of value
{
    try
    {
        result = double.Parse(input);
        return true;
    }
    catch 
    {
        result = 0;
        return false;
    }

}
string = "789";
double result;
bool b1 = TryParse(input, out result);

//Reference type by output parameter 
public class Student
{
    public int Age { get; set; }
    public string Name { get; set; }
}

public class StudentGenerator
{
    public static bool Generate(string stuName. int stuAge, out Student student)//true memory of pointer
    {
        if(string.IsNullOrEmpty(Name))return false;
        if(Age<0)return false;
        student = new Student(){Name = stuName, Age = stuAge};
        return true;
    }
}

Student student;
bool b1 = Generate("Tom",18,student);

//Array parameter
//
static int Sum(params int[] intArray)//only one params parameter and must be at the end
{
    int sum = 0;
    foreach(var i in intArray)
    {
        sum += i;
    }
    return sum;
}

int result = Sum(1,2,3,4,5);

//Named parameter
//
static Student Generate(string stuName. int stuAge)
{
    Student student = new Student(){Name = stuName, Age = stuAge};
    return student;
}

Student student = Generate(stuAge: 18, stuName: "Tom");

//Optional parameter
//
static Student Generate(string stuName. int stuAge = 18)
{
    Student student = new Student(){Name = stuName, Age = stuAge};
    return student;
}

//Extension method
double x = 3.14159;
double y = Math.Round(x,4);//y=3.1416
//achieve x.Round(4);

static class DoubleExtension//staic class: only contains static memeber; can not be instance; can not inherit; can not contain instance constructor
{//Template Class Name: SomeTypeExtension;
     public static double Round(this double input, int digits)//must be public static in static class; this must be first parameter
     {
         double reults =Math.Round(input, digits);
         return reults;
     }
}

double y =  x.Round(4);

//enum 
enum Flag
{
    A = 0x01,
    B = 0x02,
    C = 0x04
}

void test(Flag flag)
{
    if((flag & Flag.A) == Flag.A) WriteLine("A");
    if((flag & Flag.B) == Flag.B) WriteLine("B");
    if((flag & Flag.C) == Flag.C) WriteLine("C");
}
