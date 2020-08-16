using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace TouhouLauncher.Model.Serialization {
	class SerializerService {
		private readonly ISerializer _serializer;
		private readonly IDeserializer _deserializer;

		public SerializerService() {
			_serializer = new SerializerBuilder().Build();
			_deserializer = new DeserializerBuilder()
				.WithNamingConvention(CamelCaseNamingConvention.Instance)
				.Build();
		}

		public void SerializeToFile<T> (T graph, string filePath) {
			using var writer = File.CreateText(filePath);
			_serializer.Serialize(writer, graph);
		}
		public T DeserializeFromFile<T>(string filePath) {
			if(!File.Exists(filePath)) {
				return default;
			}
			using var reader = new StreamReader(filePath);
			return _deserializer.Deserialize<T>(reader);
		}
	}
}
