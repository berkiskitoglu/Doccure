public static class AutoMapperExtensions
{
    public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(GeneralMapping));

        return services;
    }
}