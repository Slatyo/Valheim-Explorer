using Jotunn.Configs;
using Jotunn.Managers;
using UnityEngine;
using Explorer.Config;

namespace Explorer.Managers
{
    public class ExplorerSkillManager
    {
        public const string SkillIdentifier = "com.explorer.skill.exploration";
        public static Skills.SkillType ExplorerSkillType { get; private set; }

        private Vector3 _lastPosition;
        private float _lastXpTime;
        private float _distanceTraveled;
        private bool _isInitialized;

        public ExplorerSkillManager()
        {
            PrefabManager.OnVanillaPrefabsAvailable += RegisterSkill;
        }

        private void RegisterSkill()
        {
            PrefabManager.OnVanillaPrefabsAvailable -= RegisterSkill;

            var skillConfig = new SkillConfig
            {
                Identifier = SkillIdentifier,
                Name = "$skill_explorer",
                Description = "$skill_explorer_desc",
                IncreaseStep = Plugin.ConfigManager.SkillIncreaseStep.Value
            };

            ExplorerSkillType = SkillManager.Instance.AddSkill(skillConfig);

            var localization = LocalizationManager.Instance.GetLocalization();
            localization.AddTranslation("English", new System.Collections.Generic.Dictionary<string, string>
            {
                { "skill_explorer", JsonConfig.Instance.SkillName },
                { "skill_explorer_desc", JsonConfig.Instance.SkillDescription }
            });

            Plugin.Log.LogInfo($"Registered skill: {JsonConfig.Instance.SkillName}");
        }

        public void OnPlayerMoved(Player player, bool isRunning, bool isSwimming, bool isOnShip)
        {
            if (player == null || !player.IsOwner()) return;

            var config = Plugin.ConfigManager;
            var jsonConfig = JsonConfig.Instance;

            if (!_isInitialized)
            {
                _lastPosition = player.transform.position;
                _lastXpTime = Time.time;
                _isInitialized = true;
                return;
            }

            float timeSinceLastXp = Time.time - _lastXpTime;
            if (timeSinceLastXp < jsonConfig.XpGainCooldown)
            {
                _distanceTraveled += Vector3.Distance(player.transform.position, _lastPosition);
                _lastPosition = player.transform.position;
                return;
            }

            _distanceTraveled += Vector3.Distance(player.transform.position, _lastPosition);
            _lastPosition = player.transform.position;

            if (_distanceTraveled < jsonConfig.MinDistanceForXp)
                return;

            float xpGain = config.BaseXpGainPerExplore.Value;

            if (isSwimming)
                xpGain *= config.SwimmingXpMultiplier.Value;
            else if (isOnShip)
                xpGain *= config.SailingXpMultiplier.Value;
            else if (isRunning)
                xpGain *= config.RunningXpMultiplier.Value;

            float distanceMultiplier = Mathf.Clamp(_distanceTraveled / jsonConfig.MinDistanceForXp, 1f, 3f);
            xpGain *= distanceMultiplier;

            RaiseSkill(player, xpGain);
            _distanceTraveled = 0f;
            _lastXpTime = Time.time;

            if (config.DebugMode.Value)
                Plugin.Log.LogDebug($"XP: {xpGain:F2} (Level: {GetSkillLevel(player):F1})");
        }

        public void OnPlayerJumped(Player player)
        {
            if (player == null || !player.IsOwner()) return;

            RaiseSkill(player, Plugin.ConfigManager.JumpingXpGain.Value);
        }

        private void RaiseSkill(Player player, float factor)
        {
            if (ExplorerSkillType != Skills.SkillType.None)
                player.RaiseSkill(ExplorerSkillType, factor);
        }

        public float GetSkillLevel(Player player)
        {
            if (player == null || ExplorerSkillType == Skills.SkillType.None) return 0f;
            return player.GetSkillLevel(ExplorerSkillType);
        }

        public float GetExplorationRadiusMultiplier(Player player)
        {
            return JsonConfig.Instance.GetRadiusMultiplier(GetSkillLevel(player));
        }

        public void ResetTracking()
        {
            _isInitialized = false;
            _distanceTraveled = 0f;
        }
    }
}
