# 1. Keyword: extends
> Class inheritance
```java
public class Dog extends Animal{

}
```
# 2. Keyword: this
## Using this with a Constructor and Overload
```java
public class Rectangle {
  public int x;
  public int y;
  public int w;
  public int h;
  
  public Rectangle (int x, int y){
    this.x = x;
    this.y = y;
  }
  
  public Rectangle (int x, int y, int w){
    this(x, y);
    this.w = w;
  }

  public Rectangle (int x, int y, int w, int h){
    this(x, y, w);
    this.h = h;
  }
}
```
# 3. Keyword: super
> Using parent class field, method, constructor 
```java
public class Dog extends Animal{
  public Dog(){
    super();
  }
  
  public eat(){
    System.out.println(super.color);
    super.eat();
  }
}
```
# 4. Keyword: instanceof
> Ex: a instanceof A: a: instance, A: class, check if a is A type, if so return true otherwise false
```java
Animal animal = new Dog();
if(animal instanceof Dog){

}
```
# 5. Keyword: ==, equals()
## ==
> Value type: compare value, no matter type
> 
> Reference type: compare pointing address
```java
//Value type
int i = 10;
double d = 10.0;
System.out.println(i == d);//true
//Reference type
String str1 = new String("123");
String str2 = new String("123");
System.out.println(str1 == str2);//false
```
## equals()
> In object class: ==
>
> In others class: depends override equal(), compare content in string, file, date class
# 6. Keyword: final
> Class: not allow to be inherited
> 
> - Method: not allow to override
> 
> - Value: constant
> 
> Parameter:
>  - Value: not allow to be changed and rewrited in method body
>  
>  - Reference: allow to be changed but not rewrited
```java
public test(final int i, final String[] strs){
  i = 8;//error
  strs[1] = "asd";
  strs = new String[]{"w","e","r"};//error
}
```
# 7. Keyword: abstract
> Class: can not instance
> 
> Method: only method declaration
## Anonymous Instance
```java
abstract class Person{
  public abstract void eat();
}

Person p = new Person(){
  @Override
  public void eat(){
  
  }
}
```
# 8. Keyword: interface
> Global constant
> 
> Abstract method
> 
> No constructor
> 
> Static method
> 
> Default method
```java
interface Movable{
  boolean direction = true; 
}

interface Flyable{
  public static final int MAX = 800;//or int MAX = 800;
  public abstract void fly();
  //Static method
  public static void up(){
  
  }
  //Default method
  public default void down(){
  
  }
}

class Airforce extends Plane implements Flyable extends Movable{
  @Override
  public void fly(){
  
  }
  public void method(){
    Flyable.super.down();
  }
}

Flyable.up();
new Airforce().down();
```
# 9. Keyword: try catch finally throw throws
```java
try{

}catch(Exception e){
  e.getMessage();
  e.printStackTrace();
  throw new RuntimeException("");
  throw new Exception("");
}finally{//must be run before return or catch

}
//thr
public class Test{
  public void method() throws Exception, IOException{
  
  }
}
//Customer Exception
public class MyException extends RuntimeException{
  static final long serialversionUID = -712381238148144L;
  public MyException(String msg){
    super(msg);
  }
}
```
# 10. Keyword: enum
~~~java
//enum class inherit Enum
interface Info{
  void show();
} 

enum Season implements Info{
  SPRING("spring", "1"),
  SUMMER("summer", "4"),
  AUTUMN("autum", "7"),
  WINTER("winter", "10");
  /* or
  SPRING("spring", "1"){
    @Override
    void show(){
    
    }
  }
  */
  
  private final String name;
  private final String time;
  
  private Season(String name, String time){
    this.name = name;
    this.time = time;
  }
  
  public String getName(){
    return name;
  }
  
  public String getTime(){
    return time;
  }
  
  /* or
  @Override
  public void show(){
  
  }
  */
}

//Simple
public enum Level{
  HIGH,
  MEDIUM,
  LOW
}
~~~

# 11. Keyword: @
> Annotation
~~~java
//Declare
@Repeatable(MyAnnotations.class)
public @interface MyAnnotation{
  String value() default "hello";
}

@MyAnnotation (value = "hi")//or @MyAnnotation
class Person{

}
//Meta-annotation (use for annotation)
//@Retention//SOURCE, CLASS (keep in compiled file - default), RUNTIME (get by reflection)
//@Target//ElementType[] (Indicates the contexts in which an annotation type is applicable) 
//@Documented//Indicates that annotations with a type are to be documented by javadoc
//@Inherited//Indicates that an annotation type is automatically inherited
//@Repeatable
public @interface MyAnnotations{
  MyAnnotation[] value();
}
~~~
# 12. Keyword: <>
> Ceneric
## Generic Method
~~~java
public class Test{
  public static <E> List<E> toList(E[] arr){
    ArrayList<E> list = new ArrayList<>();
    
    for(E e : arr){
      list.add(e);
    }
    return list;
  }
}
~~~
## Wildcard: ?
~~~java
List<Object> listO = null;
List<String> listS = null;

List<?> listW = null;

listW = listO;
listW = listS;
~~~
~~~java
List<? extends Preson> listEP = null;
List<? supper Person> listSP = null;
List<Student> listS = null;
List<Person> listP = null;
List<Object> listO = null;

listEP = listS;
listEP = listP;
listEP = listO;//error

listSP = listS;//error
listSP = listP;
listSP = listO;
~~~
# 13. Keyword: ->
> [parameters of unique method in interface] - > [override method body] (instance of interface that has only one abstract method - @FunctionalInterface)
## No parameter, no return
```java
Runnable ro = new Runnable(){
  @Override
  public void run(){
    System.out.println("Running");
  }
};
Runnable r = () -> System.out.println("Running");
//or
Runnable r1 = () -> {
  System.out.println("Running - 1");
};
```
## Parameters, no return
```java
Consumer<String> cono = new Consumer<String>(){
  @Override
  public void accept(String s){
    System.out.println("Accept");
  }
};
Consumer<String> con = (String s) -> System.out.println("Accept");
//or
Consumer<String> con1 = (s) -> System.out.println("Accept -1");
//or - single parameter
Consumer<String> con2 = s -> System.out.println("Accept -2");
```
## Parameters, return
```java
Comparator<Integer> como = new Comparator<Integer>(){
  @Override
  public int comapre(Integer o1, Integer o2){
    return o1.compareTo(o2);
  }
};

Comparator<Integer> com = (o1, o2) -> {
  return o1.compareTo(o2);
};
//or - only return
Comparator<Integer> com = (o1, o2) -> o1.compareTo(o2);
```
## Functional Interface
Interface         | Parameter     | Return        | Method
----------------- | ------------- | ------------- | ----------------
`Consumer <T>`    | T             | void          | `void accept(T t);`
`Supplier <T>`    | N/A           | T             | `T get();`
`Function <T, R>` | T             | R             | `R apply(T t);`
`Predicate <T>`   | T             | Boolean       | `Boolean test(T t);`
```java
public void test(double money, Consumer<double> con){
  con.accept(money);
}

test(500, s -> System.out.println(s - 100));
```
# 14. Keyword: ::
## Object::Instance Method (A method1 (B b ..)) (A method2 (B b ..))
> Consumer - `void accept(T t);`
> 
> PrintStream - ` void println(T t)`
```java
Comsumer<String> con = str -> System.out.println(str);

PrintStream ps = System.out;
Consumer<String> con1 = ps::println;
con1.accept("Good");
```
## Class::Static Method (A method1 (B b ..)) (A method2 (B b ..))
> Comparator - `int compare(T t1, T t2);`
> 
> Integer - `int compare(T t1, T t2);`
```java
Comparetor<Integer> com = (t1, t2) -> Integer.compare(t1, t2);
com.compare(12,23);

Comparetor<Integer> com1 = Integer::compare;
```
## Class::Instance Method (A method1 (B b, C c ..)) (A b.method2 (c ..))
> Comparator - `int compare(T t1, T t2);`
> 
> String - `int s1.compareTo(s2);`
```java
Comparetor<String> com = (s1, s2) -> s1.compareTo(s2);
com.compare("as", "we");

Comparetor<String> com1 = String::compareTo;
```
## Class::new (A method (B b ..)) (new A(B b ..))
> Supplier - `T get();`
> 
> Employee - `new Employee();`
```java
Supplier<Employee> sup = () -> new Employee();
sup.get();

Supplier<Employee> sup1 = Employee::new;
```
## Class[]::new (A method ((B b)) (new A[b])
> Function - `R apply(T t);`
> 
> String[] - `new String[t];`
```java
Function<Integer, String[]> func = length -> new String[length];
String[] strs = func.apply(5);

Function<Integer, String[]> func1 = String[]::new;
```
# 15. Keyword: ...
> Unlimmit parameters
```java
public void test(String... strs){
  for(String str : strs){
    System.out.println(str);
  }
}

test("s","d","w","f");
```
# 16. Keyword: Optional
```java
//Create Optional
Optional<Employee> optionalEmployee = Optional.ofNullable(employee);//Optional.of(employee) [null is not available]
//Check Null
Employee employee1 = optionalEmployee.orElse(new Employee());//if employee == null, return new Employee(); if employee != null, return employee
```
# 17. Keyword: native
> Using C/C++ to implement method function
# 18. Keyword: volatile
> Same as synchronized  
