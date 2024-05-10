using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Repository.Model;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderDetailController : Controller
{
	private readonly IOrderDetailData _db;
	public OrderDetailController(IOrderDetailData db)
	{
		_db = db;
	}

	[HttpGet("All")]
	public async Task<IActionResult> GetAll()
	{
		try
		{
			var result = await _db.LoadAll();

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
			var result = await _db.LoadByOrderId(id);

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

	[HttpGet("ByGoodId")]
	public async Task<IActionResult> GetByGoodId([FromQuery]int id) 
	{
		try
		{
			var result = await _db.LoadByGoodId(id);

			if(result == null)
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
	public async Task<IActionResult> Create([FromBody]List<OrderDetail> orderDetails, [FromQuery]int orderId)
	{
		try
		{
			await _db.Save(orderDetails, orderId);
			return Ok();
		}
		catch (Exception)
		{

			throw;
		}
	}
}
