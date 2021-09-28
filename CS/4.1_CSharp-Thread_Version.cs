//Thread

//Version .NetFramework 1.0, 1.1 //Thread
ThreadStart threadstart = new ThreadStart(()=>{
    Console.Write("thread start");
    Thread.Sleep(2000);
    Console.Write("thread end");
});

Thread thread = new Thread(threadstart);
thread.start();

//Version .NetFramework 2.0 //ThreadPool
WaitCallback callback = new WaitCallback(()=>{
    Console.Write("thread start");
    Thread.Sleep(2000);
    Console.Write("thread end");
});

ThreadPool.QueueUserWorkItem(callback);

//Version .NetFramework 3.0 //Task
//Task
Action action = new Action(()=>{
    Console.Write("thread start");
    Thread.Sleep(2000);
    Console.Write("thread end");
});

Task task = new Task(action);
task.Start();

//Parallel: run multi thread included main thread
Parallel.Invoek(()=>{
    Console.Write("thread1 start");
    Thread.Sleep(2000);
    Console.Write("thread1 end");
},()=>{
    Console.Write("thread2 start");
    Thread.Sleep(2000);
    Console.Write("thread2 end");
},()=>{
    Console.Write("thread3 start");
    Thread.Sleep(2000);
    Console.Write("thread4 end");
});