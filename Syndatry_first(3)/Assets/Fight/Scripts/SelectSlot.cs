using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectSlot : MonoBehaviour
{
    public WeaponInfo weaponChild;

    public bool firstSlot = false;
    public bool secondSlot = false;
    public bool thirdSlot = false;

    public Image firstImage;
    public Image secondImage;
    public Image thirdImage;

    public void FirstSlot()
    {
        firstSlot = true;
        secondSlot = false;
        thirdSlot = false;

        weaponChild = GameObject.Find("weaponIcon0").GetComponent<WeaponInfo>();

        firstImage.color = new Color(1f, 1f, 1f);
        secondImage.color = new Color(0f, 0f, 0f);
        thirdImage.color = new Color(0f, 0f, 0f);
    }
    public void SecondSlot()
    {
        firstSlot = false;
        secondSlot = true;
        thirdSlot = false;

        weaponChild = GameObject.Find("weaponIcon1").GetComponent<WeaponInfo>();

        firstImage.color = new Color(0f, 0f, 0f);
        secondImage.color = new Color(1f, 1f, 1f);
        thirdImage.color = new Color(0f, 0f, 0f);
    }
    public void ThirdSlot()
    {
        firstSlot = false;
        secondSlot = false;
        thirdSlot = true;

        weaponChild = GameObject.Find("weaponIcon2").GetComponent<WeaponInfo>();

        firstImage.color = new Color(0f, 0f, 0f);
        secondImage.color = new Color(0f, 0f, 0f);
        thirdImage.color = new Color(1f, 1f, 1f);
    }
}
