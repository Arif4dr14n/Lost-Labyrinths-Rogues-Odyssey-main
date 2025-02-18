using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Item;

public class ExplosiveProjectile : Projectile
{
    [SerializeField]
    private float explosionRadius = 2f;
    [SerializeField]
    private GameObject explosionEffect;

    protected override void FixedUpdate()
    {
        if (!hasHitGround)
        {
            Collider2D damageHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsPlayer);
            Collider2D groundHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsGround);

            if (damageHit || groundHit)
            {
                Explode();
                Destroy(gameObject);
                Debug.Log("Projectile Destroyed");
            }

            if (Mathf.Abs(xStartPos - transform.position.x) >= travelDistance && !isGravityOn)
            {
                isGravityOn = true;
                rb.gravityScale = gravity;
            }
        }
    }

    private void Explode()
    {
        if (explosionEffect != null)
        {
            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, explosionRadius, whatIsPlayer);
        foreach (Collider2D hit in hitObjects)
        {
            Combat combat = hit.GetComponentInChildren<Combat>();
            if (combat != null)
            {
                combat.Damage(damage);

                Vector2 direction = (hit.transform.position - transform.position).normalized;
                combat.Knockback(direction, knockbackAmount, 1);
            }
        }

        //Destroy(gameObject);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
