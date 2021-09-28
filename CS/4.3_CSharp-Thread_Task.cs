//Thread

//Task
//
#region Wait, WaitAll and WaitAny

List<Task> taskList = new List<Task>();

private void Running(string name, string project)
{
    Console.write($"{project} is running by {name}");

}

taskList.Add(Task.Run(()=> this.Running("part one","Steve"))); //Task.Run: create a instance and then run it
taskList.Add(Task.Run(()=> this.Running("part two","Tony")));
taskList.Add(Task.Run(()=> this.Running("part three","Jame")));

Task task_1 = Task.Run(()=>{
    Console.write($"task_1 running");
});

task_1.Wait();//it will block current thread unitll task_1 finish
//parameter; Task[]
task.WaitAny(taskList.ToArray());//task.WaitAll will block current thread untill one of threads finish

task.WaitAll(taskList.ToArray()); //task.WaitAll will block current thread untill all thread finish

Console.write($"whole project is done");

#endregion

#region Current thread block solution one (not recommand)

//not normalization: do not nest thread
Task.Run(()=>{

    taskList.Add(Task.Run(()=> this.Running("part one","Steve"))); //Task.Run: create a instance and then run it
    taskList.Add(Task.Run(()=> this.Running("part two","Tony")));
    taskList.Add(Task.Run(()=> this.Running("part three","Jame")));

    //parameter: Task[]
    task.WaitAny(taskList.ToArray());//task.WaitAll will block current thread untill one of threads finish

    task.WaitAll(taskList.ToArray()); //task.WaitAll will block current thread untill all thread finish

    Console.write($"whole project is done");
});

#endregion

#region Current thread block solution two: ContinueWhenAll and ContinueWhenAny

//Solution two: taskfactory.ContinueWhenAll and taskfactory.ContinueWhenAny won't block current thread
TaskFactory taskfactory = new TaskFactory();

//Waiting for one of tasks in Task[] finish and then run Action<Task>
taskfactory.ContinueWhenAny(taskList.ToArray(), t=>{
    Console.write($"whole project is done");
});  

//Waiting for all task in Task[] finish and then run Action<Task[]>, it return a Task
taskfactory.ContinueWhenAll(taskList.ToArray(), tArray=>{
    Console.write($"whole project is done");
});
//Action<Task> and Action<Task[]> would be running on new thread, it must not be current thread

#endregion
 
#region Task.Run in for()

for(int i = 0; i <5, i++)
{
    Task.Run(()=>{
        Console.write($"{i}");
    });
}//print out 5, 5, 5, 5, 5: before the begin of 5 threads, i is finish ++ to 5. 

//Solution:
for(int i = 0; i <5, i++)
{
    int k = i; //generate 5 k to give to Task
    Task.Run(()=>{
        Console.write($"{k}");
    });
}

#endregion

#region Lock

private static readonly object Lock = new object ();//Lock must be reference type  //string is reference and flyweight：declqred different string but same characters, using same reference( pointer same memory ) 
//Generic class: generic parameter type is the same, memory of static member is the same. otherwise they are difference.
for(int i = 0; i <5, i++)
{
    
    Task.Run(()=>{
        //or lock (this)
        lock (Lock) // ( Monitor.Enter(Lock); ....Monitor.Ext(Lock);) make sure only one thread running at this time
        {
            Console.write($"{i}");
        }
    });
    
}

#endregion

#region Long-running tasks
//for task that need to running for long time
Task tasklong = Task.Factory.StartNew(()=>{
    Thread.Sleep(3000);
    Console.WriteLine("Foo");
}, TaskCreationOptions.LongRunning);

#endregion

#region return value 

Task<int> task = Task.Run(()=>{
    Console.Write("Foo");
    return 3;
});
int result = task.Result;//result = 3;//it will block current thread untill task finish

#endregion

#region exception

Task task = Task.Run(()=>{throw null});
try
{
    task.Wait();
}
catch(AggregateException eax)
{
    if(aex.InnerException is NullReferenceException)
    {
        Console.WriteLine("Null");
    }
    else
    {
        throw;
    }

}

#endregion