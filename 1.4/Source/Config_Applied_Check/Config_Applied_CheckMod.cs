using Verse;
using UnityEngine;
using HarmonyLib;

namespace Config_Applied_Check;

public class Config_Applied_CheckMod : Verse.Mod
{
    public static Settings settings;

    public Config_Applied_CheckMod(ModContentPack content) : base(content)
    {
        Log.Message("Hello world from Config Applied Check");

        // initialize settings
        settings = GetSettings<Settings>();

#if DEBUG
        Harmony.DEBUG = true;
#endif

        Harmony harmony = new("Taggerung.rimworld.Config_Applied_Check.main");
        harmony.PatchAll();
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        base.DoSettingsWindowContents(inRect);
        settings.DoWindowContents(inRect);
    }

    public override string SettingsCategory()
    {
        return "Config Applied Check";
    }
}
