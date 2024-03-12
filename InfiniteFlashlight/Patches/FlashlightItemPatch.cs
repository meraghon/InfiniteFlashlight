using HarmonyLib;
using UnityEngine;

namespace InfiniteFlashlight.Patches
{
    [HarmonyPatch(typeof(FlashlightItem))]
    internal class FlashlightItemPatch
    {
        [HarmonyPatch(nameof(FlashlightItem.Update))]
        [HarmonyPostfix]
        static void FlashlightItemUpdatePostfix(FlashlightItem instance)
        {
            if (instance.IsOwner)
            {
                if (instance.isBeingUsed && instance.itemProperties.requiresBattery)
                {
                    if ((double)instance.insertedBattery.charge > 0.0)
                    {
                        if (instance.itemProperties.itemIsTrigger)
                            instance.insertedBattery.charge += Time.deltaTime / instance.itemProperties.batteryUsage;
                    }
                }
            }
        }
    }
}
