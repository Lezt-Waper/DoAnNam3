using Microsoft.AspNetCore.Mvc;
using Repository.Entity;
using Repository.GoodRepository;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoodController : Controller
    {
        private readonly IGoodRepository repository;

        public GoodController(IGoodRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Good>> GetGoods()
        {
            try
            {
                var result = await repository.Get();

                if (result == null)
                {
                    throw new Exception("Something wrong in database");
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Good>> GetGood(int id)
        {
            try
            {
                var result = await repository.Get(id);

                if (result == null)
                {
                    throw new Exception("Something wrong in Database");   
                }

                return result;
            }
            catch (IndexOutOfRangeException)
            {
                return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
