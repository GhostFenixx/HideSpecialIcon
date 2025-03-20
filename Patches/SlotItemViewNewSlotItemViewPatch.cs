using System;
using System.Collections;
using System.Reflection;
using SPT.Reflection.Patching;
using EFT;
using EFT.InventoryLogic;
using EFT.UI.DragAndDrop;

namespace HideSpecialIconGrids.Patches;

public class SlotItemViewNewSlotItemViewPatch : ModulePatch
{
    protected override MethodBase GetTargetMethod()
    {
        return typeof(SlotItemView).GetMethod(nameof(SlotItemView.NewSlotItemView));
    }

    [PatchPostfix]
    private static void Postfix(SlotItemView __instance, Item item)
    {
        if (!HideSpecialIconGridsPlugin.Instance.Enable.Value)
            return;

        if (!(item is CompoundItem lootItem))
            return;

        if (lootItem.Grids != null && lootItem.Grids.Length <= 0)
            return;

        StaticManager.BeginCoroutine(SlotItemViewNewSlotItemViewPatch.DoCoroutine(__instance));
    }

    private static IEnumerator DoCoroutine(SlotItemView __instance)
    {
        for (Int32 i = 0; i < HideSpecialIconGridsPlugin.Instance.FramesToWait.Value; i++)
        {
            yield return null;
        }

        GeneratedGridsView generatedGridsView = __instance.transform.parent.GetComponentInChildren<GeneratedGridsView>();

        if (generatedGridsView != null)
            generatedGridsView.GameObject.SetActive(false);
    }
}