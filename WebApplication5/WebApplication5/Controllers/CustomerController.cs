namespace WebApi.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Customers;
using WebApi.Services;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private ICustomerService _customerService;
    private IMapper _mapper;

    public CustomerController(
        ICustomerService customerService,
        IMapper mapper)
    {
        _customerService = customerService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var customers = _customerService.GetAll();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var customer = _customerService.GetById(id);
        return Ok(customer);
    }

    [HttpPost]
    public IActionResult Create(CreateRequest model)
    {
        _customerService.Create(model);
        return Ok(new { message = "Customer created" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateRequest model)
    {
        _customerService.Update(id, model);
        return Ok(new { message = "Customer updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _customerService.Delete(id);
        return Ok(new { message = "Customer deleted" });
    }
}