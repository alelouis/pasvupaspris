using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction horizontalInput;
    public InputAction jumpInput;

    [Range(0,20)]
    public float horizontalMovementSpeed;
    [Range(0,20)]
    public float verticalJumpSpeed;

    private Rigidbody2D rb;
    private float horizontalCommand = 0;

    private bool jumpWanted = false;

    private SpriteRenderer spriteRenderer;

    public AudioSource walkSFX;

    void OnEnable()
    {
        this.horizontalInput.Enable();
        this.jumpInput.Enable();
    }
    
    void OnDisable()
    {
        this.horizontalInput.Disable();
        this.jumpInput.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.horizontalInput.performed += this.OnHorizontalInput;
        this.jumpInput.performed += this.OnJumpInput;
        this.rb = GetComponent<Rigidbody2D>();
        this.spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        walkSFX.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.horizontalCommand != 0) {
            if (!this.walkSFX.isPlaying) {
                this.walkSFX.Play();
            }
        } else {
            this.walkSFX.Stop();
        }
    }

    void FixedUpdate() {
        Vector3 velocityBefore = this.rb.velocity;

        this.horizontalCommand = this.horizontalInput.ReadValue<float>();


        
        float wantedHorizontalVelocity = this.horizontalMovementSpeed * this.horizontalCommand;

        float wantedVerticalVelocity = velocityBefore.y;
        if (this.jumpWanted) {
            wantedVerticalVelocity = this.verticalJumpSpeed;
            this.jumpWanted = false;
        }

        Vector3 wantedVelocity = new Vector3(wantedHorizontalVelocity, wantedVerticalVelocity, velocityBefore.z);
        this.rb.velocity = wantedVelocity;
    }

    void OnHorizontalInput(InputAction.CallbackContext context)
    {
        this.horizontalCommand = context.ReadValue<float>();
    }
    
    void OnJumpInput(InputAction.CallbackContext context)
    {
        this.jumpWanted = true;
    }
}
