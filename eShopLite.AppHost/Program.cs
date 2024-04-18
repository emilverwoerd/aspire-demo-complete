var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddSqlServer("sqlaspire")
        .AddDatabase("ProductsContext");

var productsApi = builder.AddProject<Projects.Products>("products")
    .WithReference(db);

builder.AddProject<Projects.Store>("store")
    .WithReference(productsApi);

builder.Build().Run();
