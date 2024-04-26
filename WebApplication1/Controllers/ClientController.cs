using Microsoft.AspNetCore.Mvc;
using Repository.ClientRepository;
using Repository.Entity;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CLientController : Controller
    {
        private readonly IClientRepository clientRepository;
        public CLientController(IClientRepository  clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await clientRepository.GetClient();

                if (result == null)
                {
                    throw new Exception("Can't get clients");
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
                var result = await clientRepository.GetClient(id);

                if (result == null)
                {
                    throw new Exception("Can't get client");
                }

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Client client)
        {
            try
            {
                var result = await clientRepository.CreateClient(client);

                if (result == 0)
                {
                    throw new Exception("Can't create client");
                }

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }   
    }
}
