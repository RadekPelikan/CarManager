using CarManager.Domain;
using CarManager.Domain.Response;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CarManager.Order.API.Controllers;

[Route("[controller]")]
public class CustomersController : Controller
{
    private readonly ILogger<CustomersController> _logger;

    public CustomersController(ILogger<CustomersController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet("")]
    [ProducesResponseType<ICollection<Customer>>(200)]
    [ProducesResponseType<ResponseMessage>(204)]
    public ActionResult<ICollection<Customer>> GetCustomers()
    {
        var path = HttpContext.Request.GetEncodedUrl().Split("/").Last();
        throw new NotImplementedException($"{nameof(GetCustomers)} not implemented on endpoint: [ /{path} ]");
    }
    
    [HttpPost("")]
    [ProducesResponseType<ResponseMessage>(200)]
    [ProducesResponseType<ResponseMessage>(409)]
    public ActionResult<ResponseMessage> CreateCustomer([FromBody] Customer customer)
    {
        var path = HttpContext.Request.GetEncodedUrl().Split("/").Last();
        throw new NotImplementedException($"{nameof(CreateCustomer)} not implemented on endpoint: [ /{path} ]");
    }    
    
    [HttpDelete("")] // query
    [ProducesResponseType<ResponseMessage>(200)]
    [ProducesResponseType<ResponseMessage>(404)]
    public ActionResult<ResponseMessage> DeleteCustomers([FromQuery] IEnumerable<Guid> customerIds)
    {
        var path = HttpContext.Request.GetEncodedUrl().Split("/").Last();
        throw new NotImplementedException($"{nameof(DeleteCustomers)} not implemented on endpoint: [ /{path} ]");
    }
    
    // 3CC9EDD2-0D95-45E8-A2F5-B8377863989F
    [HttpGet("{id}")]
    [ProducesResponseType<Customer>(200)]
    [ProducesResponseType<ResponseMessage>(404)]
    public ActionResult<Customer> GetCustomer(Guid id)
    {
        var path = HttpContext.Request.GetEncodedUrl().Split("/").Last();
        throw new NotImplementedException($"{nameof(GetCustomer)} not implemented on endpoint: [ /{path} ]");
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType<ResponseMessage>(200)]
    [ProducesResponseType<ResponseMessage>(404)]
    public ActionResult<ResponseMessage> UpdateCustomer([FromBody] Customer customer)
    {
        var path = HttpContext.Request.GetEncodedUrl().Split("/").Last();
        throw new NotImplementedException($"{nameof(UpdateCustomer)} not implemented on endpoint: [ /{path} ]");
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType<ResponseMessage>(200)]
    [ProducesResponseType<ResponseMessage>(404)]
    public ActionResult<ResponseMessage> DeleteCustomer([FromBody] Customer customers)
    {
        var path = HttpContext.Request.GetEncodedUrl().Split("/").Last();
        throw new NotImplementedException($"{nameof(DeleteCustomer)} not implemented on endpoint: [ /{path} ]");
    }
    
}