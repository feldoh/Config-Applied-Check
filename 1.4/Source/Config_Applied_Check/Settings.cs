using UnityEngine;
using Verse;

namespace Config_Applied_Check;

public class Settings : ModSettings
{
    /**
     * A special setting that if you've downloaded the configs off the workshop will already be true
     * If false a message box will pop up at game start warning you you should get the configs
     * People not playing along can just tick it in settings.
     */
    public bool ConfigsApplied = false;

    public string ConfigsAppliedVersionName = null;
    public string ConfigsAppliedLastVersionName = null;
    public string ConfigsAppliedDefaultVersionName = "NO VERSION";

    public string GetLaunchedVersion => ConfigsAppliedLastVersionName ?? ConfigsAppliedDefaultVersionName;

    public void DoWindowContents(Rect wrect)
    {
        Listing_Standard options = new();
        options.Begin(wrect);

        options.CheckboxLabeled("Config_Applied_Check_ConfigsApplied".Translate(), ref ConfigsApplied);
        ConfigsAppliedVersionName = options.TextEntryLabeled("Config_Applied_Check_ConfigsApplied_Version".Translate((NamedArgument)(GetLaunchedVersion)),
            ConfigsAppliedVersionName);
        options.Gap();

        options.End();
    }

    public override void ExposeData()
    {
        Scribe_Values.Look(ref ConfigsApplied, "ConfigsApplied", false);
        Scribe_Values.Look(ref ConfigsAppliedVersionName, "ConfigsAppliedVersionName", null);
    }
}
