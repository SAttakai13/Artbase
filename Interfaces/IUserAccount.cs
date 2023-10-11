using Artbase.Models;

namespace Artbase.Interfaces
{
    public interface IUserAccount
    {
        Task CreateAccout(Account account);
        Task RemoveAccount(string? accountId);
        Task EditAccount(string? accountId, Account account);
        Task<IEnumerable<Account>> GetAccounts();
        Task<Account?> GetAccountByUserId(string? accountId);
    }
}
