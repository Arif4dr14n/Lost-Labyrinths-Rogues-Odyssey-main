using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalagmite : MonoBehaviour
{
    public int damageAmount = 10; // Amount of damage to apply
    public float knockbackAmount = 10f; // Amount of knockback to apply
    public float shakeDuration = 0.5f; // Lama getaran sebelum jatuh
    public float shakeIntensity = 0.1f; // Intensitas getaran
    public float respawnTime = 1f; // Waktu untuk respawn

    private Vector3 originalPosition;
    private Rigidbody2D rb;
    private bool isFalling = false;
    private bool isDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; // Supaya tidak langsung jatuh
        originalPosition = transform.position;

        StartCoroutine(ShakeAndFall());
    }

    IEnumerator ShakeAndFall()
    {
        yield return new WaitForSeconds(respawnTime);
        // Getaran selama shakeDuration detik
        float elapsed = 0f;
        while (elapsed < shakeDuration)
        {
            transform.position = originalPosition + (Vector3)Random.insideUnitCircle * shakeIntensity;
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition; // Kembali ke posisi awal
        rb.isKinematic = false; // Aktifkan physics supaya jatuh
        rb.gravityScale = 1f; // Atur gravitasi supaya jatuh lebih cepat
        isFalling = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (isDestroyed) return;

        if (other.CompareTag("Player"))
        {
            GameObject collidedObject = other.gameObject;
            Core objectCore = collidedObject.GetComponentInChildren<Core>();

            objectCore.GetCoreComponent<Combat>().Damage(damageAmount);
            objectCore.GetCoreComponent<Combat>().Knockback(Vector2.left, knockbackAmount, objectCore.GetCoreComponent<Movement>().FacingDirection);
            StartCoroutine(Respawn());
        }

        if (other.CompareTag("Platform"))
        {
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        isDestroyed = true;
        gameObject.SetActive(false);

        Invoke(nameof(Revive), respawnTime); // Jadwalkan pemulihan objek

        yield break;
    }

    void Revive()
    {
        transform.position = originalPosition;
        rb.isKinematic = true;
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        isFalling = false;

        gameObject.SetActive(true);
        isDestroyed = false;
        StartCoroutine(ShakeAndFall());
    }
}

