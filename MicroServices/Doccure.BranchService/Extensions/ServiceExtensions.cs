public static class ServiceExtensions
{
    public static IServiceCollection AddBranchServices(this IServiceCollection services)
    {
        services.AddScoped<IBranchService, BranchService>();

        return services;
    }
}