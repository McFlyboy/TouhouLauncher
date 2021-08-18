using IniParser;
using System;

namespace TouhouLauncher.Models.Infrastructure {
	public class IniSerializerService {
		private readonly IniDataFormatter _iniDataFormatter;
		private readonly IniDataParser _iniDataParser;

		private IniSerializerService() {
			_iniDataFormatter = new();

			_iniDataParser = new();
			_iniDataParser.Configuration.SkipInvalidLines = true;
		}

		public string Serialize(IniData data) {
			try {
				return _iniDataFormatter.Format(
					data,
					new() {
						NumSpacesBetweenKeyAndAssigment = 0,
						NumSpacesBetweenAssigmentAndValue = 0
					}
				);
			}
			catch (Exception e) {
				return (e is NullReferenceException || e is ArgumentOutOfRangeException)
					? string.Empty
					: null;
			}
		}

		public IniData Deserialize(string ini) {
			try {
				return _iniDataParser.Parse(ini);
			}
			catch (Exception) {
				return null;
			}
		}

		static IniSerializerService() => Instance = new();

		public static IniSerializerService Instance { get; }
	}

	public abstract record Ini {
		public IniData Data { get; init; }

		public string ToIniString() => IniSerializerService.Instance.Serialize(Data);
	}

	namespace Extensions {
		public static partial class StringExtensions {
			public static TIni ToIniObject<TIni>(this string iniString) where TIni : Ini, new() {
				var data = IniSerializerService.Instance.Deserialize(iniString);

				return data != null
					? new() { Data = data }
					: null;
			}
		}
	}
}
