using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���������� ����� �������� ������� � �������� ������ ���������
public class CustomCharacterController : MonoBehaviour
{


    [SerializeField] private List<WeaponBehaviour> inventory = new List<WeaponBehaviour>();
    public List<WeaponBehaviour> Inventory
    {
        get { return inventory; }

        set { inventory = value; }
    }


    private List<WeaponBehaviour> inventoryForDeb = new List<WeaponBehaviour>();
    public List<WeaponBehaviour> InventoryForDeb
    {
        get { return inventoryForDeb; }

        set { inventoryForDeb = value; }
    }

    public Canvas canvas;

    public Animator anim;
    public Rigidbody rig;
    public Transform mainCamera;
    public float jumpForce = 3.5f;
    public float walkingSpeed = 10f;
    public float runningSpeed = 15f;
    public float currentSpeed;
    private float animationInterpolation = 1f;
    public FixedJoystick joystick;
    public float horisontal;
    public float vertical;
    private float lerpMulti = 7f;

    public bool canGo = true; 

    void Start()
    {
        canvas = FindObjectOfType<Canvas>();
    }
    void Run()
    {
        animationInterpolation = Mathf.Lerp(animationInterpolation, 1.5f, Time.deltaTime * 3);
        anim.SetFloat("x", horisontal * animationInterpolation);
        anim.SetFloat("y", vertical * animationInterpolation);

        currentSpeed = Mathf.Lerp(currentSpeed, runningSpeed, Time.deltaTime * 3);
    }
    void Walk()
    {
        // Mathf.Lerp - ������� �� ��, ����� ������ ���� ����� animationInterpolation(� ������ ������) ������������ � ����� 1 �� ��������� Time.deltaTime * 3.
        animationInterpolation = Mathf.Lerp(animationInterpolation, 1f, Time.deltaTime * 3);
        anim.SetFloat("x", horisontal * 1.5f);
        anim.SetFloat("y", vertical * 1.5f);

        //currentSpeed = Mathf.Lerp(currentSpeed, walkingSpeed, Time.deltaTime * 3);
        currentSpeed = Mathf.Lerp(currentSpeed, runningSpeed, Time.deltaTime * 3);
    }
    private void Update()
    {
        if (canGo)
        {
            horisontal = Input.GetAxis("Horizontal") * animationInterpolation;
            vertical = Input.GetAxis("Vertical") * animationInterpolation;
            //horisontal = Mathf.Lerp(horisontal, joystick.Horizontal, Time.deltaTime * lerpMulti);
            //vertical = Mathf.Lerp(vertical, joystick.Vertical, Time.deltaTime * lerpMulti);
            // ������������� ������� ��������� ����� ������ �������������� 
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, mainCamera.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            // ������ �� ������ W � Shift?
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                // ������ �� ��� ������ A S D?
                //Debug.Log("aaaa");
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                {
                    // ���� ��, �� �� ���� ������
                    Walk();
                }
                // ���� ���, �� ����� �����!
                else
                {
                    Run();
                }
            }
            // ���� W & Shift �� ������, �� �� ������ ���� ������
            else
            {
                Walk();
            }
            //���� ����� ������, �� � ��������� ���������� ��������� �������, ������� ���������� �������� ������
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetTrigger("Jump");
            }
        }
        else
        {
            horisontal = 0;
            vertical = 0;
            currentSpeed = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // ����� �� ������ �������� ��������� � ����������� �� ����������� � ������� ������� ������
        // ��������� ����������� ������ � ������ �� ������ 
        Vector3 camF = mainCamera.forward;
        Vector3 camR = mainCamera.right;
        // ����� ����������� ������ � ������ �� �������� �� ���� ������� �� ������ ����� ��� ����, ����� ����� �� ������� ������, �������� ����� ���� ������� ��� ����� ������� ����� ��� ����
        // ������ ���� ��������� ��� ����� ����� camF.y = 0 � camR.y = 0 :)
        camF.y = 0;
        camR.y = 0;
        Vector3 movingVector;
        // ��� �� �������� ���� ������� �� ������ W & S �� ����������� ������ ������ � ���������� � �������� �� ������ A & D � �������� �� ����������� ������ ������
        movingVector = Vector3.ClampMagnitude(camF.normalized * vertical * currentSpeed + camR.normalized * horisontal * currentSpeed, currentSpeed);
        // Magnitude - ��� ������ �������. � ���� ������ �� currentSpeed ��� ��� �� �������� ���� ������ �� currentSpeed �� 86 ������. � ���� �������� ����� �������� 1.
        anim.SetFloat("magnitude", movingVector.magnitude / currentSpeed);
        //Debug.Log(movingVector.magnitude / currentSpeed);
        // ����� �� ������� ���������! ������������� �������� ������ �� x & z ������ ��� �� �� ����� ����� ��� �������� ������� � ������
        rig.velocity = new Vector3(movingVector.x, rig.velocity.y, movingVector.z);
        // � ���� ��� ���, ��� �������� �������� �� ����� � ��� �������� � ������� ���� ������
        rig.angularVelocity = Vector3.zero;
    }
    public void Jump()
    {
        // ��������� ������ �� ������� ��������.
        rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}