using UnityEngine;

public class Projectile : MonoBehaviour
{
    //private AttackDetails attackDetails;

    protected float speed;
    protected float travelDistance;
    protected float xStartPos;

    [SerializeField]
    protected float gravity;
    [SerializeField]
    protected float damageRadius;

    protected Rigidbody2D rb;

    protected bool isGravityOn;
    protected bool hasHitGround;
    public float damage = 15f;
    public float knockbackAmount = 3f;

    [SerializeField]
    protected LayerMask whatIsGround;
    [SerializeField]
    protected LayerMask whatIsPlayer;
    [SerializeField]
    protected Transform damagePosition;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0.0f;
        rb.velocity = transform.right * speed;

        isGravityOn = false;

        xStartPos = transform.position.x;
    }

    protected virtual void Update()
    {
        if (!hasHitGround)
        {
            //attackDetails.position = transform.position;

            if (isGravityOn)
            {
                float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }

    protected virtual void FixedUpdate()
    {
        if (!hasHitGround)
        {
            Collider2D damageHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsPlayer);
            Collider2D groundHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsGround);

            if (damageHit)
            {
                //damageHit.transform.SendMessage("Damage", attackDetails);
                GameObject hitObject = damageHit.gameObject;
                hitObject.GetComponentInChildren<Combat>().Damage(damage);
                // Get the direction based on arrow's rotation or facing direction
                int angle = (int)transform.rotation.y;
                if (angle == 0) angle++;
        
                hitObject.GetComponentInChildren<Combat>().Knockback(new Vector2(1, 1), knockbackAmount, angle);
                Destroy(gameObject);
            }

            if (groundHit)
            {
                hasHitGround = true;
                rb.gravityScale = 0f;
                rb.velocity = Vector2.zero;
                Destroy(gameObject);
            }


            if (Mathf.Abs(xStartPos - transform.position.x) >= travelDistance && !isGravityOn)
            {
                isGravityOn = true;
                rb.gravityScale = gravity;
            }
        }        
    }

    public void FireProjectile(float speed, float travelDistance, float damage)
    {
        this.speed = speed;
        this.travelDistance = travelDistance;
        //attackDetails.damageAmount = damage;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(damagePosition.position, damageRadius);
    }
}
