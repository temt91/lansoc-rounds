using BepInEx;
using HarmonyLib;
using LanSoc.Cards;
using UnboundLib.Cards;

namespace LanSoc
{
    // These are the mods required for our mod to work
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    // Declares our mod to Bepin
    [BepInPlugin(ModId, ModName, Version)]
    // The game our mod is associated with
    [BepInProcess("Rounds.exe")]
    public class LanSoc: BaseUnityPlugin
    {
        private const string ModId = "lansociety.rounds";
        private const string ModName = "LAN Society Rounds Mod";
        public const string Version = "0.0.1";
        public const string modInitials = "LAN";

        public static LanSoc Instance { get; private set; }

        void Awake()
        {
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
        }

        void Start()
        {
            Instance = this;
            CustomCard.BuildCard<EvasiveManeuvers>();
        }
    }
}
