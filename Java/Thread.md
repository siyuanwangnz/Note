# 1. Create Thread
### Override run() of Thread Class
```java
class MyThread extends Thread{
  @Override
  public void run(){
  
  }
}

new MyThread().start();
```
### Anonymous Class
```java
new Thread(){
  @Override
  public void run(){
  
  }
}.start();
```
### Implement Runnable Interface
~~~java
class MyThread implements Runnable{
  @Override
  public void run(){
  
  }
}

MyThread myThread = new MyThread();
new Thread(myThread).start();
~~~
### Implement Callable Interfacce
~~~java
class MyThread implements Callable{
  @Override
  public Object call() throws Exception{
  
    return new Object();
  }
}

MyThread myThread = new MyThread();
FutureTask futureTask = new FutureTask(myThread);
new Thread(futureTask).start();
Object obj = futureTask.get();

//or

class MyThread implements Callable<Integer>{
  @Override
  public Integer call() throws Exception{
  
    return new Integer();
  }
}

MyThread myThread = new MyThread();
FutureTask<Integer> futureTask = new FutureTask<Integer>(myThread);
new Thread(futureTask).start();
Integer obj = futureTask.get();
~~~
### Thread Pool
~~~java
class MyThread implements Runnable{
  @Override
  public void run(){
  
  }
}
class MyThread1 implements Runnable{
  @Override
  public void run(){
  
  }
}
ExecutorService service = new Executor.newFixedThreadPool(nThread: 10);
ThreadPoolExecutor service1 = (ThreadPoolExecutor)service;
service1.setCorePoolSize(15);
//execute for Runnable; submit for Callable
service.execute(new MyThread());
service.execute(new MyThread1());
service.shutdown();
~~~
# 2. Operation
### yield()
> Stop current executing thread and give to others thread 
### join()
> Switch to another thread and wait until finish, Ex: MyThread.join();
### sleep()
> Block millisecond still lock, Ex: sleep(millis: 1000);
### wait() notify()
> Must be uesd in synchronized block or method
> 
> Must use the same obj as synchronized(obj) (motheds in the object class)
> 
> wait(): Block thread and unlock
> 
> notify(): Ready a thread that is waiting depends priority
> 
> notifyAll(): Ready all threads that are waiting
~~~java
synchronized(this){
  notify();
  
  wait();
}

Object obj = new Object();
synchronized(obj){
  obj.notify();
  
  obj.wait();
}
~~~
### isAlive()
### getName() setName()
### getPriority() setPriority()
### synchronized(obj){}
> obj: any instance of class and one for multi thread
#### Code Block
~~~java
class MyThread implements Runnable{
  @Override
  public void run(){
    synchronized(this){

    }
  }
}

class MyThread extends Thread{
  private static Object obj = new object();
  @Override
  public void run(){
    synchronized(obj){

    }
    /* or
     *synchronized(MyThread.class){
     * 
     *}
     */
  }
}
~~~
#### Code Method
~~~java
class MyThread implements Runnable{
  @Override
  public void run(){
    method();
  }
  private synchronized void method(){
  
  }
}

class MyThread extends Thread{
  @Override
  public void run(){
    method();
  }
  private static synchronized void method(){
  
  }
}
~~~
### ReentrantLock
~~~java
class MyThread implements Runnable{
  private ReentrantLock lock = new ReantrantLock();
  @Override
  public void run(){
   try{
    lock.lock();
   
   }finally{
    lock.unlock();
   }
  }
}
~~~
