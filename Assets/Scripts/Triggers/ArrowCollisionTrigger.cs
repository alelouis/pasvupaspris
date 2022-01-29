using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class ArrowCollisionTrigger : MonoBehaviour
{
    public UnityEvent triggeredAction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<Arrow>()) {
            this.triggeredAction.Invoke();
        }
    }
}
