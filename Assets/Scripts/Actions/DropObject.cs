using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour
{
    public GameObject objectPrefab;

    public void TriggerDrop() {
        Instantiate(objectPrefab);
    }
}
