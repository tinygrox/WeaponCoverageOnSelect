using System.Reflection;
using System.Runtime.Versioning;
using HarmonyLib;
using Halfling.Logging;

[assembly: SupportedOSPlatform("windows")]
namespace WeaponCoverageOnSelect;

public class Main
{
    private static Harmony? s_harmonyInstance;

    public static void InitializePatches()
    {
        s_harmonyInstance ??= new Harmony("tinygrox.mods.WeaponCoverageOnSelect");
        s_harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
        Logger.Log("[WeaponCoverageOnSelect] Mod loaded.");
    }
}

