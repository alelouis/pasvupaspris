using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEngine.Rendering.Universal.Light2D lightWorld;
    public AudioSource audioSource;
    public float bpm = 100; // Beats per minutes
    public int sampleRate = 44100; 
    private float bps; // Beats per seconds
    private float secondsPerBeat;
    public int beatsInDay = 1;
    private float samplesPerDay;
    private bool wasDay = true;
    private bool isDay = true;
    private bool invert = false;
    public Color nightColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
    public Color dayColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

    void Start()
    {
        audioSource.Play();
        Debug.Log(samplesPerDay);
        bps = bpm / 60.0f; // Beats per seconds
        secondsPerBeat = 1.0f / bps;
        samplesPerDay = beatsInDay * secondsPerBeat * sampleRate;
    }

    // Update is called once per frame
    void Update()
    {
        isDay = (Mathf.Floor(audioSource.timeSamples/samplesPerDay))%2 == 1;
        if (isDay != wasDay) {
            invert = true;
            wasDay = isDay;
        } else {
            invert = false;
        }

        if (invert) {
            if (isDay) {
                lightWorld.color = nightColor;
            } else {
                lightWorld.color = dayColor;
            }
        }
    }
}
