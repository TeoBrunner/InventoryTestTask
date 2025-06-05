using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BackpackSlotData 
{
    private ItemData currentItemData;
    private int stackCount;

    public ItemData ItemData => currentItemData;
    public int StackCount => stackCount;
    public bool isEmpty => currentItemData == null;

    public int AddToStack(ItemData newItemData, int amount)
    {
        if (!isEmpty && newItemData != currentItemData)
        {
            Debug.LogError($"Cannot add {newItemData.name} to {currentItemData.name}");
            return amount;
        }

        currentItemData = newItemData;
        int added = Mathf.Min(amount, newItemData.MaxStack - StackCount);
        stackCount += added;
        return amount - added;
    }
    public int AddToStack(int amount)
    {
        int added = Mathf.Min(amount, currentItemData.MaxStack - StackCount);
        stackCount += added;
        return amount - added;
    }

    public void Clear()
    {
        currentItemData = null;
        stackCount = 0;
    }

}
