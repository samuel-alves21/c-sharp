var dataContext = new DataContext<Person>();
var person = new Person();

dataContext.Save(person);

public class DataContext<T>
{
  public void Save(T item)
  {

  }
}

public class Person
{

}

public class Payment
{

}

public class Product
{

}