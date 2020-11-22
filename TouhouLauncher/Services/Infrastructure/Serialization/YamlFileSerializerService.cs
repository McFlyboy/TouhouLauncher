using System;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace TouhouLauncher.Services.Infrastructure.Serialization {
	public class YamlFileSerializerService : IFileSerializerService {
		private readonly ISerializer _serializer;
		private readonly IDeserializer _deserializer;

		public YamlFileSerializerService() {
			_serializer = new SerializerBuilder()
				.WithNamingConvention(HyphenatedNamingConvention.Instance)
				.Build();
			_deserializer = new DeserializerBuilder()
				.WithNamingConvention(HyphenatedNamingConvention.Instance)
				.Build();
		}

		public string FileLastName => "yaml";

		public virtual bool SerializeToFile<T>(T graph, string filePath) {
			try {
				using var writer = File.CreateText(filePath);
				_serializer.Serialize(writer, graph);
				return true;
			}
			catch (Exception) {
				return false;
			}
		}

		public virtual T DeserializeFromFile<T>(string filePath) {
			if(!File.Exists(filePath)) {
				return default;
			}
			try {
				using var reader = new StreamReader(filePath);
				return _deserializer.Deserialize<T>(reader);
			}
			catch (Exception) {
				return default;
			}
		}
	}
}
