using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Config", menuName = "Configs/Player")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] float speed = 3;
    public float Speed => speed;
}
