using System.Threading.Tasks;

namespace TouhouLauncher.Models.Application {
	public interface ISettingsAndGamesRepository {
		public Task<bool> SaveAsync(SettingsAndGames settingsAndGames);

		public Task<SettingsAndGames> LoadAsync();
	}
}
