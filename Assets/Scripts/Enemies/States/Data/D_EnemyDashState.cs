using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newDashStateData", menuName = "Data/State Data/Dash State")]
public class D_EnemyDashState : ScriptableObject
{
    public float dashSpeed = 10f;
    public float dashDuration = 0.5f;
    public float dashDistance = 3f;
    public bool dashTowardPlayer = true;
}
