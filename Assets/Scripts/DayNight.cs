using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{

    private static DayNight instance = null;

    public static DayNight GetInstance()
    {
        if (instance == null)
        {
            Debug.LogError("No instance of DayNight");
            instance = Instantiate(new GameObject("DayNight").AddComponent<DayNight>());
        }
        return instance;
    }

    public AudioSource audioSource;
    public float bpm = 100; // Beats per minutes
    public int sampleRate = 44100;
    private float bps; // Beats per seconds
    private float secondsPerBeat;
    public int beatsInDay = 1;
    private float samplesPerDay;

    private bool wasDay = true;
    private bool isDay = true;

    private bool transitionToDay = false;
    private bool transitionToNight = false;

    void Start()
    {
        if (instance != null && instance != this) {
            Debug.LogError("Two DayNight components");
            Destroy(gameObject);
        }
        instance = this;

        Debug.Log(samplesPerDay);
        bps = bpm / 60.0f; // Beats per seconds
        secondsPerBeat = 1.0f / bps;
        samplesPerDay = beatsInDay * secondsPerBeat * sampleRate;
    }

    // Update is called once per frame
    void Update()
    {
        isDay = (Mathf.Floor(audioSource.timeSamples / samplesPerDay)) % 2 == 0;
        transitionToDay = (isDay && !wasDay);
        transitionToNight = (!isDay && wasDay);
        if (isDay != wasDay) {
            wasDay = isDay;
        }
    }

    public bool GetTransitionToDay()
    {
        return transitionToDay;
    }

    public bool GetTransitionToNight()
    {
        return transitionToNight;
    }
}
