﻿using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheUKTories.DataStores.AzureCosmos
{
    public interface ICosmosDbContext
    {
        Task<List<T>> ItemFeedAsync<T>(Container container);
        Task<List<T>> GetDocumentsAsync<T>(Container container, string query);
        Task<List<T>> GetDocumentsAsync<T>(Container container);
        Task<T> ReadItemAsync<T>(string id, PartitionKey partitionKey, Container container);
        Task<T> InsertAsync<T>(T item, PartitionKey partitionKey, Container container);
        Task<T> UpsertAsync<T>(T item, PartitionKey partitionKey, Container container);
        Task<T> DeleteItemAsync<T>(string id, PartitionKey partitionKey, Container container);
    }
}