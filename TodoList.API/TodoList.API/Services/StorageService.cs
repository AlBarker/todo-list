using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.API.Infrastructure;
using TodoList.API.Models;

namespace TodoList.API.Services
{
    public class StorageService<TEntity> : IStorageService<TEntity> where TEntity : BaseEntity, new ()
    {
        private readonly IOptions<Settings> _settings;

        public StorageService(IOptions<Settings> settings)
        {
            _settings = settings;
        }

        #region Exposed Methods
        public async Task<TEntity> Add(TEntity entity)
        {
            // Create the TableOperation that inserts the customer entity.
            TableOperation insertOperation = TableOperation.Insert(entity);

            var table = await GetCloudTable();
            // TODO Fix exception here on duplicate

            TableOperation retrieve = TableOperation.Retrieve<TEntity>(entity.PartitionKey, entity.RowKey);
            TableResult result = await table.ExecuteAsync(retrieve);

            if (result.Result != null)
            {
                return null;
            }

            // Execute the insert operation.
            await table.ExecuteAsync(insertOperation);
            return entity;
        }

        public void Delete(TEntity t)
        {
            throw new System.NotImplementedException();
        }

        public async Task<TEntity> Get(string id)
        {
            var table = await GetCloudTable();

            // Create a retrieve operation that takes a customer entity.
            TableOperation retrieveOperation = TableOperation.Retrieve<TEntity>("Smith", "Ben");

            // Execute the retrieve operation.
            TableResult retrievedResult = await table.ExecuteAsync(retrieveOperation);

            // Print the phone number of the result.
            if (retrievedResult.Result != null)
            {
                return (TEntity)retrievedResult.Result;
            }
        }

        public async Task<List<TEntity>> GetAll()
        {
            var table = await GetCloudTable();

            TableContinuationToken token = null;
            var entities = new List<TEntity>();
            do
            {
                var queryResult = await table.ExecuteQuerySegmentedAsync(new TableQuery<TEntity>(), token);
                entities.AddRange(queryResult.Results);
                token = queryResult.ContinuationToken;
            } while (token != null);

            return entities.OrderBy(x => x.Timestamp).ToList();
        }

        public TEntity Update(TEntity t)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Private methods
        private async Task<CloudTable> GetCloudTable()
        {
            var cloudTable = GetCloudTableReference();

            // Create the table if it doesn't exist.
            await cloudTable.CreateIfNotExistsAsync();

            return cloudTable;
        }

        private CloudTable GetCloudTableReference()
        {
            // Retrieve the storage account from the connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_settings.Value.StorageConnectionString);

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Retrieve a reference to the table.
            return tableClient.GetTableReference(nameof(TEntity));
        }
        #endregion
    }
}
