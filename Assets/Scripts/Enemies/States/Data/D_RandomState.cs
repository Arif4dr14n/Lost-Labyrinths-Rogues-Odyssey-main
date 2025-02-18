using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newRandomStateData", menuName = "Data/State Data/Random State")]
public class D_RandomState : ScriptableObject
{
    [Range(0f, 1f)]
    public float chanceToIdle = 0.6f;
}
