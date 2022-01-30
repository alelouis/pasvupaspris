using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

[RequireComponent((typeof(Light2D)))]
public class LightManager : MonoBehaviour
{
    public Color dayColor;
    public Color nightColor;

    private Light2D light2D;

    void Start() {
        this.light2D = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DayNight.GetInstance().GetTransitionToDay()) {
            light2D.color = dayColor;
        }
        else if (DayNight.GetInstance().GetTransitionToNight()) {
            light2D.color = nightColor;
        }
    }
}
