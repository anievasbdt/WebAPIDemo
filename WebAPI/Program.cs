using Aplicacion.Services;
using Aplicacion.Servicios;
using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Repositorys;
using Dominio.Contracts.Services;
using Dominio.Contracts.Servicios;
using Infraestructura.Persistence;
using Infraestructura.Persistence.Repositorys;
using Infraestructura.Persistencia;
using Infraestructura.Persistencia.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Oracle.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

// Configura el DbContext con Oracle
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseOracle("Data Source=localhost:1521/XEPDB1;User Id=adminProyecto;Password=adminProyecto;")
           .ConfigureWarnings(w => w.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning));
});

// Inyección de dependencias

builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IMunicipalityService, MunicipalityService>();
builder.Services.AddScoped<IMunicipalityRepository, MunicipalityRepository>();
builder.Services.AddScoped<INacionalityService, NacionalityService>();
builder.Services.AddScoped<INacionalityRepository, NacionalityRepository>();
builder.Services.AddScoped<INMPolizaService, NMPolizaService>();
builder.Services.AddScoped<INMPolizaRepository, NMPolizaRepository>();
builder.Services.AddScoped<INMPremiumService, NMPremiumService>();
builder.Services.AddScoped<INMPremiumRepository, NMPremiumRepository>();
builder.Services.AddScoped<IPolizaHistoryService, PolizaHistoryService>();
builder.Services.AddScoped<IPolizaHistoryRepository, PolizaHistoryRepository>();
builder.Services.AddScoped<IPolizaService, PolizaService>();
builder.Services.AddScoped<IPolizaRepository, PolizaRepository>();
builder.Services.AddScoped<IPremiumService, PremiumService>();
builder.Services.AddScoped<IPremiumRepository, PremiumRepository>();
builder.Services.AddScoped<IProductMasterService, ProductMasterService>();
builder.Services.AddScoped<IProductMasterRepository, ProductMasterRepository>();
builder.Services.AddScoped<IProvinceService, ProvinceService>();
builder.Services.AddScoped<IProvinceRepository, ProvinceRepository>();
builder.Services.AddScoped<ISexService, SexService>();
builder.Services.AddScoped<ISexRepository, SexRepository>();
builder.Services.AddScoped<ITabLocatService, TabLocatService>();
builder.Services.AddScoped<ITabLocatRepository, TabLocatRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IWayPayService, WayPayService>();
builder.Services.AddScoped<IWayPayRepository, WayPayRepository>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();