﻿namespace TheUKTories.Services.Data.Selfrolled
{
    using Microsoft.Azure.Cosmos;
    using TheUKTories.Services.Data.Selfrolled.Models;

    public static class ContextExtensions
    {
        public static async Task<Person> GetPerson(this ICosmosContext context, string id, string partition)
        {
            return await context.ReadItemAsync<Person>(id, new PartitionKey(partition), context.PeopleContainer);
        }

        public static async Task<Person> TryGetPerson(this ICosmosContext context, string id)
        {
            return await context.ReadItemAsync<Person>(id, PartitionKey.None, context.PeopleContainer);
        }

        public static async Task<ARTactics> GetTactic(this ICosmosContext context, string id, string partition)
        {
            return await context.ReadItemAsync<ARTactics>(id, new PartitionKey(partition), context.TacticsContainer);
        }

        public static async Task<ARTactics> TryGetTactic(this ICosmosContext context, string id)
        {
            return await context.ReadItemAsync<ARTactics>(id, new PartitionKey(id), context.TacticsContainer);
        }
    }
}
