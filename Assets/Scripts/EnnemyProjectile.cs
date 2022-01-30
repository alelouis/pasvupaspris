using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyProjectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool touched = false;

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Collision with " + collision.gameObject);
        if (!touched && collision.gameObject.GetComponent<PlayerController>()) {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.TakeHit();
        }
        this.touched = true;
        Destroy(gameObject, 1);
    }


    void Awake()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        if (!this.touched && this.rb.velocity.magnitude > 0.1f) {
            Vector2 v = rb.velocity;
            float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            // this.rb.rotation = Vector2.Angle(Vector2.right, this.rb.velocity.normalized);
        }
    }
}
