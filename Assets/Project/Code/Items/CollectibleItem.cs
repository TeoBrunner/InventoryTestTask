using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [Space]
    [SerializeField] ItemData itemData;
    [SerializeField] int amount = 1;

    public ItemData ItemData => itemData;
    public int Amount => amount;
    private void Awake()
    {
        UpdateContent(itemData, amount);
    }
    public void UpdateContent(ItemData itemData, int amount)
    {
        this.itemData = itemData;
        this.amount = amount;

        spriteRenderer.sprite = this.itemData.Icon;
    }
}
