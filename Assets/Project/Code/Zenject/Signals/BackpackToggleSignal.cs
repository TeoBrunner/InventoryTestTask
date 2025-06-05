using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackToggleSignal
{
    private bool value;
    public bool Value => value;
    public BackpackToggleSignal(bool value)
    {
        this.value = value;
    }
}
