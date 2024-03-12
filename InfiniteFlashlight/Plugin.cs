using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using InfiniteFlashlight.Patches;

namespace InfiniteFlashlight
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class InfiniteFlashlightBase : BaseUnityPlugin
    {
        private const string modGUID = "Hades.InfiniteFlashlight";
        private const string modName = "Infinite Flashlight";
        private const string modVersion = "1.0.1";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static InfiniteFlashlightBase Instance;

        // keep logs 
        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("The test mod has awaken :)");

            harmony.PatchAll(typeof(InfiniteFlashlightBase));
            harmony.PatchAll(typeof(FlashlightItemPatch));
        }
    }
}
