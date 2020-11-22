using System;
using System.IO;
using TouhouLauncher.Services.Infrastructure.Serialization;
using Xunit;

namespace TouhouLauncher.Test.Services.Infrastructure.Serialization {
	public class YamlFileSerializerServiceTest : IDisposable {
		private readonly YamlFileSerializerService _fileSerializerService;
		private const string _testDir = "TestObjects";
		private const string _testFile = "SerializedObject.yaml";

		public YamlFileSerializerServiceTest() {
			_fileSerializerService = new YamlFileSerializerService();
			if (!Directory.Exists(_testDir)) {
				Directory.CreateDirectory(_testDir);
			}
		}

		[Fact]
		public void Returns_default_when_unable_to_deserialize() {
			string filePath = $"{_testDir}\\NonExistingFile";

			Assert.False(File.Exists(filePath));

			var failedObject = _fileSerializerService
				.DeserializeFromFile<CommonTestTools.SerializableClass>(filePath);

			Assert.Equal(default, failedObject);
			Assert.Null(failedObject);
		}

		[Fact]
		public void Serializes_object_to_file() {
			string filePath = $"{_testDir}\\{_testFile}";

			var testObject = new CommonTestTools.SerializableClass() {
				Number = 3,
				Text = "Hello",
				SubClass = new CommonTestTools.SerializableClass.SerializableSubClass() {
					DecimalNumber = 0.35F,
					LongNumber = 68L,
					Letter = 'y'
				},
				Bool = true
			};

			_fileSerializerService.SerializeToFile(testObject, filePath);

			Assert.True(File.Exists(filePath));

			var sameTestObject = _fileSerializerService
				.DeserializeFromFile<CommonTestTools.SerializableClass>(filePath);

			Assert.NotNull(sameTestObject);
			Assert.Equal(testObject, sameTestObject);
		}

		public void Dispose() {
			Directory.Delete(_testDir, true);
		}
	}
}
