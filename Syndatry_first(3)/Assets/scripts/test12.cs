using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test12 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GameObject jbj = GameObject.Find("videoCharacter");
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        rotation_cam playerScript = other.GetComponent<rotation_cam>();
        if (other.tag == "Player")
        {
            playerScript.enabled = true;
        }
    }
}
