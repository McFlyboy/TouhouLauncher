using TouhouLauncher.Models.Infrastructure;
using TouhouLauncher.Models.Infrastructure.Extensions;
using Xunit;
using static TouhouLauncher.Test.CommonTestToolsAndData;

namespace TouhouLauncher.Test.Models.Infrastructure {
	public class YamlSerializerServiceTest {
		private readonly YamlSerializerService _yamlSerializerService = YamlSerializerService.Instance;

		[Fact]
		public void Serializes_objects_to_yaml_formatted_strings() {
			string resultFromSimpleObject = _yamlSerializerService.Serialize(new SimpleType() { Text = "Hello", Number = 3 });

			Assert.Equal($"text: Hello{LineBreak}number: 3{LineBreak}", resultFromSimpleObject);
		}

		[Fact]
		public void Deserializes_yaml_formatted_strings_to_objects() {
			var emptyResult = _yamlSerializerService.Deserialize<object>("");
			var nonsenseResult = _yamlSerializerService.Deserialize<object>("grer43t4q3g43rab b fewfe2");
			var nullResult = _yamlSerializerService.Deserialize<object>("--- ");
			var simpleObjectResult = _yamlSerializerService.Deserialize<SimpleType>($"text: Hello{LineBreak}number: 3{LineBreak}");

			Assert.True(emptyResult.IsLeft);
			Assert.Equal("grer43t4q3g43rab b fewfe2", nonsenseResult.GetRight());
			Assert.True(nullResult.IsLeft);
			Assert.Equal(new() { Text = "Hello", Number = 3 }, simpleObjectResult.GetRight());
		}

		[Fact]
		public void Yaml_object_turns_into_yaml_string() {
			YamlTestType yamlObject = yamlTestTypeObject;

			string result = yamlObject.ToYamlString();

			Assert.Equal(yamlTestTypeObjectAsString, result);
		}

		[Fact]
		public void Yaml_string_turns_into_yaml_object() {
			string yamlString = yamlTestTypeObjectAsString;

			var result = yamlString.ToYamlObject<YamlTestType>();

			Assert.True(result.IsRight);
			Assert.Equal(yamlTestTypeObject, result.GetRight());
		}
	}
}
