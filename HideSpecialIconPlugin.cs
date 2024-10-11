using System;
using BepInEx;
using BepInEx.Configuration;
using HideSpecialIcon.Patches;

namespace HideSpecialIcon {
	[BepInPlugin("com.pandahhcorp.hidespecialicon", "HideSpecialIcon", "1.0.0")]
	public class HideSpecialIconPlugin : BaseUnityPlugin {
		public static HideSpecialIconPlugin Instance { get; private set; }
		public ConfigEntry<Boolean> Enable { get; private set; }
		public ConfigEntry<Int32> FramesToWait { get; private set; }

		private void Awake() {
			HideSpecialIconPlugin.Instance = this;
			this.Enable = this.Config.Bind("General", "Enable", true);
			this.FramesToWait = this.Config.Bind("General", "Frames To Wait", 1);
			new SlotItemViewNewSlotItemViewPatch().Enable();
		}
	}
}