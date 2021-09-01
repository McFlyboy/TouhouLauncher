using System.Threading.Tasks;

namespace TouhouLauncher.Models.Application {
	public interface INp21ntConfigRepository {
		public Task<bool> SaveAsync(Np21ntConfig? config);

		public Task<Np21ntConfig?> LoadAsync();
	}
}
