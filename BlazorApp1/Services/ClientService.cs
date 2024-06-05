using Repository.Model;
using RSA_Encrypt.RSALib;
using Newtonsoft.Json;


namespace BlazorApp1.Services;

public class ClientService : IClientService
{
    private readonly HttpClient _httpClient;
    private readonly RSA RSA;
    private readonly ILogger _logger;

    public ClientService(HttpClient httpClient, RSA rsa, ILogger<ClientService> logger)
    {
        _httpClient = httpClient;
        RSA = rsa;
        _logger = logger;
    }

    public async Task<int> Create(Client client)
    {
        //Get RSA public key 
        await GetKey();

        //Logging the client data
        _logger.LogInformation("Origin Client Data\n" + JsonConvert.SerializeObject(client, Formatting.Indented));
        try
        {

            ClientEncrypt clientEncrypt = Encrypt(client);
            //Logging the encrypted client data
            _logger.LogInformation("Encrypted Client Data\n" + JsonConvert.SerializeObject(clientEncrypt, Formatting.Indented));

            var result = await _httpClient.PostAsJsonAsync<ClientEncrypt>($"/Client?n={RSA.N}&pKey={RSA.PublicKey}", clientEncrypt);

            if (!result.IsSuccessStatusCode)
            {
                throw new Exception("Can't create client");
            }

            var encryptedClientId = await result.Content.ReadFromJsonAsync<IEnumerable<long>>();

            if (encryptedClientId is null)
            {
                throw new Exception("Can't create client");
            }

            _logger.LogInformation("Encrypted Client Id\n" + JsonConvert.SerializeObject(encryptedClientId, Formatting.Indented));

            var clientId = RSA.Decrypt(encryptedClientId);

            _logger.LogInformation("Client Id\n" + JsonConvert.SerializeObject(clientId, Formatting.Indented));

            return Convert.ToInt32(clientId);
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task GetKey()
    {
        try
        {
            var result = await _httpClient.GetFromJsonAsync<Key>("/Client/RSAKey");

            if (result is null)
            {
                throw new Exception("Can't get rsa key");
            }

            RSA.SetKey(result.N, result.P);

        }
        catch (Exception)
        {

            throw;
        }
    }

    private ClientEncrypt Encrypt(Client client)
    {
        ClientEncrypt result = new ClientEncrypt();
        result.Name = RSA.Encrypt(client.Name).ToList();
        result.PhoneNumber = RSA.Encrypt(client.PhoneNumber).ToList();
        result.Credit = RSA.Encrypt(client.Credit).ToList();
        result.Address = RSA.Encrypt(client.Address).ToList();

        return result;
    }

}

public record Key(long N, long P);
