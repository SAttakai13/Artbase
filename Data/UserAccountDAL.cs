using Artbase.Interfaces;
using Artbase.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Artbase.Data
{
    public class UserAccountDAL : IUserAccount
    {
        private readonly IMongoCollection<Account> _accountCollection;

        public UserAccountDAL(IOptions<ArtbaseDatabaseSettings> artbaseSettings)
        {
            var mongoClient = new MongoClient(artbaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(artbaseSettings.Value.DatabaseName);
            _accountCollection = mongoDatabase.GetCollection<Account>(
                artbaseSettings.Value.AccountCollectionName);
        }

        public async Task CreateAccout(Account account) =>
            await _accountCollection.InsertOneAsync(account);

        //Update might cause some issues, especially with only changing small details in the document. Currently using replace as of right now.
        public async Task EditAccount(string? accountId, Account account) =>
            await _accountCollection.ReplaceOneAsync(accountId, account);

        public async Task RemoveAccount(string? accountId) =>
            await _accountCollection.DeleteOneAsync(x => x.Id == accountId);

        public async Task<Account> GetAccountByUserId(string? accountId)=>
            await _accountCollection.Find(x => x.Id == accountId).FirstOrDefaultAsync();

        public async Task<IEnumerable<Account>> GetAccounts() =>
            await _accountCollection.Find(_ => true).ToListAsync();
        
    }
}
