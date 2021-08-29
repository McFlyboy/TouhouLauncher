#nullable disable

using TouhouLauncher.Models.Application;
using Xunit;

namespace TouhouLauncher.Test.Models.Application {
	public class Np21ntConfigDefaultsServiceTest {
		private readonly Np21ntConfigDefaultsService _np21ntConfigDefaultsService = new();

		[Fact]
		public void Returns_default_np21nt_config_values() {
			var result = _np21ntConfigDefaultsService.CreateNp21ntConfigDefaults();

			Assert.NotNull(result);
			Assert.True(result.NekoProject21.WinSnap);
		}
	}
}
