namespace WebApi.Entities;

using System.Text.Json.Serialization;

public class Customer
{
    public int Id { get; set; }
    public string DocumentType { get; set; }
    public string DocumentNumber { get; set; }
    public string LastName { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }

}