using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace Mahjong.Model.Configs;

public static class ConfigurationBuilderExtensions
{
    /// <summary>
    /// appsettings.jsonを設定ファイルとして読み込みます。
    /// </summary>
    /// <param name="configuration"></param>
    public static IConfigurationBuilder AddSettingsJson(this IConfigurationBuilder configuration)
    {
        configuration.AddJsonFile("appsettings.json");
        configuration.AddSettingsJsonForDebug();
        return configuration;
    }

    /// <summary>
    /// デバッグ時のみ実行されます。
    /// appsettings.Debug.jsonを設定ファイルとして読み込みます。
    /// </summary>
    /// <param name="configuration"></param>
    [Conditional("DEBUG")]
    private static void AddSettingsJsonForDebug(this IConfigurationBuilder configuration)
    {
        configuration.AddJsonFile("appsettings.Debug.json");
    }
}
