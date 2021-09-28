//Switch statement
//
int switch_on = 105;//suitable for int, char, string, emum, bool

switch (switch_on/10)
{
    case 10:
        if(switch_on ==1) goto case 8;
        else goto default;
    case 8:
        Console.WriteLine("8");
        break;
    case 7:
    case 6:
        Console.WriteLine("6&7");
        break;
    default:
        Console.WriteLine("error");
        break;
}

//Try and catch statement
//
bool hasError = false;
try
{
    int a = int.Parse("123");
}
catch  //if there is exception in try{}, it will run catch{}
{
    Console.WriteLine("error");
    hasError = true;
}
finally //no matter what, it will run finally{}
{
    if(hasError)Console.WriteLine("error");
    else Console.WriteLine("done");
}
//or
try
{
    int a = int.Parse("123");
}
catch(ArgumentNullException)//ane
{
    Console.WriteLine("is null");
}
catch(FormatException)//fe
{
    Console.WriteLine("is not number");
}
catch(OverflowException)//oe
{
    Console.WriteLine("out of range");
}
catch(OverflowException oe)
{
    Console.WriteLine(oe.Message);
}
//throw
static int Add(string arg1, string arg2)
{
    int a = 0;
    int b = 0;
    try
    {
        a = int.Parse(arg1);
        b = int.Parse(arg2);

    }
    catch(FormatException fe)//or (FormatException)
    {
        throw fe;//or throw;
    }
    int result = a + b;
    return result;
}

int r = 0;
try
{
    r = Add("123","456");
}
catch(FormatException fe)
{
    Console.WriteLine(fe.Message);
}

//using statement
//
SqlConnection sqlConn = new SqlConnection(yourConnectionString);

using (sqlConn as IDisposable)
using (SqlCommand sqlComm = new SqlCommand(yourQueryString, sqlConn))
using (Font MyFont = new Font("Arial", 10.0f), MyFont2 = new Font("Arial", 10.0f))
{
      try
        {
            sqlConn.Open(); //Open connection
            sqlComm.ExecuteNonQuery(); //Operate DB here
        }
        catch( SqlException err )
        {
 
            MessageBox.Show( err.Message );
        }
        catch( Exception err )
        {
            MessageBox.Show( err.Message );
        }
}
//instance in using() will be disposed after code running finish