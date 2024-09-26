var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AspireMomento_ApiService>("apiservice");

builder.AddProject<Projects.AspireMomento_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.AddProject<Projects.ASP_Net_API_Memento>("asp-net-api-memento");

builder.Build().Run();
