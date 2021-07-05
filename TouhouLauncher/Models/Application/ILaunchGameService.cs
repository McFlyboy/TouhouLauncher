using TouhouLauncher.Models.Application.GameInfo;

namespace TouhouLauncher.Models.Application {
	public interface ILaunchGameService {
		public bool LaunchGame(Game game);
	}
}
