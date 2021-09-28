# 1. Collection
~~~java
Collection coll = new ArrauList();
coll.add(123);
coll.add("AA");
coll.add(new Person("Tom",23));
coll.add(true);
~~~
### Iterator
~~~java
Iterator iterator = coll.iterator();
while(iterator.hasNext()){
  System.out.println(iterator.next());
}
~~~
### For Each
~~~java
for(Object obj : coll){
   System.out.println(obj);
}
~~~
## List
> Orderly, repeatable
### ArrayList
> Object [] elementData
### LinkedList
> Node
### Vector
> Object [] elementData (synchronized)
## Set
> Disorderly, non-repeatable
### HashSet
> (Key of HashMap) Order by hash table, compare by hashCode() and then equals()
#### LinkedHashSet
> Indexable by add order
### TreeSet
> Order by compareTo() or TreeSet set = new TreeSet(new Comparator(){}); (Red Black Tree)
# 2. Map
> Node[] (JDK7: Entry[]): key (disorderly, non-repeatable (Set)) - value (disorderly, repeatable)
~~~java
Map map = new HashMap();
map.put(null,123);
map.put("Tom",new Person("Tom",32));
map.put("A",12);
map.put("A",123);//put same key (hasCode() and equals() all true), new value would cover old
~~~
## HasMap
> Hash table + list + red black tree (JDK8 list>8, table>64)
>
> Null is available 
~~~java
Set set = map.keySet();
Collection values = map.values();
Set entrySet = map.entrySet();
~~~
### LinkedHashMap
> Indexable by add order
## TreeMap
> Order by key
## Hashtable
> Null is unavailable
### Properties
> key and value are all string type
~~~java
FileInputStream fis = new FileInputStream(jdbc.properties);

Properties pros = new Properties();
pros.load(fis);
~~~
# 3. Collections
### synchronizedList()
~~~java
List list = new List();
List list1 = Collections.synchronizedList(list);
~~~
# 4. Stream
## Create Stream
### From Collection
```java
List<Employee> employees = new List<Employee>();
Stream<Employee> stream = employees.stream();//serial
Stream<Employee> parallelStream = employees.parallelStream();//parallel
```
### From Array
```java
intStream stream = Array.stream(new int[]{1,2,3,4,5});

Stream<Employee> = Array.stream(employees.toArray());
```
### From Stream
```java
Stream<Integer> stream = Stream.of(1,2,3,4,5);

//Unlimit Stream
Stream.iterate(0, t -> t + 2).limit(10).forEach(System.out::println);
Stream.generate(Math::random).limit(10).forEach(System.out::println);
```
## Process
### Sellection
```java
List<Employee> employees = new List<Employee>();
Stream<Employee> stream = employees.stream();
//Filter
stream.filter(e -> e.salay > 7000).forEach(System.out::println);
//Limit
stream.limit(10).forEach(System.out::println);//error
employees.stream().limit(10).forEach(System.out::println);
//Skip
employees.stream().skip(2).forEach(System.out::println);
//Distinct - detele repeated element by hashCode() and equals()
employees.stream().distinct().forEach(System.out::println);
```
### Map
```java
//Map
List<String> list = Arrays.asList("a","s","d","w");
list.stream().map(str -> str.toUpperCase()).forEach(System.out::println);
//Flat Map
List<String> list1 = Arrays.asList("aaa","sss");
list1.stream().flatMap(Test::fromStringtoStream/*String "aaa" to Stream<String> "a" "a" "a"*/).forEach(System.out::println);//"a" "a" "a" "s" "s" "s"
```
### Sort
```java
List<Integer> list = Arrays.asList(12,34,56,3,67,3);
list.stream().sorted().forEach(System.out::println);

list.stream().sorted(Integer::compare).forEach(System.out::println);
```
## End
### Find and Match
```java
//allMatch: all meets requirement return true
boolean allMatch = employees.stream().allMatch(e -> e.age > 18);
//anyMatch: any one meets requirement return true
boolean anyMatch = employees.stream().anyMatch(e -> e.salary > 1000);
//noneMatch: none meets requirement return true
boolean noneMatch = employees.stream().noneMatch(e -> e.salary < 100);
//findFirst
Optional<Employee> employee = employees.stream().findFirst();
//findAny
Optional<Employee> employee = employees.parallelStream().findAny();
//count
long count = employees.stream().filter(e -> e.salary > 1000).count();
//max min
Optional<Double> maxSalary = employees.stream().map(e -> e.salay).max(Double::compare);
//forEach
employees.stream().forEach(System.out::println);
```
### Reduction
```java
Integer sum = employees.stream().map(e -> e.salay).reduce(0, Integer::sum);
```
### Collection
```java
List<Employee> collect = employees.stream().filter(e -> e.salary > 100).collect(Collectors.toList());
```
