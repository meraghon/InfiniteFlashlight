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
                __instance.insertedBattery.charge = float.MaxValue;
            }
        }


    }
}
