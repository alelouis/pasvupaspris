using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemyShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject arrowTemplate;
    public Transform playerTransform;
    public float arrowSpeed;
    private Vector3 direction = Vector3.zero;
    private float xRange;
    private float yTarget;
    public float g = 9.81f;
    private float inside;
    private float theta;
    private float v2;
    public float waitTime = 0.5f;
    private float timer = 0.0f;

    private AudioSource audioSource;

    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            xRange = playerTransform.position.x - this.transform.position.x;
            yTarget = playerTransform.position.y - this.transform.position.y;
            inside = Mathf.Pow(arrowSpeed, 4) - g * (g * Mathf.Pow(xRange, 2) + 2 * yTarget * Mathf.Pow(arrowSpeed, 2));
            if (inside > 0){
                v2 = Mathf.Pow(arrowSpeed, 2);
                theta = Mathf.Atan((v2 + Mathf.Sqrt(inside))/(g * xRange));
                if (xRange < 0){
                    theta += Mathf.PI;
                }
                GameObject arrow = Instantiate(arrowTemplate);
                arrow.transform.position = this.transform.position;
                direction.x = Mathf.Cos(theta)*arrowSpeed;
                direction.y = Mathf.Sin(theta)*arrowSpeed;
                Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
                if (rb) {
                    rb.velocity = direction;
                }

                // play sound
                if (!audioSource.isPlaying) {
                    audioSource.PlayOneShot(audioSource.clip, 1f);
                }
            }
            timer = 0.0f;
        }
    }
}
