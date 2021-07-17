using IniParser.Model;
using TouhouLauncher.Models.Application;

namespace TouhouLauncher.Models.Infrastructure.Persistence.FileSystem.IniTypes {
	public record Np21ntConfigIni : Ini {
		public Np21ntConfig ToDomain() {
			return new Np21ntConfig(
				new Np21ntConfig.NekoProject21Section() {
					Hdd1File = Data["NekoProject21"]["HDD1FILE"]
				}
			);
		}
	}

	namespace Extensions {
		public static class Np21ntConfigExtensionsForNp21ntConfigIni {
			public static Np21ntConfigIni ToIni(this Np21ntConfig domain) {
				return new Np21ntConfigIni() {
					Data = new() {
						Sections = new() {
							new Section("NekoProject21") {
								Properties = new() {
									new Property("HDD1FILE", domain.NekoProject21.Hdd1File)
								}
							}
						}
					}
				};
			}
		}
	}
}
