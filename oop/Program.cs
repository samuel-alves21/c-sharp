//Access Modifiers:

//public -> Available everywhere
//private -> Available only inside of the class
//protected -> Available inside of the class and inside of the child classes
//internal -> Available inside of the assembly

//static -> cannot be instantiated (no object)
//virtual -> can be overriden
//parcial -> can be divided into different files while being the same class
//abstract -> cannot be instantiated and cannot be overriden



//Dispose -> Dispose of the object (close the connection)
using (Customer customer = new Customer("Pedro"))
{
  customer.Buy();
}

VipCustomer myVipCustomer = new VipCustomer("Samuel");
Console.WriteLine(myVipCustomer.Name);

//Encapsulate everything that is related to a customer inside ofthe class
public class Customer : IDisposable
{
  private string _Name;
  public string Name
  {
    get
    {
      return _Name;
    }
    set
    {
      Console.WriteLine("Changing the name");
      _Name = value;
    }
  }

  public Customer(string name)
  {
    _Name = name;
  }

  //Abstract everything that is related to buying to be used only inside of the class
  virtual public void Buy()
  {
    Console.WriteLine("Buying");
  }

  public void Dispose()
  {
    Console.WriteLine("Disposing...");
  }
}

//inherit from the customer class
public class VipCustomer : Customer
{
  public VipCustomer(string name) : base(name)
  { }

  //Polymorphism: override the buy method from the customer class 
  override public void Buy()
  {
    Console.WriteLine("Buying VIP");
  }
}
