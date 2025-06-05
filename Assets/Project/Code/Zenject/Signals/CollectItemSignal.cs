using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItemSignal 
{
    private ItemData itemData;
    private int amount;
    public ItemData ItemData => itemData;
    public int Amount => amount;
    public CollectItemSignal(ItemData itemData, int amount = 1)
    {
        this.itemData = itemData;
        this.amount = amount;
    }
}
