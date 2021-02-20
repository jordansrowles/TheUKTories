Epics [![Board Status](https://dev.azure.com/jordansrowles/f361817f-1aa4-4b40-970d-390f45b3439b/0995344b-b3d3-45b8-a3b7-0798a211cd6a/_apis/work/boardbadge/87de1b95-7e7c-4202-9801-f274b0d6e4bb?columnOptions=1)](https://dev.azure.com/jordansrowles/f361817f-1aa4-4b40-970d-390f45b3439b/_boards/board/t/0995344b-b3d3-45b8-a3b7-0798a211cd6a/Microsoft.EpicCategory/)

Tasks [![Board Status](https://dev.azure.com/jordansrowles/f361817f-1aa4-4b40-970d-390f45b3439b/0995344b-b3d3-45b8-a3b7-0798a211cd6a/_apis/work/boardbadge/c7194984-bec9-4c36-a7f2-90fc3c1b2231?columnOptions=1)](https://dev.azure.com/jordansrowles/f361817f-1aa4-4b40-970d-390f45b3439b/_boards/board/t/0995344b-b3d3-45b8-a3b7-0798a211cd6a/Microsoft.RequirementCategory/)

![.NET](https://github.com/jordansrowles/theuktories/workflows/.NET/badge.svg)
[![Build Status](https://dev.azure.com/jordansrowles/TheUKTories/_apis/build/status/jordansrowles.TheUKTories?branchName=master)](https://dev.azure.com/jordansrowles/TheUKTories/_build/latest?definitionId=10&branchName=master)

![alt text](docs/img/Site.png "Main Window")
![alt text](docs/img/MainWindow.png "Main Window")

# Projects
## TheUKTories
The main frontend application to view data, the public website.
- ASP.NET / .NET 5 Razor Pages Web Application
- [GOV.UK Frontend Design System](https://design-system.service.gov.uk/) by UK Government Digital Services
- [GovUk.Frontend.AspNetCore](https://github.com/gunndabad/govuk-frontend-aspnetcore) by gunnadabad
## TheUKTories.DataStores
Data access layer and business objects. Used by the webapp and Dashboard.
- .NET 5 Class Library
- Microsoft.Azure.Cosmos - Cosmos connectivity - without fat-ass EntityFrameworkCore
- Newtonsoft.Json - because I'm too lazy to port to System.Text.Json
## TheUKTories.Dashboard
Administrative access to the data without having to have to fire up the Azure Data Explorer and manually edit json...
- [AdonisUI and AdonisUI.ClassicTheme](https://github.com/benruehl/adonis-ui) by benruehl - A really cool library that brings a plugin dark theme for WPF
- Microsoft.Extensions.Hosting - For when I finally get around to implementing .NET 5 based dependency injection and IoC

__How do I add more data?__
1) Add a model with json related attributes in the `TheUKTories.DataStores.AzureCosmos.Models` directory.
2) Add a public `Container` object to `CosmosDbContext`, config in init
