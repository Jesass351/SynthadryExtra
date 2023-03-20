using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehaviour : MonoBehaviour
{
    [SerializeField] GameObject openButton;

    private void OnTriggerEnter(Collider other)
    {
        openButton.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        openButton.SetActive(false);
    }
}
