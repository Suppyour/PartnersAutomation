namespace Backend;

public class Ex
{
    private IServiceCollection? _services;
    public void ConfigServices(IServiceCollection services)
    {
        _services = services;
        services.AddMvc();
        services.AddAuthorization();
        services.
    }
}