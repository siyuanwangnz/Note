# 1. Polymorphism 
```java
class Animal {
  String color = "red";
  public void eat(){
    System.out.println("Animal eat");
  }
  //Method Overloading
  public void eat(string food){
    System.out.println("Animal eat" + food);
  }
}

class Dog extends Animal{
  String color = "green"; 
  //Method Overriding
  public void eat(){
    System.out.println("Dog eat");
  }
  public void jump(){
  
  }
}

Animal animal = new Dog();
aniaml.eat();//"Dog eat"
aniaml.jump();//Wrong!!!
System.out.println(animal.color);//"red"
```
# 2. Wrapper Class
```java
//Value type to wrapper class
int i = 10;
Integer in = new Integer(i);
//Wrapper class to value type
int i1 = in.intValue();

//Autoboixng and unboxing from JDK 5.0
Integer in1 = i1;
int i2 = in1

//To string
//1
String str = i + "";
//2
String.valueOf(i);

//String to
Integer.parseInt(str);
```
# 3. Code Block
```java
//Run while class loading, only run once. it is available to have multi static code block in class
static{

}
//Run while class instance creating. it is available to have multi static code block in class
{

}
//Running priority: static code block > code block > constructor
```
# 4. Internal Class
```java
class Animal{
  public void run(){
  
  }
  static class Dog{ //Static internal class (Dog) won't create while Animal creating, it is only created while Dog is invoked 
    public void dogRun(){
      run();//or Animal.this.run();
    }
  }
  class Cat{
  
  }
  //Method
  public Compareable getComparable(){
    class MyComparable implements Comparable{
      @Override
      public int compareTo(Object o){
        return 0;
      }
      return new MyComparable(); 
      /*or
       *   return new Comparable(){
       *    @Override
       *    public int compareTo(Object o){
       *      return 0;
       *    }
       *   };
       */
    }
  }
}

Animal.Dog dog = new Animal.Dog();
Animal animal = new Animal();
animal.Cat cat = animal.new Cat();
```
