# Creational
## 1. Singleton
> Only allow to create an instance
```java
//1
class Bank {
  private Bank(){
  
  }
  
  private static Bank instance = new banck();
  
  public static Bank getInstance(){
    return instance;
  }
}
//2 (lazy initialization)
class Bank {
  private Bank(){
  
  }
  
  private static Bank instance = null;
  
  public static Bank getInstance(){
    if(instance == null) instance = new banck();
    return instance;
  }
}
//3 (safe - double check)
class Bank {
  private Bank(){
  
  }
  
  private static volatile Bank instance = null;
  
  public static Bank getInstance(){
    if(instance == null){
      synchronized(Bank.class){
        if(instance == null) instance = new banck();
      }
    }
    return instance;
  }
}
//4 (safe - internal static class)
class Bank{
  private Bank(){
  
  }
  
  private static class BankInstance{
    private static final Bank INSTANCE = new Bank();
  }
  
  public static Bank getInstance(){
    return BankInstance.INSTANCE;
  }
}
//5 (recommend - enum)
enum Bank{
  INSTANCE;
  
  public void test(){
    System.out.println("Testing");
  }
}
```
# Structural
## 1. Proxy
```java
interface NetWork{
  public abstract void browse();
}

class Server implements NetWork{
  @Override
  public void browse(){
    System.out.println("Running");
  }
}

class ProxyServer implements NetWork(){
  private NetWork network;
  public ProxyServer(network){
    this.network = network;
  }
  private void check(){
  
  }
  @Override
  public void browse(){
    check();
    network.browse();
  }
}

Server server = new Server();
ProxyServer proxyserver = new ProxyServer(server);
proxyserver.browse();
```
## 2. Dynamic Proxy
```java
class ProxyFactory{
  public static Object getProxyInstance(Object obj /*poxied*/){
    MyInvocationhandler handler = new MyInvocationhandler();
    handler.bind(obj);
    return Proxy.newProxyInstance(obj.getClass().getClassLoader(), obj.getClass().getInterfaces(), handler);
  }
}

class MyInvocationhandler implements InvocationHandler{
  private Object obj;//poxied
  public void bind(Object obj){
    this.obj = obj;
  }
  @Override
  public Object invoke(Object proxy, Method method, Object[] args) throws Throwable{
    General.method1();
    Object returnValue = method.invoke(obj, args);//poxied
    General.method2();
    return returnValue;
  }
}
class General{
  public static method1(){
    System.out.println("Start");
  }
  
  public static method2(){
    System.out.println("End");
  }
}
NetWork proxyInstance = (NetWork) ProxyFactory.getProxyInstance(new Server);
proxyInstance.browse();//"Start" "Running" "End"
```
# Behavioral
## 1. Tempate Method
```java
abstract class Monitor{
  public final void Run(){
    setConfig();
    process();
    getResult();
  }
  public void setConfig(){
  
  }
  public abstract void process();
  public void getResult(){
  
  }
}

class VoltageMonitor extends Monitor{
  @override
  public void process(){
    voltageMonitor();
  }
  private void voltageMonitor(){
  
  }
}
```
