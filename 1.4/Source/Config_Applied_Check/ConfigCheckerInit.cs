using UnityEngine;
using Verse;

namespace Config_Applied_Check;

[StaticConstructorOnStartup]
public class ConfigCheckerInit
{
    static ConfigCheckerInit()
    {
        Config_Applied_CheckMod.settings.ConfigsAppliedLastVersionName = Config_Applied_CheckMod.settings.ConfigsAppliedVersionName;
        Log.Message($"Config Applied Check - Loaded to menu with config version: {Config_Applied_CheckMod.settings.GetLaunchedVersion}");
    }
}
