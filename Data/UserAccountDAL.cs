using Artbase.Interfaces;
using Artbase.Models;

namespace Artbase.Data
{
    public class UserAccountDAL : IUserAccount
    {
        
        public void CreateAccout(Account account)
        {
            throw new NotImplementedException();
        }

        public void EditAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public void RemoveAccount(string? userId)
        {
            throw new NotImplementedException();
        }

        public Account GetAccountByUserId(string? accountId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> SearchAccounts(string? name)
        {
            throw new NotImplementedException();
        }
    }
}
