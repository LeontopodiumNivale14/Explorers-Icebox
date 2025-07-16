using ECommons.Logging;
using System.IO;
using System.Reflection;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

public static class YamlConfig
{
    private static readonly ISerializer Serializer = new SerializerBuilder()
        .WithNamingConvention(CamelCaseNamingConvention.Instance)
        .Build();

    private static readonly IDeserializer Deserializer = new DeserializerBuilder()
        .WithNamingConvention(CamelCaseNamingConvention.Instance)
        .IgnoreUnmatchedProperties()
        .Build();

    public static T Load<T>(string path) where T : new()
    {
        if (!File.Exists(path))
        {
            var defaultConfig = new T();
            Save(defaultConfig, path);
            return defaultConfig;
        }

        var yaml = File.ReadAllText(path);
        return Deserializer.Deserialize<T>(yaml) ?? new T();
    }

    public static void Save<T>(T config, string path)
    {
        var yaml = Serializer.Serialize(config);
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        File.WriteAllText(path, yaml);
    }

    public static T LoadFromResource<T>(string resourceName) where T : new()
    {
        var assembly = Assembly.GetExecutingAssembly();

        using Stream? stream = assembly.GetManifestResourceStream(resourceName);
        if (stream == null)
        {
            PluginLog.Warning($"Could not find embedded resource: {resourceName}");
            return new T();
        }

        using var reader = new StreamReader(stream);
        var yaml = reader.ReadToEnd();

        return Deserializer.Deserialize<T>(yaml) ?? new T();
    }
}
