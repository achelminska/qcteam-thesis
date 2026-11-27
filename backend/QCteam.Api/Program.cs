using Microsoft.EntityFrameworkCore;
using QCteam.Infrastructure;
using QCteam.SharedKernel;
using QCteam.Modules.Catalog.Features;
using QCteam.Modules.Catalog.Features.CreateSupplier;
using QCteam.Modules.Catalog.Features.GetSupplier;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IAppDbContext>(sp => sp.GetRequiredService<AppDbContext>());

// Catalog
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<CreateSupplierHandler>();
builder.Services.AddScoped<GetSupplierHandler>();

builder.Services.AddControllers()
    .AddApplicationPart(typeof(CreateSupplierEndpoint).Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();