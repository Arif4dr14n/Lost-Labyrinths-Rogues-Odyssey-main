using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
