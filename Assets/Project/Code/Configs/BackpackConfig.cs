using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Backpack Config", menuName = "Configs/Backpack")]
public class BackpackConfig : ScriptableObject
{
    [Range(1,100)]
    [SerializeField] int slotsCount = 50;
    public int SlotsCount => slotsCount;
}
