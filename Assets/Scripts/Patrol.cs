using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] points;

    public float distanceThreshold = 0.1f;
    public float speed = 4;

    private int nextPointIndex = 0;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform nextPoint = points[nextPointIndex];
        if ((this.transform.position - nextPoint.position).magnitude > distanceThreshold) {
            this.transform.position = Vector3.MoveTowards(transform.position, nextPoint.position, speed * Time.deltaTime);
            if ((nextPoint.position - transform.position).x < 0) {
                spriteRenderer.flipX = false;
            } else {
                spriteRenderer.flipX = true;
            }
        } else {
            nextPointIndex = (nextPointIndex + 1) % points.Length;
        }
    }
}
