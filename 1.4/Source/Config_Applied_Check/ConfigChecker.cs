using HarmonyLib;
using RimWorld;
using Verse;

namespace Config_Applied_Check;

[HarmonyPatch(typeof(GameComponentUtility), nameof(GameComponentUtility.FinalizeInit))]
public static class ConfigChecker
{
    [HarmonyPostfix]
    public static void Postfix()
    {
        if (!Config_Applied_CheckMod.settings.ConfigsApplied)
            Find.LetterStack.ReceiveLetter("Config_Applied_Check_ConfigsApplied_Warning_Label".Translate(),
                "Config_Applied_Check_ConfigsApplied_Warning_Message".Translate(), LetterDefOf.NegativeEvent);

        Log.Message($"Config Applied Check - Launched with config version: {Config_Applied_CheckMod.settings.GetLaunchedVersion}");
    }
}
