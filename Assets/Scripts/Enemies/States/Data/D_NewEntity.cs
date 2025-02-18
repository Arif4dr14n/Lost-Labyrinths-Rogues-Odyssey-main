using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/New Entity")]
public class D_NewEntity : D_Entity
{
    public float movementSpeed = 2f;
    public LayerMask whatIsObstacle;
}
