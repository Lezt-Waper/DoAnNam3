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

            var result = await _httpClient.PostAsJsonAsync<ClientEncrypt>("/Client", clientEncrypt);

            if (!result.IsSuccessStatusCode)
            {
                throw new Exception("Can't create client");
            }

            string temp = await result.Content.ReadAsStringAsync();

            int i;
            if (int.TryParse(temp, out i))
            {
                if (i == 0)
                {
                    throw new Exception("Failed to create");
                }
                else
                {
                    return i;
                }
            }
            else
            {
                throw new Exception("Failed to create");
            }
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
