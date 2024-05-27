Customer myCustomer = new Customer();
VipCustomer myVipCustomer = new VipCustomer();
Console.WriteLine(myVipCustomer.Name);

//Encapsulate everything that is related to a customer
public class Customer
{
  public string Name { get; } = "Samuel";

  //Abstract everything that is related to buying to be used only inside of the class
  private void Buy()
  {
    Console.WriteLine("Buying");
  }
}

//inherit from the customer class
public class VipCustomer : Customer
{
  //override the name property
  public new string Name { get; } = "Lucas";
}
