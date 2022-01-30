using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour
{
    public GameObject objectPrefab;

    public void TriggerDrop() {
        GameObject instance = Instantiate(objectPrefab);
        instance.transform.position = transform.position;
    }
}
