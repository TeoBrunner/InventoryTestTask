using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item Data")]
public class ItemData : ScriptableObject
{
    [SerializeField] string itemID;
    [SerializeField] Sprite icon;
    [Range(1, 99)]
    [SerializeField] int maxStack = 1;
    [SerializeField] ItemType type;

    public string ItemID => itemID;
    public Sprite Icon => icon;
    public int MaxStack => maxStack;
    public ItemType Type => type;

}
