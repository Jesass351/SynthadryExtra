using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation_cam : MonoBehaviour
{
    public FixedJoystick joystick;
    public Vector3 camCoordinates;
    public float camAngle = 8f;
    protected float CameraAngleSpeed = 2f;
    protected float CameraAngle;
    public Transform target;
    private Vector3 _local;
    private float _mxd;
    public LayerMask obstacles;
    private Camera _camera;
    //public Camera cam;
    // Start is called before the first frame update

    private Vector3 tarpos
    {
        get { return target.position; }
        set { target.position = value; }
    }
    private Vector3 _position
    {
        get { return Camera.main.transform.position; }
        set { Camera.main.transform.position = value; }
    }

    private Quaternion _rotation
    {
        get { return Camera.main.transform.rotation; }
        set { Camera.main.transform.rotation = value; }
    }
    void Start()
    {
        _camera = Camera.main;
        //CameraAngle += joystick.Horizontal * CameraAngleSpeed;
        _position = transform.position +
            //Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, 15, 20);
        Quaternion.AngleAxis(CameraAngle, Vector3.up) * camCoordinates;
        _local = target.InverseTransformPoint(_position);
        _mxd = Vector3.Distance(_position, target.position);
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");


        CameraAngle += mouseX * CameraAngleSpeed;
        //Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, 
            //transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, 20, 30), 0.2f);
  
        _position = transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * camCoordinates;
        _rotation = Quaternion.LookRotation(transform.position + Vector3.up * camAngle - _position, Vector3.up);
        ObReact();

    }
    
    void ObReact()
    {
        //Camera.main.transform.position - target.position
        //var distance = Vector3.Distance(_position, target.position);
        RaycastHit hit;
        if (Physics.Raycast(tarpos, _position - tarpos,  out hit, _mxd, obstacles))
        {
            _position = hit.point;
        }
        /*else if (distance < _mxd && !Physics.Raycast(_position, -transform.forward, .05f, obstacles))
        {
            //_position = Vector3.Lerp(Camera.main.transform.position,
            //transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, 15, 30), 0.01f);
            _position -= Camera.main.transform.forward * .05f;
        }*/
    }
}
