using System;
using BepInEx;
using BepInEx.Configuration;
using HideSpecialIconGrids.Patches;

namespace HideSpecialIconGrids;

[BepInPlugin("com.pandahhcorp.hidespecialicongrids", "HideSpecialIconGrids", HideSpecialIconGridsVersion)]
public class HideSpecialIconGridsPlugin : BaseUnityPlugin
{
    public const string HideSpecialIconGridsVersion = "1.1.0.0";

    public static HideSpecialIconGridsPlugin Instance { get; private set; }
    public ConfigEntry<Boolean> Enable { get; private set; }
    public ConfigEntry<Int32> FramesToWait { get; private set; }

    private void Awake()
    {
        HideSpecialIconGridsPlugin.Instance = this;
        this.Enable = this.Config.Bind("General", "Enable", true);
        this.FramesToWait = this.Config.Bind("General", "Frames To Wait", 1);
        new SlotItemViewNewSlotItemViewPatch().Enable();
    }
}