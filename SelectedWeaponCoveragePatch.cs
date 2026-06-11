using Cosmoteer;
using Cosmoteer.Ships;
using Cosmoteer.Ships.Parts.Weapons;
using Cosmoteer.Simulation;
using Halfling.Pooling;
using HarmonyLib;

namespace WeaponCoverageOnSelect;


[HarmonyPatch(typeof(SimOverlayRenderer), "DrawPartComponentUnderlays")]
public static class SelectedWeaponCoveragePatch
{
    private static void Postfix(SimOverlayRenderer __instance)
    {
        using TempList<Weapon> weapons = TempList<Weapon>.Alloc();
        __instance.Sim.PlayerInput.GetSelectedWeapons(weapons);

        foreach (Weapon weapon in weapons)
        {
            Ship? ship = weapon.Ship;
            if (ship == null || !ship.ExistsInSim(__instance.Sim))
            {
                continue;
            }

            weapon.DrawCoverageArea(ship.WorldCenter, ship.WorldRotation, Settings.GetCurrentEnemyColor());
        }
    }
}
