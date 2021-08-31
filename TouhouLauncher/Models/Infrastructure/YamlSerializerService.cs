using System;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace TouhouLauncher.Models.Infrastructure {
	public class YamlSerializerService {
		private readonly ISerializer _serializer;
		private readonly IDeserializer _deserializer;

		private YamlSerializerService() {
			_serializer = new SerializerBuilder()
				.WithNamingConvention(HyphenatedNamingConvention.Instance)
				.DisableAliases()
				.Build();

			_deserializer = new DeserializerBuilder()
				.WithNamingConvention(HyphenatedNamingConvention.Instance)
				.IgnoreUnmatchedProperties()
				.Build();
		}

		public string Serialize<T>(T graph) where T : class, new() =>
			_serializer.Serialize(graph);

		public T? Deserialize<T>(string yaml) where T : class, new() {
			try {
				return _deserializer.Deserialize<T>(yaml);
			}
			catch (Exception) {
				return null;
			}
		}

		static YamlSerializerService() => Instance = new();

		public static YamlSerializerService Instance { get; }
	}

	public abstract record Yaml;

	namespace Extensions {
		public static class YamlStringExtensions {
			public static string ToYamlString<TYaml>(this TYaml yamlObject) where TYaml : Yaml, new() =>
				YamlSerializerService.Instance.Serialize(yamlObject);

			public static TYaml? ToYamlObject<TYaml>(this string yamlString) where TYaml : Yaml, new() =>
				YamlSerializerService.Instance.Deserialize<TYaml>(yamlString);
		}
	}
}
