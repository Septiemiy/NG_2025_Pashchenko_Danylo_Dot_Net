using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Refit;
using SentinelAbstraction.Settings;
using SentinelBusinessLayer.Clients;

namespace SentinelBusinessLayer.Injections;
public static class RefitInjections
{
    public static void AddRefitClients(
        this IServiceCollection services,
        IConfiguration configuration,
        IOptions<TreatmentClientSettings> treatmentOptions,
        IOptions<PetClientSettings> petOptions,
        IOptions<StoreClientSettings> storeOptions,
        IOptions<HealthCareClientSettings> healthCareOptions,
        IOptions<VendorClientSettings> vendorOptions)
    {
        var treatmentSettings = treatmentOptions.Value ?? throw new ArgumentNullException(nameof(treatmentOptions));
        var petSettings = petOptions.Value ?? throw new ArgumentNullException(nameof(petOptions));
        var storeSettings = storeOptions.Value ?? throw new ArgumentNullException(nameof(storeOptions));
        var healthCareSettings = healthCareOptions.Value ?? throw new ArgumentNullException(nameof(healthCareOptions));
        var vendorSettings = vendorOptions.Value ?? throw new ArgumentNullException(nameof(vendorOptions));

        services.Configure<TreatmentClientSettings>(action =>
        {
            action.BaseAddress = treatmentSettings.BaseAddress;
        });

        services.Configure<PetClientSettings>(action =>
        {
            action.BaseAddress = petSettings.BaseAddress;
        });

        services.Configure<StoreClientSettings>(action =>
        {
            action.BaseAddress = storeSettings.BaseAddress;
        });

        services.Configure<HealthCareClientSettings>(action =>
        {
            action.BaseAddress = healthCareSettings.BaseAddress;
        });

        services.Configure<VendorClientSettings>(action =>
        {
            action.BaseAddress = vendorSettings.BaseAddress;
        });

        services.AddRefitClient<ITreatmentClient>()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri(treatmentSettings.BaseAddress));

        services.AddRefitClient<IPetClient>()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri(petSettings.BaseAddress));

        services.AddRefitClient<IStoreClient>()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri(storeSettings.BaseAddress));

        services.AddRefitClient<IHealthCareClient>()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri(healthCareSettings.BaseAddress));

        services.AddRefitClient<IVendorClient>()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri(vendorSettings.BaseAddress));
    }
}
