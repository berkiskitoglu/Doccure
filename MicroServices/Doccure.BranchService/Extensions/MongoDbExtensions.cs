using Microsoft.Extensions.Options;
using MongoDB.Driver;

public static class ServiceRegistration
{
    public static IServiceCollection AddMongoDb(this IServiceCollection services,IConfiguration configuration)
    {
        services.Configure<DatabaseSettings>(
            configuration.GetSection("DatabaseSettings"));

        services.AddSingleton<IDatabaseSettings>(sp =>
            sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

        services.AddSingleton<IMongoClient>(sp =>
        {
            var settings = sp.GetRequiredService<IDatabaseSettings>();
            return new MongoClient(settings.ConnectionString);
        });

        services.AddSingleton<IMongoDatabase>(sp =>
        {
            var settings = sp.GetRequiredService<IDatabaseSettings>();
            var client = sp.GetRequiredService<IMongoClient>();

            return client.GetDatabase(settings.DatabaseName);
        });

        return services;
    }
}