var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Aspire_Momento_ApiService>("Aspireapiservice");

builder.AddProject<Projects.Aspire_Momento_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);
builder.AddProject<Projects.ASP_Net_API_Memento>("Coreapiservice");

builder.Build().Run();
