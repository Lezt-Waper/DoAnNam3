using Microsoft.AspNetCore.Mvc;
using Repository.Data;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class GoodController : Controller
{
    private readonly IGoodData _db;
    public GoodController(IGoodData db)
    {
        _db = db;
    }

    [HttpGet("All")]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await _db.Get();

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

    [HttpGet("{id}", Name = "GetById")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var result = await _db.Get(id);

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

    [HttpGet("ByCategory")]
    public async Task<IActionResult> GetByCategoryId([FromQuery]int CategoryId) 
    {
        try
        {

            var result = await _db.GetByCategoryId(CategoryId);

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

}
