using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DayNightTrigger : MonoBehaviour
{
    public UnityEvent triggeredOnDay;
    public UnityEvent triggeredOnNight;

    // Update is called once per frame
    void Update()
    {
        if (DayNight.GetInstance().GetTransitionToDay()) {
            triggeredOnDay.Invoke();
        }
        else if (DayNight.GetInstance().GetTransitionToNight()) {
            triggeredOnNight.Invoke();
        }
    }
}
