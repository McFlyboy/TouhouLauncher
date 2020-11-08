using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using TouhouLauncher.Services.Infrastructure.Serialization;

namespace Test.Services.Serialization {
	[TestClass]
	public class SerializerServiceTest {
		private readonly YamlFileSerializerService _fileSerializerService = new YamlFileSerializerService();

		[TestMethod]
		public void ShouldReturnDefaultWhenUnableToSerialize() {
			string filePath = "TestObjects\\NonExistingFile";

			Assert.IsFalse(File.Exists(filePath));

			var failedObject = _fileSerializerService
				.DeserializeFromFile<CommonTestTools.SerializableClass>(filePath);

			Assert.AreEqual(failedObject, default);
			Assert.IsNull(failedObject);
		}

		[TestMethod]
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
			
			Assert.IsTrue(File.Exists(filePath));

			var sameTestObject = _fileSerializerService
				.DeserializeFromFile<CommonTestTools.SerializableClass>(filePath);

			Assert.IsNotNull(sameTestObject);
			Assert.AreEqual(testObject, sameTestObject);
		}
	}
}
