using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPatrolStateData", menuName = "Data/State Data/Patrol State")]
public class D_PatrolState : ScriptableObject
{
    public float patrolDuration = 3f;
    public float patrolRange = 5f;
}
