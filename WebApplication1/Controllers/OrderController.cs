using Microsoft.AspNetCore.Mvc;
using RSA_Encrypt.RSALib;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class OrderController : Controller
    {
        private RSA rsa;

        public OrderController(RSA rsa)
        {
            this.rsa = rsa;
        }

        [HttpGet]
        public ActionResult<PublicKey> GetPublicKey()
        {
            PublicKey result = new PublicKey(rsa.N, rsa.PublicKey);
            return Ok(result);
        }
    }

    public record PublicKey(long N, long P);
}
