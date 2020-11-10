using System.IO;
using TouhouLauncher.Services.Infrastructure.Serialization;
using Xunit;

namespace TestCore.Services.Infrastructure.Serialization {
	public class YamlFileSerializerServiceTest {
		private readonly YamlFileSerializerService _fileSerializerService;

		public YamlFileSerializerServiceTest() {
			_fileSerializerService = new YamlFileSerializerService();
		}

		[Fact]
		public void ShouldReturnDefaultWhenUnableToSerialize() {
			string filePath = "TestObjects\\NonExistingFile";

			Assert.False(File.Exists(filePath));

			var failedObject = _fileSerializerService
				.DeserializeFromFile<CommonTestTools.SerializableClass>(filePath);

			Assert.Equal(default, failedObject);
			Assert.Null(failedObject);
		}

		[Fact]
		public void ShouldSerializeObjectToFile() {
			string filePath = "TestObjects\\SerializedObject.yaml";

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
	}
}
