using Domain.Record.Response.Bank;
using System.Threading.Tasks;

namespace Application.Service.Bank.Interface;

public interface IBankService
{
    Task<BankResponse> GetBanks();
}
