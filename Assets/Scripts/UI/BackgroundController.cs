using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float startX, startY, length;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        startX = transform.position.x;
        startY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = cam.transform.position.x * parallaxEffect;
        float movement = cam.transform.position.x * (1 - parallaxEffect);

        transform.position = new Vector3(startX + distance, cam.transform.position.y, transform.position.z);

        if (movement > startX + length)
        {
            startX += length;
        }
        else if (movement < startX - length)
        {
            startX -= length;
        }
    }
}
