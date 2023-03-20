using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testtt : MonoBehaviour
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
        
        
        List <WeaponBehaviour> _Inventory = other.GetComponent<CustomCharacterController>().Inventory;
        //Animator animator = other.GetComponent<Animator>();
        if (other.tag == "Player")
        {
            for (int i = 0; i < _Inventory.Count; i++)
            {
                Debug.Log(_Inventory[i].damage);
                //Debug.Log(_Inventory[i].name);
                Debug.Log(_Inventory[i].weaponIcon);
            }    
            
        }
    }
}
