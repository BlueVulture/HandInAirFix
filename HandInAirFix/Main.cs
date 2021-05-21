using UnityModManagerNet;
using System;
using System.Reflection;
using Kingmaker.Blueprints;
using System.Collections.Generic;

namespace HandInAirFix
{
    internal class Main
    {
        public static bool noHandInTheAir = true;

        internal static UnityModManagerNet.UnityModManager.ModEntry.ModLogger logger;
        internal static HarmonyLib.Harmony harmony;
        internal static LibraryScriptableObject library;

        internal static void DebugError(Exception ex)
        {
            if (logger != null) logger.Log(ex.ToString() + "\n" + ex.StackTrace);
        }
        internal static bool enabled;

        static bool Load(UnityModManager.ModEntry modEntry)
        {
            try
            {
                logger = modEntry.Logger;

                harmony = new HarmonyLib.Harmony(modEntry.Info.Id);
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            catch (Exception ex)
            {
                DebugError(ex);
                throw ex;
            }
            return true;
        }

    }
}
