using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Repository.Model;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : Controller
{
    private readonly IOrderData _orderDb;
    private readonly IOrderDetailData _orderDetailDb;

    public OrderController(IOrderData orderDb, IOrderDetailData orderDetailDb)
    {
        _orderDb = orderDb;
        _orderDetailDb = orderDetailDb;
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await _orderDb.GetAll();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception)
        {

            throw;
        }
    }

    [HttpGet("ByOrderId")]
    public async Task<IActionResult> GetByOrderId([FromQuery]int id)
    {
        try
        {
            var result = await _orderDb.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception)
        {

            throw;
        }
    }

    [HttpGet("ByClientId")]
    public async Task<IActionResult> GetByClientId([FromQuery]int clientId)
    {
        try
        {
            var result = await _orderDb.GetByClientId(clientId);

            if (result == null) 
            {
                return NotFound(); 
            }

            return Ok(result);
        }
        catch (Exception)
        {

            throw;
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]Order order)
    {
        try
        {
            var result = await _orderDb.Save(order);

            if (result == null)
            {
                return BadRequest();
            }

            await _orderDetailDb.Save(order.Details, result);

            return Ok();
        }
        catch (Exception)
        {

            throw;
        }
    }
}
