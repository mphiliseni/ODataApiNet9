using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using ODataApiNet9.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddOData(opt =>
    {
        var odataBuilder = new ODataConventionModelBuilder();
        odataBuilder.EntitySet<Product>("Products");
        opt.AddRouteComponents("odata", odataBuilder.GetEdmModel())
            .Select()
            .Filter()
            .OrderBy()
            .Expand()
            .SetMaxTop(100)
            .Count();
    });

builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();          

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseSwagger();           // Optional Swagger UI
app.UseSwaggerUI();         // Optional Swagger UI

app.MapControllers();

app.Run();
