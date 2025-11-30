using BepInEx.Configuration;

namespace Explorer.Config
{
    public class ConfigManager
    {
        private readonly ConfigFile _config;

        public ConfigEntry<float> BaseXpGainPerExplore { get; private set; }
        public ConfigEntry<float> RunningXpMultiplier { get; private set; }
        public ConfigEntry<float> SwimmingXpMultiplier { get; private set; }
        public ConfigEntry<float> JumpingXpGain { get; private set; }
        public ConfigEntry<float> SailingXpMultiplier { get; private set; }
        public ConfigEntry<float> SkillIncreaseStep { get; private set; }
        public ConfigEntry<bool> DebugMode { get; private set; }

        public ConfigManager(ConfigFile config)
        {
            _config = config;
            _config.SaveOnConfigSet = false;

            BaseXpGainPerExplore = _config.Bind(
                "1. Skill XP Gain", "BaseXpGainPerExplore", 0.1f,
                new ConfigDescription("Base XP gained per exploration tick",
                    new AcceptableValueRange<float>(0.01f, 5f),
                    new ConfigurationManagerAttributes { IsAdminOnly = true }));

            RunningXpMultiplier = _config.Bind(
                "1. Skill XP Gain", "RunningXpMultiplier", 1.5f,
                new ConfigDescription("XP multiplier when running",
                    new AcceptableValueRange<float>(1f, 5f),
                    new ConfigurationManagerAttributes { IsAdminOnly = true }));

            SwimmingXpMultiplier = _config.Bind(
                "1. Skill XP Gain", "SwimmingXpMultiplier", 2f,
                new ConfigDescription("XP multiplier when swimming",
                    new AcceptableValueRange<float>(1f, 5f),
                    new ConfigurationManagerAttributes { IsAdminOnly = true }));

            JumpingXpGain = _config.Bind(
                "1. Skill XP Gain", "JumpingXpGain", 0.05f,
                new ConfigDescription("XP gained per jump",
                    new AcceptableValueRange<float>(0.01f, 1f),
                    new ConfigurationManagerAttributes { IsAdminOnly = true }));

            SailingXpMultiplier = _config.Bind(
                "1. Skill XP Gain", "SailingXpMultiplier", 1.25f,
                new ConfigDescription("XP multiplier when sailing",
                    new AcceptableValueRange<float>(1f, 5f),
                    new ConfigurationManagerAttributes { IsAdminOnly = true }));

            SkillIncreaseStep = _config.Bind(
                "2. Skill Progression", "SkillIncreaseStep", 1f,
                new ConfigDescription("Skill increase per XP event",
                    new AcceptableValueRange<float>(0.1f, 10f),
                    new ConfigurationManagerAttributes { IsAdminOnly = true }));

            DebugMode = _config.Bind(
                "3. Debug", "DebugMode", false,
                new ConfigDescription("Enable verbose debug logging"));

            _config.Save();
            _config.SaveOnConfigSet = true;
        }
    }

    public class ConfigurationManagerAttributes
    {
        public bool? IsAdminOnly;
        public bool? Advanced;
        public int? Order;
    }
}
