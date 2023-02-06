namespace WebApi.Models.Customers;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class UpdateRequest
{
    public string DocumentType { get; set; }
    public string DocumentNumber { get; set; }
    public string LastName { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }

    private string replaceEmptyWithNull(string value)
    {
        // replace empty string with null to make field optional
        return string.IsNullOrEmpty(value) ? null : value;
    }
}