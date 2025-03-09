using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DisappearingPlatform : MonoBehaviour
{
    public float interval = 5f;
    public float fadeDuration = 2f;

    private Tilemap platformTilemap;
    private Collider2D platformCollider;

    // Start is called before the first frame update
    void Start()
    {
        platformTilemap = GetComponent<Tilemap>();
        platformCollider = GetComponent<Collider2D>();

        StartCoroutine(TogglePlatform());
    }

    IEnumerator TogglePlatform()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            yield return StartCoroutine(FadeOut());
            platformCollider.enabled = false;
            yield return new WaitForSeconds(interval);
            platformCollider.enabled = true;
            yield return StartCoroutine(FadeIn());
        }
    }

    IEnumerator FadeOut()
    {
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(1, 0, t / fadeDuration);
            SetAlpha(alpha);
            yield return null;
        }
        SetAlpha(0);
    }

    IEnumerator FadeIn()
    {
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(0, 1, t / fadeDuration);
            SetAlpha(alpha);
            yield return null;
        }
        SetAlpha(1);
    }

    void SetAlpha(float alpha)
    {
        if (platformTilemap != null)
        {
            Color color = platformTilemap.color;
            color.a = alpha;
            platformTilemap.color = color;
        }
    }
}
