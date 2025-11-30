using System;
using System.IO;
using UnityEngine;

namespace Explorer.Config
{
    [Serializable]
    public class JsonConfig
    {
        public float BaseExplorationRadiusMultiplier = 100f;
        public float MaxExplorationRadiusMultiplier = 250f;
        public string SkillName = "Explorer";
        public string SkillDescription = "Reveals more of the map as you explore. Level up by walking, running, swimming, jumping, and sailing.";
        public float XpGainCooldown = 1f;
        public float MinDistanceForXp = 5f;

        private static string ConfigPath => Path.Combine(BepInEx.Paths.ConfigPath, "Explorer.json");
        private static JsonConfig _instance;

        public static JsonConfig Instance => _instance ?? (_instance = Load() ?? new JsonConfig());

        public static JsonConfig Load()
        {
            try
            {
                if (File.Exists(ConfigPath))
                {
                    _instance = JsonUtility.FromJson<JsonConfig>(File.ReadAllText(ConfigPath));
                    _instance.Validate();
                }
                else
                {
                    _instance = new JsonConfig();
                    Save();
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"Failed to load JSON config: {ex.Message}");
                _instance = new JsonConfig();
            }
            return _instance;
        }

        public static void Save()
        {
            try
            {
                File.WriteAllText(ConfigPath, JsonUtility.ToJson(_instance, true));
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"Failed to save JSON config: {ex.Message}");
            }
        }

        private void Validate()
        {
            BaseExplorationRadiusMultiplier = Mathf.Clamp(BaseExplorationRadiusMultiplier, 10f, 1000f);
            MaxExplorationRadiusMultiplier = Mathf.Clamp(MaxExplorationRadiusMultiplier, 100f, 10000f);

            if (MaxExplorationRadiusMultiplier < BaseExplorationRadiusMultiplier)
                (BaseExplorationRadiusMultiplier, MaxExplorationRadiusMultiplier) = (MaxExplorationRadiusMultiplier, BaseExplorationRadiusMultiplier);

            XpGainCooldown = Mathf.Clamp(XpGainCooldown, 0.1f, 10f);
            MinDistanceForXp = Mathf.Clamp(MinDistanceForXp, 1f, 50f);

            if (string.IsNullOrWhiteSpace(SkillName))
                SkillName = "Explorer";
        }

        public float GetRadiusMultiplier(float skillLevel)
        {
            skillLevel = Mathf.Clamp(skillLevel, 0f, 100f);
            float percentage = Mathf.Lerp(BaseExplorationRadiusMultiplier, MaxExplorationRadiusMultiplier, skillLevel / 100f);
            return percentage / 100f;
        }
    }
}
