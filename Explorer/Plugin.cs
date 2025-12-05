using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Jotunn.Utils;
using Explorer.Config;
using Explorer.Managers;

namespace Explorer
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGUID = "com.slatyo.explorer";
        public const string PluginName = "Explorer";
        public const string PluginVersion = "1.0.0";

        public static Plugin Instance { get; private set; }
        public static ManualLogSource Log { get; private set; }
        public static ConfigManager ConfigManager { get; private set; }
        public static ExplorerSkillManager SkillManager { get; private set; }

        private Harmony _harmony;

        private void Awake()
        {
            Instance = this;
            Log = Logger;

            ConfigManager = new ConfigManager(Config);
            JsonConfig.Load();
            SkillManager = new ExplorerSkillManager();

            _harmony = new Harmony(PluginGUID);
            _harmony.PatchAll();

            Log.LogInfo($"{PluginName} v{PluginVersion} loaded");
        }

        private void OnDestroy()
        {
            _harmony?.UnpatchSelf();
        }

        public static bool IsServer() => ZNet.instance != null && ZNet.instance.IsServer();
        public static bool IsClient() => ZNet.instance != null && !ZNet.instance.IsServer();
    }
}
