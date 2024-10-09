namespace CarManager.Domain;

public class Customer
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Contact Contact { get; set; }
}