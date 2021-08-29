#nullable disable

using IniParser;
using IniParser.Model;
using TouhouLauncher.Models.Infrastructure;
using TouhouLauncher.Models.Infrastructure.Extensions;
using static TouhouLauncher.Test.CommonTestToolsAndData;
using Xunit;

namespace TouhouLauncher.Test.Models.Infrastructure {
	public class IniSerializerServiceTest {
		private readonly IniSerializerService _iniSerializerService = IniSerializerService.Instance;

		[Fact]
		public void Serializes_IniData_to_ini_formatted_strings() {
			var iniDataWithProperty = new IniData();
			iniDataWithProperty.Global.Add(new Property("Test property", "Hello"));

			var resultFromNull = _iniSerializerService.Serialize(null);
			var resultFromNew = _iniSerializerService.Serialize(new());
			var resultFromIniWithEmptySection = _iniSerializerService.Serialize(
				new() {
					Sections = new() {
						new Section("Test section")
					}
				}
			);
			var resultFromIniWithProperty = _iniSerializerService.Serialize(iniDataWithProperty);
			var resultFromIniWithNonEmptySection = _iniSerializerService.Serialize(
				new() {
					Sections = new() {
						new Section("Test section") {
							Properties = new() {
								new Property("Test property", "Hello"),
								new Property("Test property 2", "Goodbye")
							}
						}
					}
				}
			);

			Assert.Equal(string.Empty, resultFromNull);
			Assert.Equal(string.Empty, resultFromNew);
			Assert.Equal("[Test section]", resultFromIniWithEmptySection);
			Assert.Equal("Test property=Hello", resultFromIniWithProperty);
			Assert.Equal($"[Test section]{LineBreak}Test property=Hello{LineBreak}Test property 2=Goodbye", resultFromIniWithNonEmptySection);
		}

		[Fact]
		public void Deserializes_ini_formatted_strings_to_IniData() {
			var nullResult = _iniSerializerService.Deserialize(null);
			var emptyResult = _iniSerializerService.Deserialize("");
			var nonsenseResult = _iniSerializerService.Deserialize("grer43t4q3g43rab b fewfe2");
			var sectionResult = _iniSerializerService.Deserialize("[Test section]");
			var propertyResult = _iniSerializerService.Deserialize("Test property=Hello");
			var sectionWithPropertiesResult = _iniSerializerService.Deserialize(
				$"[Test section]{LineBreak}Test property=Hello{LineBreak}Test property 2=Goodbye"
			);

			Assert.Null(nullResult);
			Assert.Empty(emptyResult.Global);
			Assert.Empty(nonsenseResult.Global);
			Assert.NotNull(sectionResult.Sections["Test section"]);
			Assert.Equal("Hello", propertyResult.Global["Test property"]);
			Assert.Equal("Goodbye", sectionWithPropertiesResult.Sections["Test section"]["Test property 2"]);
		}

		[Fact]
		public void Ini_object_turns_into_ini_string() {
			var iniObject = iniTestTypeObject;

			var result = iniObject.ToIniString();

			Assert.Equal(iniTestTypeObjectAsString, result);
		}

		[Fact]
		public void Ini_string_turns_into_ini_object() {
			var iniString = iniTestTypeObjectAsString;

			var result = iniString.ToIniObject<IniTestType>();

			Assert.Equal(iniTestTypeObject.Data.Global.Count, result.Data.Global.Count);
			Assert.Equal(iniTestTypeObject.Data.Sections.Count, result.Data.Sections.Count);
		}
	}
}
