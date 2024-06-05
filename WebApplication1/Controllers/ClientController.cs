using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Repository.Model;
using RSA_Encrypt.RSALib;
using Newtonsoft.Json;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : Controller
{
    private readonly IClientData _db;
    private readonly RSA RSA;
    private readonly ILogger _logger;

    public ClientController(IClientData db, RSA rsa, ILogger<ClientController> logger)
    {
        _db = db;
        RSA = rsa;
        _logger = logger;
    }

    [HttpGet]
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

    [HttpGet("RSAKey")]
    public IActionResult GetKey() 
    {
        var Key = new { N = RSA.N, P = RSA.PublicKey };
        return Ok(Key);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ClientEncrypt clientEncrypt, [FromQuery] long n, [FromQuery] long pKey)
    {
        //Logging data receive
        _logger.LogInformation("Client Data Server Receive\n" + JsonConvert.SerializeObject(clientEncrypt, Formatting.Indented));
        try
        {
            Client client = Decrypt(clientEncrypt);
            //Logging decrypted data
            _logger.LogInformation("Decrypted Client Data\n" + JsonConvert.SerializeObject(client, Formatting.Indented));

            var result = await _db.Create(client);

            if (result == 0)
            {
                return BadRequest();    
            }

            _logger.LogInformation($"Client Id: {result}");

            RSA.SetKey(n, pKey);
            IEnumerable<long> encryptedResult = RSA.Encrypt($"{result}");

            _logger.LogInformation("Encrypted Client Id\n" + JsonConvert.SerializeObject(encryptedResult, Formatting.Indented));

            return Ok(encryptedResult);
        }
        catch (Exception)
        {

            throw;
        }
    }

    private Client Decrypt(ClientEncrypt clientEncrypt)
    {
        Client result = new Client();

        result.Name = RSA.Decrypt(clientEncrypt.Name);
        result.PhoneNumber = RSA.Decrypt(clientEncrypt.PhoneNumber);
        result.Credit = RSA.Decrypt(clientEncrypt.Credit);
        result.Address = RSA.Decrypt(clientEncrypt.Address);

        return result;
    }
}
