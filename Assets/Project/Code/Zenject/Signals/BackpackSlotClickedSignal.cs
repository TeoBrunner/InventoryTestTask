using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackSlotClickedSignal 
{
    private int index;
    public int Index => index;
    public BackpackSlotClickedSignal (int index)
    {
        this.index = index;
    }
}
