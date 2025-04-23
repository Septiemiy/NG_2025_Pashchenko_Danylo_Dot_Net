using Microsoft.Extensions.Options;
using SentinelAbstraction.Settings;
using SentinelBusinessLayer.Injections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRefitClients(builder.Configuration,
    Options.Create(
        builder.Configuration.GetSection("RefitClients")
        .GetSection(TreatmentClientSettings.SectionName)
        .Get<TreatmentClientSettings>() ?? new TreatmentClientSettings()),

    Options.Create(
        builder.Configuration.GetSection("RefitClients")
        .GetSection(PetClientSettings.SectionName)
        .Get<PetClientSettings>() ?? new PetClientSettings()),

    Options.Create(
        builder.Configuration.GetSection("RefitClients")
        .GetSection(StoreClientSettings.SectionName)
        .Get<StoreClientSettings>() ?? new StoreClientSettings()),

    Options.Create(
        builder.Configuration.GetSection("RefitClients")
        .GetSection(HealthCareClientSettings.SectionName)
        .Get<HealthCareClientSettings>() ?? new HealthCareClientSettings()),

    Options.Create(
        builder.Configuration.GetSection("RefitClients")
        .GetSection(VendorClientSettings.SectionName)
        .Get<VendorClientSettings>() ?? new VendorClientSettings())
    );

builder.Services.AddSentinelServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
