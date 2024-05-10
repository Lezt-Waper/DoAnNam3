using Microsoft.AspNetCore.Mvc;
using Repository.Data;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : Controller
{
    private readonly ICategoryData _db;
    public CategoryController(ICategoryData db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result =  await _db.Get();

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

    [HttpGet("{id}")]
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
}
