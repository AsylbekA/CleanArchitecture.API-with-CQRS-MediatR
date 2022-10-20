using Microsoft.Extensions.Configuration;

namespace CleanArhcitecture.Application.Helper.Redis.RedisHelper;

public static class RedisConfigurationManager
{
    public static IConfiguration AppSetting { get; }

    static RedisConfigurationManager()
    {
        AppSetting = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
    }
}
