using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootController : MonoBehaviour
{
    // public List<WeaponBehaviour> Weapon = new List<WeaponBehaviour>();
    public GameObject Katana, Shotgun, Grenade, Chest;
    public int goodChance, badChance, utilityChance;

    [SerializeField] private HealthManager heroHealthManager;
    private GameObject Weapon;
    private int isChestOpen, maxChance = 100, weaponCount = 2;

    // Update is called once per frame
    void Start()
    {
        isChestOpen = 0;
    }


    public void ButtonClick()
    {
        if (isChestOpen == 0) {
            float eventChance = Random.Range(0, maxChance);
            if (eventChance < goodChance)
            {
                eventChance = Random.Range(0, maxChance);
                if (eventChance < maxChance - utilityChance)
                {
                    eventChance = Random.Range(0, maxChance);
                    if (eventChance < maxChance / weaponCount)
                    {
                        Weapon = Shotgun;
                    }
                    else
                    {
                        Weapon = Katana;
                    }
                }
                else
                {
                    Weapon = Grenade;
                }

                Weapon = Instantiate(Weapon, Chest.transform.position, Quaternion.identity);
                Weapon.transform.position += transform.forward * 2 + transform.up * 2 - transform.right * 3.5f;
            }
            else if (eventChance < goodChance + badChance)
            {
                heroHealthManager.TakeDamage(10);
            }
            else
            {
                Debug.Log("Neutral event");
            }
        }
        isChestOpen = 1;
    }
}
