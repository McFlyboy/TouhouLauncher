﻿using System;
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

		public string Serialize(object graph) => _serializer.Serialize(graph);

		public T Deserialize<T>(string yaml) {
			try {
				return _deserializer.Deserialize<T>(yaml);
			}
			catch (Exception) {
				return default;
			}
		}

		static YamlSerializerService() => Instance = new();

		public static YamlSerializerService Instance { get; }
	}

	public abstract record Yaml {
		public string ToYamlString() => YamlSerializerService.Instance.Serialize(this);
	}

	namespace Extensions {
		public static partial class StringExtensions {
			public static TYaml ToYamlObject<TYaml>(this string yamlString) where TYaml : Yaml =>
				YamlSerializerService.Instance.Deserialize<TYaml>(yamlString);
		}
	}
}
