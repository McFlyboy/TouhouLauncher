using TouhouLauncher.Models.Infrastructure;
using TouhouLauncher.Models.Infrastructure.Extensions;
using Xunit;
using static TouhouLauncher.Test.CommonTestToolsAndData;

namespace TouhouLauncher.Test.Models.Infrastructure {
	public class YamlSerializerServiceTest {
		private readonly YamlSerializerService _yamlSerializerService = YamlSerializerService.Instance;

		[Fact]
		public void Serializes_objects_to_yaml_formatted_strings() {
			var resultFromString = _yamlSerializerService.Serialize("Hello");
			var resultFromInt = _yamlSerializerService.Serialize(3);
			var resultFromBool = _yamlSerializerService.Serialize(true);
			var resultFromNull = _yamlSerializerService.Serialize(null);
			var resultFromSimpleObject = _yamlSerializerService.Serialize(new SimpleType() { Text = "Hello", Number = 3 });

			Assert.Equal($"Hello{LineBreak}", resultFromString);
			Assert.Equal($"3{LineBreak}", resultFromInt);
			Assert.Equal($"true{LineBreak}", resultFromBool);
			Assert.Equal($"--- {LineBreak}", resultFromNull);
			Assert.Equal($"text: Hello{LineBreak}number: 3{LineBreak}", resultFromSimpleObject);
		}

		[Fact]
		public void Deserializes_yaml_formatted_strings_to_objects() {
			var emptyResult = _yamlSerializerService.Deserialize<object>("");
			var nonsenseResult = _yamlSerializerService.Deserialize<int>("grer43t4q3g43rab b fewfe2");
			var stringResult = _yamlSerializerService.Deserialize<string>("Hello");
			var intResult = _yamlSerializerService.Deserialize<int>("3");
			var boolResult = _yamlSerializerService.Deserialize<bool>("true");
			var nullResult = _yamlSerializerService.Deserialize<object>("--- ");
			var simpleObjectResult = _yamlSerializerService.Deserialize<SimpleType>($"text: Hello{LineBreak}number: 3{LineBreak}");

			Assert.Null(emptyResult);
			Assert.Equal(default, nonsenseResult);
			Assert.Equal("Hello", stringResult);
			Assert.Equal(3, intResult);
			Assert.True(boolResult);
			Assert.Null(nullResult);
			Assert.Equal(new() { Text = "Hello", Number = 3 }, simpleObjectResult);
		}

		[Fact]
		public void Yaml_object_turns_into_yaml_string() {
			var yamlObject = yamlTestTypeObject;

			var result = yamlObject.ToYamlString();

			Assert.Equal(yamlTestTypeObjectAsString, result);
		}

		[Fact]
		public void Yaml_string_turns_into_yaml_object() {
			var yamlString = yamlTestTypeObjectAsString;

			var result = yamlString.ToYamlObject<YamlTestType>();

			Assert.Equal(yamlTestTypeObject, result);
		}
	}
}
