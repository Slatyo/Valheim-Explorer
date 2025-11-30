using HarmonyLib;
using UnityEngine;

namespace Explorer.Patches
{
    [HarmonyPatch(typeof(Minimap))]
    public static class MinimapPatches
    {
        private static float _originalExploreRadius;
        private static bool _hasModifiedRadius;

        [HarmonyPatch(nameof(Minimap.Explore), typeof(Vector3), typeof(float))]
        [HarmonyPrefix]
        public static void Explore_Prefix(ref float radius)
        {
            Player player = Player.m_localPlayer;
            if (player == null || Plugin.SkillManager == null) return;

            float multiplier = Plugin.SkillManager.GetExplorationRadiusMultiplier(player);
            radius *= multiplier;
        }

        [HarmonyPatch(nameof(Minimap.UpdateExplore))]
        [HarmonyPrefix]
        public static void UpdateExplore_Prefix(ref float ___m_exploreRadius)
        {
            Player player = Player.m_localPlayer;
            if (player == null || Plugin.SkillManager == null) return;

            _originalExploreRadius = ___m_exploreRadius;
            _hasModifiedRadius = true;
            ___m_exploreRadius *= Plugin.SkillManager.GetExplorationRadiusMultiplier(player);
        }

        [HarmonyPatch(nameof(Minimap.UpdateExplore))]
        [HarmonyPostfix]
        public static void UpdateExplore_Postfix(ref float ___m_exploreRadius)
        {
            if (_hasModifiedRadius)
            {
                ___m_exploreRadius = _originalExploreRadius;
                _hasModifiedRadius = false;
            }
        }
    }
}
