using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newDashStateData", menuName = "Data/State Data/Dash State")]
public class D_EnemyDashState : ScriptableObject
{
    public float dashSpeed = 10f;
    public float dashDistance = 5f;
}
