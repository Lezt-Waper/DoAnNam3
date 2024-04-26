using Microsoft.AspNetCore.Mvc;
using Repository.ClientRepository;
using Repository.Entity;
using Repository.OrderRepository;
using RSA_Encrypt.RSALib;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class OrderController : Controller
    {
        private RSA rsa;
        private readonly IOrderRepository orderRepository;
        private readonly IClientRepository clientRepository;

        public OrderController(RSA rsa, IOrderRepository orderRepository, IClientRepository clientRepository)
        {
            this.rsa = rsa;
            this.orderRepository = orderRepository;
            this.clientRepository = clientRepository;
        }

        [HttpGet]
        public ActionResult<PublicKey> GetPublicKey()
        {
            PublicKey result = new PublicKey(rsa.N, rsa.PublicKey);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            try
            {
                var clientResult = await clientRepository.CreateClient(order.Client);
                var orderResult = await orderRepository.CreateOrder(order);

                if (orderResult == 0 || clientResult == 0)
                {
                    throw new Exception("Can't create the order");
                }

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    public record PublicKey(long N, long P);
}
