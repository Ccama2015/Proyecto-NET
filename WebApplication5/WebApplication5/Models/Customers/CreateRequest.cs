namespace WebApi.Models.Customers;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class CreateRequest
{

    [Required]
    public string DocumentType { get; set; }

    [Required]
    public string DocumentNumber { get; set; }

    [Required]
    public string Name { get; set; }
    [Required]
    public string LastName { get; set; }

    [Required]
    public string Phone { get; set; }

   
}