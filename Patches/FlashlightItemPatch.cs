using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace InfiniteFlashlight.Patches
{
    [HarmonyPatch(typeof(FlashlightItem))]
    internal class FlashlightItemPatch
    {
        [HarmonyPatch(nameof(FlashlightItem.Update))]
        [HarmonyPostfix]
        static void InfiniteFlashlightPatch(FlashlightItem __instance)
        {
            if(__instance == null)
            {
                return;
            }
            if (__instance.IsOwner && __instance.isBeingUsed && __instance.itemProperties.requiresBattery)
            {
                if (__instance.insertedBattery.charge > 0f) {
                    if (!__instance.itemProperties.itemIsTrigger) {
                        __instance.insertedBattery.charge -= 0;  // Don't change the charge level of the battery.
                    }
                }
                else if (!__instance.insertedBattery.empty) {
                    __instance.insertedBattery.empty = true;
                    if (__instance.isBeingUsed) {
                        __instance.isBeingUsed = false;
                        // Omit code to use up battery levels.
                    }
                }
            }
        }


    }
}
