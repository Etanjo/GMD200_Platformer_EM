using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Platformer/Player Settings")]
public class PlayerControllerSettings : ScriptableObject
{
    public float walkSpeed = 6.0f;
    public float jumpSpeed = 10.0f;
    public LayerMask groundLayer;
    public float deathY = -45;
    public string movingTag;
    public float grappleForce = 5.0f;
}