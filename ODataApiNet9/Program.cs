using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using ODataApiNet9.Models;

var builder = WebApplication.CreateBuilder(args);

// ✅ ALL SERVICES REGISTERED HERE BEFORE `builder.Build()`
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

builder.Services.AddEndpointsApiExplorer(); // ✅ MOVE THIS UP BEFORE `builder.Build()`
builder.Services.AddSwaggerGen();           // Optional Swagger

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseSwagger();           // Optional Swagger UI
app.UseSwaggerUI();         // Optional Swagger UI

app.MapControllers();

app.Run();
