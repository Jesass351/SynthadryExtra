using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
   
    //public float velocity = 5.0f;rigidbody.velocity.y
    protected FixedJoystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<FixedJoystick>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3((-joystick.Horizontal * 10.0f),
        rigidbody.velocity.y, -(joystick.Vertical * 10.0f));
    }
}
