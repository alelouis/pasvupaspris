using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BowController : MonoBehaviour
{
    public InputAction aimAction;
    public InputAction shootAction;

    public Arrow arrowTemplate;

    public float arrowSpeed = 8;

    private Vector3 direction = Vector3.zero;

    private bool shootEnabled = false;

    void OnEnable() {
        this.aimAction.Enable();
        this.shootAction.Enable();
    }
    
    void OnDisable() {
        this.aimAction.Disable();
        this.shootAction.Disable();
    }

    // Start is called before the first frame update
    void Start() {
        this.shootAction.performed += OnShootAction; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseScreenPosition = this.aimAction.ReadValue<Vector2>();
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = transform.position.z;

        this.direction = (mouseWorldPosition - transform.position).normalized;
        float angle = Mathf.Atan2(this.direction.y, this.direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }

    public void EnableShoot() {
        this.shootEnabled = true;
    }
    public void DisableShoot() {
        this.shootEnabled = false;
    }

    void OnShootAction(InputAction.CallbackContext context)
    {
        if (this.shootEnabled) {
            Arrow arrow = Instantiate(arrowTemplate);
            arrow.transform.position = this.transform.position;
            arrow.SetVelocity(this.direction.normalized * this.arrowSpeed);
        }
    }
}
