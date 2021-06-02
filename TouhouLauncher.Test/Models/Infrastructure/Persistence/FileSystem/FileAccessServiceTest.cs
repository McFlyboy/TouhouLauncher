﻿using System.IO;
using TouhouLauncher.Models.Infrastructure.Persistence.FileSystem;
using Xunit;
using static TouhouLauncher.Test.CommonTestToolsAndData;

namespace TouhouLauncher.Test.Models.Infrastructure.Persistence.FileSystem {
	public class FileAccessServiceTest {
		private readonly FileAccessService _fileAccessService = new();

		[Fact]
		public async void Returns_null_when_trying_to_read_nonexisting_file_async_to_string() {
			var result = await _fileAccessService.ReadFileToStringAsync("Non-existing file.txt");

			Assert.Null(result);
		}

		[Fact]
		public async void Returns_read_content_async_from_file_as_string() {
			File.WriteAllText("Existing file.txt", "Test content");

			var result = await _fileAccessService.ReadFileToStringAsync("Existing file.txt");

			File.Delete("Existing file.txt");

			Assert.Equal("Test content", result);
		}

		[Fact]
		public async void Returns_false_when_failing_to_create_file_to_write_to_from_string_async_when_file_path_is_not_provided() {
			bool result = await _fileAccessService.WriteFileFromStringAsync(null, "Test content");

			Assert.False(result);
		}

		[Fact]
		public async void Returns_true_when_writing_string_content_async_to_file() {
			bool result = await _fileAccessService.WriteFileFromStringAsync("Test file.txt", "Test content");

			File.Delete("Test file.txt");

			Assert.True(result);
		}

		[Fact]
		public async void Returns_null_when_trying_to_read_nonexisting_file_async_to_yaml() {
			var result = await _fileAccessService.ReadFileToYamlAsync<YamlTestType>("Non-existing file.txt");

			Assert.Null(result);
		}

		[Fact]
		public async void Returns_read_content_async_from_file_as_yaml() {
			File.WriteAllText("Existing file.txt", yamlTestTypeObjectAsString);

			var result = await _fileAccessService.ReadFileToYamlAsync<YamlTestType>("Existing file.txt");

			File.Delete("Existing file.txt");

			Assert.Equal(yamlTestTypeObject, result);
		}

		[Fact]
		public async void Returns_false_when_failing_to_create_file_to_write_to_from_yaml_async_when_file_path_is_not_provided() {
			bool result = await _fileAccessService.WriteFileFromYamlAsync(null, yamlTestTypeObject);

			Assert.False(result);
		}

		[Fact]
		public async void Returns_true_when_writing_yaml_content_async_to_file() {
			bool result = await _fileAccessService.WriteFileFromYamlAsync("Test file.txt", yamlTestTypeObject);

			File.Delete("Test file.txt");

			Assert.True(result);
		}
	}
}