# 1. Class
> class is instance of Class (class, interface, [], enum, annotation, value type, void)
~~~java
//1
Class<Person> clazz = Person.class;
//2
Class<Person> clazz1 = new Person().getClass();
//3 (main)
Class<Person> clazz2 = Class.forName("com.java.Person");
//4
public class Test{
  public void test(){
    ClassLoader classLoader = Test.class.getClassLoader();
    Class<Person> clazz3= classLoader.loadClass("com.java.Person");
  }
}

System.out.println(clazz == clazz1);//true
System.out.println(clazz == clazz2);//true
System.out.println(clazz == clazz3);//true
~~~
# 2. Instance
~~~java
//Person class must have public Person(){}
Person obj = clazz2.newInstance();
~~~
# 3. Methods
## Get Fields
~~~java
//Get all public only fields includes parent class
Field[] fields = clazz.getFields();

//Get all fields not includes parent class
Field[] declaredFields = clazz.getDeclaredFields();

for(Field f : declaredFields){

  //Modifier
  int modifier = f.getModifiers();
  System.out.println(Modofier.toString(modifier));
  
  //Type
  Class type = f.getType();
  System.out.println(type.getName());
  
  //Name
  String name = f.getName();
  System.out.println(name);
}
~~~
~~~java
Person p = (Person) clazz.newInstance();
//Get public only field
Field idField = clazz.getField("id");
//Get any field
Field idDeclaredField = clazz.getDeclaredField("id");

idDeclaredField.setAccessible(true)//allow to access private or default field
idDeclaredField.set(p,1122);
int id = (int) idDeclaredField.get(p);

//Static field
Field staticIDDeclaredField = clazz.getDeclaredField("staticID");
staticIDDeclaredField.setAccessible(true)//allow to access private or default field
staticIDDeclaredField.set(Person.class/*or null*/,1122);
int staticID = (int) staticIDDeclaredField.get(Person.class/*or null*/);
~~~
## Get Methods
~~~java
//Get all public only methods includes parent class
Method[] methods = clazz.getMethods();

//Get all methods not includes parent class
Method[] declaredMethods = clazz.getDeclaredMethods();

for(Method m : declaredMethods){

  //Annotation
  Annotation[] annos = m.getAnnotations();
  
  //Modifier
  int modifier = m.getModifiers();
  System.out.println(Modofier.toString(modifier));
  
  //Return type
  Class type = m.getReturnType();
  System.out.println(type.getName());
  
  //Name
  String name = m.getName();
  System.out.println(name);
  
  //Parameter
  Class[] paramenterTypes = m.getParamenterTypes();
  
  //Exception
  Class[] exceptionTypes = m.getExceptionTypes();
  
}
~~~
~~~java
Person p = (Person) clazz.newInstance();
//Get public only method
Method showMethod = clazz.getMethod("show", String.class);
//Get any method
Method showDeclaredMethod = clazz.getDeclaredMethod("show", String.class);

showDeclaredMethod.setAccessible(true)//allow to access private or default method
String return = show.invoke(p, "RUN");

//Static method
Method staticShowDeclaredMethod = clazz.getDeclaredMethod("staticShow", String.class);
staticShowDeclaredMethod.setAccessible(true)//allow to access private or default method
staticShowDeclaredMethod.invoke(Person.class/*or null*/, "RUN");
~~~
## Get Constructor
~~~java
//Get all public only constructors not includes parent class
Constructor[] constructors = clazz.getConstructors();

//Get all constructors not includes parent class
Constructor[] declaredConstructors = clazz.getDeclaredConstructors();

for(Method m : declaredMethods){
  //Same as method
}
~~~
~~~java
Constructor[] declaredConstructors = clazz.getDeclaredConstructors(String.class);
declaredConstructors.setAccessible(true)//allow to access private or default constructor
Person p = (Person) declaredConstructors.newInstance("NEW");
~~~
## Get Parent Class
~~~java
Class superclass = clazz.getSupperclass();

//Generic parent class
Type genericSuperclass = clazz.getGenericSupperclass();
//Get generic parameter
ParameterizedType paramType = (ParameterizedType) genericSuperclass;
Type[] actualtypeArguments = paramType.getActualTypeArguments();
~~~
## Get Interface
~~~java
Class[] interfaces = clazz.getInterfaces();
~~~
## Get Package
~~~java
Package pack = clazz.getPackage();
~~~
## Get Annotation
~~~java
Annotation[] annos = clazz.getAnnotations();
~~~
