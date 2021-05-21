using Kingmaker.Blueprints;
using Kingmaker.View.Animation;
using Kingmaker.View.Equipment;

namespace HandInAirFix
{
    [HarmonyLib.HarmonyPatch(typeof(UnitViewHandsEquipment), "get_ActiveOffHandWeaponStyle")]
    class UnitViewHandsEquipment_ActiveOffHandWeaponStyle_Patch
    {
        static bool Prepare()
        {
            return Main.noHandInTheAir;
        }

        static void Postfix(UnitViewHandsEquipment __instance, ref WeaponAnimationStyle __result)
        {
            if (__instance.ActiveMainHandWeaponStyle != WeaponAnimationStyle.Fist && __result == WeaponAnimationStyle.Fist)
            {
                __result = WeaponAnimationStyle.None;
            }
        }
    }
}
