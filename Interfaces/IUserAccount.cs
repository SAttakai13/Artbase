using Artbase.Models;

namespace Artbase.Interfaces
{
    public interface IUserAccount
    {
        void CreateAccout(Account account);
        void RemoveAccount(string? userId);
        void EditAccount(Account account);
        IEnumerable<Account> GetAccounts();
        IEnumerable<Account> SearchAccounts(string? name);
        Account GetAccountByUserId(string? accountId);
    }
}
