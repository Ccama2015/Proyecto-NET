namespace WebApi.Services;

using AutoMapper;
using BCrypt.Net;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Customers;

public interface ICustomerService
{
    IEnumerable<Customer> GetAll();
    Customer GetById(int id);
    void Create(CreateRequest model);
    void Update(int id, UpdateRequest model);
    void Delete(int id);
}

public class CustomerService : ICustomerService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public CustomerService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Customer> GetAll()
    {
        return _context.Customers;
    }

    public Customer GetById(int id)
    {
        return getCustomer(id);
    }

    public void Create(CreateRequest model)
    {
        // validate
       /* if (_context.Users.Any(x => x.Email == model.Email))
            throw new AppException("User with the email '" + model.Email + "' already exists");*/

        // map model to new user object
        var customer = _mapper.Map<Customer>(model);

     

        // save user
        _context.Customers.Add(customer);
        _context.SaveChanges();
    }

    public void Update(int id, UpdateRequest model)
    {
        var customer = getCustomer(id);


        // copy model to user and save
        _mapper.Map(model, customer);
        _context.Customers.Update(customer);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var customer = getCustomer(id);
        _context.Customers.Remove(customer);
        _context.SaveChanges();
    }

    // helper methods


    private Customer getCustomer(int id)
    {
        var customer = _context.Customers.Find(id);
        if (customer == null) throw new KeyNotFoundException("Customer not found");
        return customer;
    }
}