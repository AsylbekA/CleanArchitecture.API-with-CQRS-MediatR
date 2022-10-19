using CleanArchitecture.Domain.Contracts;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArhcitecture.Application.Helper.Redis.RedisHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace CleanArhcitecture.Application.Helper.RedisHelper;

//public static class RedisConnectorHelper
//{
//    static RedisConnectorHelper()
//    {
//        lazyConnection = new Lazy<ConnectionMultiplexer>(() => {
//            return ConnectionMultiplexer.Connect("127.0.0.1:6379"); //RedisConfigurationManager.AppSetting["RedisCacheUrl"]
//        });
//    }
//    private  static Lazy<ConnectionMultiplexer> lazyConnection;
//    public static ConnectionMultiplexer Connection
//    {
//        get { return lazyConnection.Value; }
//    }
//}

public class RedisConnectorHelper
{
    static RedisConnectorHelper()
    {
        RedisConnectorHelper.lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect("localhost");
        });
    }

    private static Lazy<ConnectionMultiplexer> lazyConnection;

    public static ConnectionMultiplexer Connection
    {
        get
        {
            return lazyConnection.Value;
        }
    }
}