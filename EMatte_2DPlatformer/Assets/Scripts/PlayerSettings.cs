using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Platformer/Player Settings")]
public class PlayerControllerSettings : ScriptableObject
{
    public float walkSpeed = 6.0f;
    public float jumpSpeed = 10.0f;
    public LayerMask groundLayer;
    public Vector2 spawnPoint = new Vector2(0, -2.5f);
    public float deathY = -45;
}