![.NET](https://github.com/jordansrowles/theuktories/workflows/.NET/badge.svg)

# TheUKTories

- [GOV.UK Design System](https://design-system.service.gov.uk/)
- [github/govuk-frontend-aspnetcore](https://github.com/gunndabad/govuk-frontend-aspnetcore/)

__How do I add more data?__
1) Add a model with json related attributes in the `TheUKTories.DataStores.AzureCosmos.Models` directory.
2) Add a public `Container` object to `CosmosDbContext`, config in init
