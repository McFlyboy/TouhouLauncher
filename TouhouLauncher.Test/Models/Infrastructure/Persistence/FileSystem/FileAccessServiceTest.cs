using System.IO;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem;
using Xunit;
using static TouhouLauncher.Test.CommonTestToolsAndData;

namespace TouhouLauncher.Test.Models.Infrastructure.Persistence.FileSystem {
	public class FileAccessServiceTest {
		private readonly FileAccessService _fileAccessService = new();

		[Fact]
		public async void Returns_error_when_trying_to_read_nonexisting_file_async_to_string() {
			var result = await _fileAccessService.ReadFileToStringAsync("Non-existing file.txt");

			Assert.True(result.IsLeft);
		}

		[Fact]
		public async void Returns_read_content_async_from_file_as_string() {
			File.WriteAllText("Existing file.txt", "Test content");

			var result = await _fileAccessService.ReadFileToStringAsync("Existing file.txt");

			File.Delete("Existing file.txt");

			Assert.Equal("Test content", result);
		}

		[Fact]
		public async void Returns_error_when_failing_to_create_file_to_write_to_from_string_async_when_file_path_is_not_provided() {
			var result = await _fileAccessService.WriteFileFromStringAsync(string.Empty, "Test content");

			Assert.NotNull(result);
		}

		[Fact]
		public async void Returns_null_when_writing_string_content_async_to_file() {
			var result = await _fileAccessService.WriteFileFromStringAsync("Test file.txt", "Test content");

			File.Delete("Test file.txt");

			Assert.Null(result);
		}

		[Fact]
		public async void Returns_error_when_trying_to_read_nonexisting_file_async_to_yaml() {
			var result = await _fileAccessService.ReadFileToYamlAsync<YamlTestType>("Non-existing file.yaml");

			Assert.True(result.IsLeft);
		}

		[Fact]
		public async void Returns_read_content_async_from_file_as_yaml() {
			File.WriteAllText("Existing file.yaml", yamlTestTypeObjectAsString);

			var result = await _fileAccessService.ReadFileToYamlAsync<YamlTestType>("Existing file.yaml");

			File.Delete("Existing file.yaml");

			Assert.Equal(yamlTestTypeObject, result);
		}

		[Fact]
		public async void Returns_error_when_failing_to_create_file_to_write_to_from_yaml_async_when_file_path_is_not_provided() {
			var result = await _fileAccessService.WriteFileFromYamlAsync(string.Empty, yamlTestTypeObject);

			Assert.NotNull(result);
		}

		[Fact]
		public async void Returns_null_when_writing_yaml_content_async_to_file() {
			var result = await _fileAccessService.WriteFileFromYamlAsync("Test file.yaml", yamlTestTypeObject);

			File.Delete("Test file.yaml");

			Assert.Null(result);
		}

		[Fact]
		public async void Returns_error_when_trying_to_read_nonexisting_file_async_to_ini() {
			var result = await _fileAccessService.ReadFileToIniAsync<IniTestType>("Non-existing file.ini");

			Assert.True(result.IsLeft);
		}

		[Fact]
		public async void Returns_read_content_async_from_file_as_ini() {
			File.WriteAllText("Existing file.ini", iniTestTypeObjectAsString);

			var result = await _fileAccessService.ReadFileToIniAsync<IniTestType>("Existing file.ini");

			File.Delete("Existing file.ini");

			Assert.True(result.IsRight);
			Assert.Equal(iniTestTypeObject.Data["Test"]["text"], result.GetRight().Data["Test"]?["text"]);
			Assert.Equal(iniTestTypeObject.Data["Test"]["number"], result.GetRight().Data["Test"]?["number"]);
			Assert.Equal(iniTestTypeObject.Data["More test"]["is_test"], result.GetRight().Data["More test"]?["is_test"]);
		}

		[Fact]
		public async void Returns_error_when_failing_to_create_file_to_write_to_from_ini_async_when_file_path_is_not_provided() {
			var result = await _fileAccessService.WriteFileFromIniAsync(string.Empty, iniTestTypeObject);

			Assert.NotNull(result);
		}

		[Fact]
		public async void Returns_null_when_writing_ini_content_async_to_file() {
			var result = await _fileAccessService.WriteFileFromIniAsync("Test file.ini", iniTestTypeObject);

			File.Delete("Test file.ini");

			Assert.Null(result);
		}
	}
}
