using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackSlotDeleteClickedSignal
{
    private int index;
    public int Index => index;
    public BackpackSlotDeleteClickedSignal(int index)
    {
        this.index = index;
    }
}
