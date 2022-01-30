using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    private Image image;
    public Sprite heartFull;
    public Sprite heartEmpty;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFull()
    {
        image.sprite = heartFull;
    }

    public void SetEmpty()
    {
        image.sprite = heartEmpty;
    }
}
