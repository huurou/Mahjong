using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Mahjong.Model.Configs;

public static class LoggingBuilderExtensions
{
    public static ILoggingBuilder Configure(this ILoggingBuilder builder, IConfiguration configuration)
    {
        builder.AddConfiguration(configuration.GetSection("Logging"));
        return builder;
    }
}
