using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maraveur : MonoBehaviour
{
    public float maxMaraveDistance = 2f;
    public PlayerController player;

    private bool maraveEnabled = false;

    public void EnableMarave() {
        this.maraveEnabled = true;
        Debug.Log("Enable marave");
    }
    public void DisableMarave() {
        this.maraveEnabled = false;
    }



    void Update() {
        if (DayNight.GetInstance().GetTransitionToDay()) {
            DisableMarave();
        }
        else if (DayNight.GetInstance().GetTransitionToNight()) {
            EnableMarave();
        }

        if (maraveEnabled) {
            if ((player.transform.position - transform.position).magnitude <= maxMaraveDistance) {
                player.TakeHit();
                this.DisableMarave();
            }
        }
    }
}
