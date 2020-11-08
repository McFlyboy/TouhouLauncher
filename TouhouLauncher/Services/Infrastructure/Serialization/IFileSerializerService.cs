namespace TouhouLauncher.Services.Infrastructure.Serialization {
	public interface IFileSerializerService {
		public string FileLastName { get; }

		public bool SerializeToFile<T>(T graph, string filePath);

		public T DeserializeFromFile<T>(string filePath);
	}
}
