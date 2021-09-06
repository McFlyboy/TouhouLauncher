using System.Threading.Tasks;
using TouhouLauncher.Models.Common;

namespace TouhouLauncher.Models.Application {
	public interface INp21ntConfigRepository {
		public Task<Np21ntConfigSaveError?> SaveAsync(Np21ntConfig? config);

		public Task<Np21ntConfig?> LoadAsync();
	}

	public record Np21ntConfigSaveError(string Reason) : TouhouLauncherError {
		public override string Message => "Unable to save Neko Project II settings.\n\n" +
			"Reason:\n" +
			Reason;
	}
}
