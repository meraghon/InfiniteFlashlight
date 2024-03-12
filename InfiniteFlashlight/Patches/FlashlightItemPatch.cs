using HarmonyLib;
using UnityEngine;

namespace InfiniteFlashlight.Patches
{
    [HarmonyPatch(typeof(FlashlightItem))]
    internal class FlashlightItemPatch
    {
        [HarmonyPatch(nameof(FlashlightItem.Update))]
        [HarmonyPostfix]
        static void InfiniteFlashlightPatch(FlashlightItem __instance)
        {
            if (__instance == null)
            {
                return;
            }
            if (__instance.IsOwner && __instance.isBeingUsed && __instance.itemProperties.requiresBattery)
            {
                if (__instance.insertedBattery.charge > 0f)
                {
                    if (!__instance.itemProperties.itemIsTrigger)
                    {
                        // Adds charge as battery is used 
                        __instance.insertedBattery.charge += Time.deltaTime / __instance.itemProperties.batteryUsage;
                    }
                }
            }
        }
    }
}
