using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSwitcher : MonoBehaviour
{
    [SerializeField]
    private GameObject targetScript; //Canvas
    [SerializeField]
    private Transform newTarget; //pointer1, pointer2,..., pointerN

    void OnTriggerEnter(Collider other)
    {
        targetScript.GetComponent<TargetPointer>().Target = newTarget;
    }

}
