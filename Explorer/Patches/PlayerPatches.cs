using HarmonyLib;

namespace Explorer.Patches
{
    [HarmonyPatch(typeof(Player))]
    public static class PlayerPatches
    {
        [HarmonyPatch(nameof(Player.FixedUpdate))]
        [HarmonyPostfix]
        public static void FixedUpdate_Postfix(Player __instance)
        {
            if (__instance == null || !__instance.IsOwner()) return;
            if (Plugin.SkillManager == null) return;

            if (__instance.GetVelocity().magnitude > 0.1f)
            {
                Plugin.SkillManager.OnPlayerMoved(
                    __instance,
                    __instance.IsRunning(),
                    __instance.IsSwimming(),
                    __instance.IsAttachedToShip());
            }
        }

        [HarmonyPatch(nameof(Player.OnDeath))]
        [HarmonyPostfix]
        public static void OnDeath_Postfix(Player __instance)
        {
            if (__instance == null || !__instance.IsOwner()) return;
            Plugin.SkillManager?.ResetTracking();
        }

        [HarmonyPatch(nameof(Player.OnRespawn))]
        [HarmonyPostfix]
        public static void OnRespawn_Postfix(Player __instance)
        {
            if (__instance == null || !__instance.IsOwner()) return;
            Plugin.SkillManager?.ResetTracking();
        }
    }

    [HarmonyPatch(typeof(Character))]
    public static class CharacterPatches
    {
        [HarmonyPatch(nameof(Character.Jump))]
        [HarmonyPostfix]
        public static void Jump_Postfix(Character __instance)
        {
            if (__instance is Player player && player.IsOwner())
                Plugin.SkillManager?.OnPlayerJumped(player);
        }
    }
}
