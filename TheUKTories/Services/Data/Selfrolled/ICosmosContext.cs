using Microsoft.Azure.Cosmos;

namespace TheUKTories.Services.Data.Selfrolled
{
    public interface ICosmosContext
    {
        public Container CovidResponsesContainer { get; set; }
        public Container CovidContractsContainer { get; set; }
        public Container AusterityContainer { get; set; }
        public Container TacticsContainer { get; set; }
        public Container PeopleContainer { get; set; }
        public Container ISCReportContainer { get; set; }
        public Container ContactsContainer { get; set; }
        public Container GovCovidContractsContainer { get; set; }
        public Container ExternalLinksContainer { get; set; }

        Task<List<T>> ItemFeedAsync<T>(Container container);
        Task<List<T>> GetDocumentsAsync<T>(Container container, string query);
        Task<List<T>> GetDocumentsAsync<T>(Container container);
        Task<int> CountDocumentsAsync<T>(Container container);
        Task<T> ReadItemAsync<T>(string id, PartitionKey partitionKey, Container container);
        Task<T> InsertAsync<T>(T item, PartitionKey partitionKey, Container container);
        Task<T> UpsertAsync<T>(T item, PartitionKey partitionKey, Container container);
        Task<T> DeleteItemAsync<T>(string id, PartitionKey partitionKey, Container container);
    }
}