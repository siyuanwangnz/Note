//Thread

//Invoke
//

//BeginInvoke 
static void UpdateData(string arg1)
{
    Console.WriteLine($"{arg1} is running");
    //do something that need to take long time
}

Action<string> action = new Action<string>(UpdateData);

AsyncCallback callback = new AsyncCallback(ar=>{
    Console.WriteLine($"{ar.AsyncState} is done");
});

action.BeginInvoke("action", callback, "UpdateData");

#region parameter of BeginInvoke: 
//1. parameter of delegate function instance 
//2. AsyncCallback tpye of delegate function instance
//3. ar.AsyncState of parameter(IAsyncResult ar) of AsyncCallback // can be object type
#endregion

//after running action by another thread, callback will run by the same thread//action->callback with ar.AsyncState

//print out: action is running 
//           UpdateData is done

//WaitOne(): wait unitll BeginInvoke finish // or asyncResult.IsCompleted
IAsyncResult asyncResult = action.BeginInvoke("action", callback, "UpdateData");

Console.WriteLine($"do something else");

asyncResult.AsyncWaitHandle.WaitOne();//block current thread untill action finish
//WaitOne(-1) keep waiting
//WaitOne(1000) just wait for 1000ms 

//EndInvoke(): wait unitll BeginInvoke finish and then get return from Func delegate fucntion 
static void int UpdateData1() //Func<int> func = ()=>{return DateTime.Now.Day;}
{
    //do something that need to take long time
    return DateTime.Now.Day;
}

Func<int> func = new Func<int>(UpdateData1);

IAsyncResult asyncResult = func.BeginInvoke(null, null);

var result = func.EndInvoke(asyncResult); //block current thread untill func finish and then get return
//result = DateTime.Now.Day // var result = func.EndInvoke(func.BeginInvoke(null, null));

//EndInvoke as AsyncCallback
IAsyncResult asyncResult = func.BeginInvoke(ar=>{
    var result1 = func.EndInvoke(ar) //ar = asyncResult, result1 =  DateTime.Now.Day
}, null);