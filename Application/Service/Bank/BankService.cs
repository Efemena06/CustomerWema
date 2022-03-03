using Application.Service.Bank.Interface;
using Domain.Constants;
using Domain.Exception;
using Domain.Record.Response.Bank;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Application.Service.Bank;

public class BankService : IBankService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BankService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<BankResponse> GetBanks()
    {
        using var client = _httpClientFactory.CreateClient(BankConstant.WemaClient);
        var response = await client.GetAsync("api/Shared/GetAllBanks");

        if (response.IsSuccessStatusCode)
            return JsonConvert.DeserializeObject<BankResponse>(await response.Content.ReadAsStringAsync());
        
        throw new NotFoundException(nameof(GetBanks), response.StatusCode);
    }
}
