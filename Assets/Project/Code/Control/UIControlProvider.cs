using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIControlProvider : MonoBehaviour
{
    [SerializeField] Joystick uIJoystick;
    [SerializeField] Button fireButton;
    [SerializeField] Button backpackButton;

    public Vector2 UIJoystickInput => new Vector2(uIJoystick.Horizontal, uIJoystick.Vertical);

    private SignalBus signalBus;

    [Inject]
    private void Construct(SignalBus signalBus)
    {
        this.signalBus = signalBus;
    }
    private void Awake()
    {
        fireButton.onClick.AddListener(() => signalBus.Fire(new BackpackToggleSignal(true)));
        backpackButton.onClick.AddListener(() => signalBus.Fire(new BackpackToggleSignal(true)));
    }
}
