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
