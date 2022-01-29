using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Door : MonoBehaviour
{
    private Collider2D myCollider;
    private SpriteRenderer spriteRenderer;

    void Awake() {
        this.myCollider = GetComponent<Collider2D>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Open() {
        this.spriteRenderer.color = new Color(0,0,0,0);
        this.myCollider.enabled = false;
    }

    public void Close() {
        this.spriteRenderer.color = Color.white;
        this.myCollider.enabled = true;
    }
}
