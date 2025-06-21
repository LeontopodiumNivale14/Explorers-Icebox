using System.IO;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;

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
}
