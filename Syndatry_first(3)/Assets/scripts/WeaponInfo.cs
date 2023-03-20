using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Diagnostics.Contracts;

public class WeaponInfo : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private int index;
    private CustomCharacterController _playerManager;
    private Text text;
    public Image img;
    private Text who;
    private Transform playerPostion;
    [SerializeField] public GameObject shotgunPrefab;
    [SerializeField] public GameObject katanaPrefab;



    private void Start()
    {
        _playerManager = GameObject.Find("Player Character").GetComponent<CustomCharacterController>();
        text = GameObject.Find("infoAboutSlots").GetComponent<Text>();
        img = GetComponent<Image>();
        who = GameObject.Find("infoAboutWeapons").GetComponent<Text>();

    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        Text text = GameObject.Find("infoAboutSlots").GetComponent<Text>();

        Image img = GetComponent<Image>();
        Text who = GameObject.Find("infoAboutWeapons").GetComponent<Text>();
        
        if ((_playerManager.Inventory.Count == 3) && (who.text.Length > 1) && (!this.name.Equals("debaf0")) && (!this.name.Equals("debaf1")))
        {
            playerPostion = GameObject.Find("Player Character").transform;
            switch (img.sprite.name)
            {
                case "shotgun":
                    Instantiate(shotgunPrefab, playerPostion.position + Vector3.back * 5, playerPostion.rotation);
                    break;
                case "e76e3f57012b83b3":
                    Instantiate(katanaPrefab, playerPostion.position + Vector3.back * 5, playerPostion.rotation);
                    break;
            }

            //Instantiate(_playerManager.Inventory[index].testCube, playerPostion.position, playerPostion.rotation);
            string str = "weaponIcon2";
            Image img1 = GameObject.Find(str).GetComponent<Image>();
            img1.sprite = null;
            img1.color = new Color(255, 255, 255, 0f);
            _playerManager.Inventory.RemoveAt(index);

        }


        
        if (img.sprite != null)
        {
            for (int i = 0; i < _playerManager.Inventory.Count; i++)
            {
                if (_playerManager.Inventory[i].weaponIcon == img.sprite)
                {
                    text.text = "Damage = " + _playerManager.Inventory[i].damage + "\nHits = " + _playerManager.Inventory[i].how_hits;

                }
            }
            for (int i =0; i < _playerManager.InventoryForDeb.Count; i++)
            {
                if ((_playerManager.InventoryForDeb[i].weaponIcon == img.sprite) && !(who.text.Length > 0))
                {
                    text.text = "Damage = " + _playerManager.InventoryForDeb[i].damage + "\nHits = " + _playerManager.InventoryForDeb[i].how_hits;
                }
            }
        }
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
       
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Image img = GetComponent<Image>();
        if (img.sprite != null)
        {
            Text text = GameObject.Find("infoAboutSlots").GetComponent<Text>();
            text.text = null;
        }
    }


}
