using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public AudioSource walkAudioSource;
    public AudioSource hitAudioSource;

    public AudioClip hitSound;

    public int life;
    private GameObject[] heartList; 

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
        walkAudioSource.loop = true;
        heartList = GameObject.FindGameObjectsWithTag("Heart"); }
    // Update is called once per frame
    void Update()
    {

        this.GetComponent<Animator>().SetBool("walking", Mathf.Abs(this.rb.velocity.x)>0.1);

        if (this.horizontalCommand != 0) {
            if (!this.walkAudioSource.isPlaying) {
                this.walkAudioSource.Play();
            }
        } else {
            this.walkAudioSource.Stop();
        }
    }

    void FixedUpdate() {
        Vector3 velocityBefore = this.rb.velocity;

        this.horizontalCommand = this.horizontalInput.ReadValue<float>();
        
        float wantedHorizontalVelocity = this.horizontalMovementSpeed * this.horizontalCommand;


        this.GetComponent<SpriteRenderer>().flipX = this.GetComponentInChildren<BowController>().direction.x < 0;

        float wantedVerticalVelocity = velocityBefore.y;
        if (this.jumpWanted && velocityBefore.y == 0) {
            wantedVerticalVelocity = this.verticalJumpSpeed;
           
        }
        this.jumpWanted = false;
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

    
    public void TakeHit() {
        life--;
        Debug.Log("Life:"+life);
        if (life <= 0) {
            SceneManager.LoadScene("GameOverScene");
        } 
        else {
            this.hitAudioSource.PlayOneShot(hitAudioSource.clip, 1f);
            heartList[life].GetComponent<HeartController>().SetEmpty();
        }
    }
}
