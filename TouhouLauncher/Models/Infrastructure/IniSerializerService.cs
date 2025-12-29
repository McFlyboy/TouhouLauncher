using IniParser;
using System;

namespace TouhouLauncher.Models.Infrastructure
{
    public class IniSerializerService
    {
        private readonly IniDataFormatter _iniDataFormatter;
        private readonly IniDataParser _iniDataParser;

        private IniSerializerService()
        {
            _iniDataFormatter = new();

            _iniDataParser = new();
            _iniDataParser.Configuration.SkipInvalidLines = true;
        }

        public string Serialize(IniData data)
        {
            try
            {
                return _iniDataFormatter.Format(
                    data,
                    new()
                    {
                        NumSpacesBetweenKeyAndAssigment = 0,
                        NumSpacesBetweenAssigmentAndValue = 0
                    }
                );
            }
            catch (ArgumentOutOfRangeException)
            {
                return string.Empty;
            }
        }

        public IniData Deserialize(string ini) => _iniDataParser.Parse(ini);

        static IniSerializerService() => Instance = new();

        public static IniSerializerService Instance { get; }
    }

    public abstract record Ini
    {
        public Ini()
        {
            Data = new();
        }

        public IniData Data { get; init; }

        public string ToIniString() => IniSerializerService.Instance.Serialize(Data);
    }

    namespace Extensions
    {
        public static class IniStringExtensions
        {
            public static TIni ToIniObject<TIni>(this string iniString) where TIni : Ini, new()
            {
                IniData data = IniSerializerService.Instance.Deserialize(iniString);

                return new() { Data = data };
            }
        }
    }
}
