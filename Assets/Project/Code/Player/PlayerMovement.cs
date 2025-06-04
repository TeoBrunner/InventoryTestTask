using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    private UIControlProvider uIControlProvider;
    private PlayerConfig playerConfig;
    private Rigidbody2D rb;

    [Inject]
    private void Construct(UIControlProvider uIControlProvider, PlayerConfig playerConfig)
    {
        this.uIControlProvider = uIControlProvider;
        this.playerConfig = playerConfig;

        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        rb.velocity = playerConfig.Speed * uIControlProvider.UIJoystickInput;
    }
}
