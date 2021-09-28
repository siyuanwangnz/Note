//await and async
//

public async Task DoSomethingAsync()
{
    await Taks.Run(()=>{
        Console.WriteLine("********");
    });
}

public async Task<int> DoSomethingReturnAsync()
{
    await Taks.Run(()=>{
        Console.WriteLine("********");
    });
    return 10;
}

static async Task Main()
{
    await DoSomethingAsync();
    int result = await DoSomethingReturnAsync();

}

//Usage
public static async Task DoSomethingAsync()
{
    Console.WriteLine("Task 1");
    await Taks1.Run(()=>{
        Console.WriteLine("1");
    });
    //or
    //Task task= Taks1.Run(()=>{
    //    Console.WriteLine("1");
    //});
    //await task;
    Console.WriteLine("Task 2");
    await Taks2.Run(()=>{
        Console.WriteLine("2");
    });
    Console.WriteLine("3");
}

static async Task Main()
{
    Console.WriteLine("Main 1");
    await DoSomethingAsync();
    Console.WriteLine("Main 2");
}
//printout Main 1 -> Task 1 -> Main2 -> 1 -> Task 2 -> 2 -> 3 
//current thread jump out DoSomethingAsync() when meet await unitll await finish and then run code behind of await
//the code behind of await is as callback function of the code front of await

//Lambda
Button.Click += async (sender,args)=>{
    await task.Delay(1000);
    Buton.Content = "Done";
};

Func<Task<int>> func = async ()=>{
    await Task.Delay(1000);
    return 123;
};
int result = await func();

//C# 异步编程基础（完结
