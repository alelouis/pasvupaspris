using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Arrow : MonoBehaviour
{
    public float velocityThreshold = 0.1f;
    public Color colorWhenStuck = Color.black;
    
    private Rigidbody2D rb;

    private bool stuck = false;

    private SpriteRenderer spriteRenderer;


    void Awake()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void FixedUpdate() {
        if (!this.stuck && this.rb.velocity.magnitude > velocityThreshold) {
            Vector2 v = rb.velocity;
            float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            // this.rb.rotation = Vector2.Angle(Vector2.right, this.rb.velocity.normalized);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        this.stuck = true;
        this.rb.simulated = false;
        this.rb.velocity = Vector2.zero;
        this.spriteRenderer.color = colorWhenStuck;
    }

    public void SetVelocity(Vector3 velocity) {
        this.rb.velocity = velocity;
    }
}
