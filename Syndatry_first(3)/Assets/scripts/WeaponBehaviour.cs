using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponBehaviour : MonoBehaviour
{
    private CustomCharacterController _playerManager;

    [SerializeField] public int damage;
    [SerializeField] public Sprite weaponIcon;
    [SerializeField] public int how_hits;
    //private Button button;
   // private ButtonWeapons oclick;
    private Text text1;
   //private ButtonWeapons onclick;

    bool clickF = false;
    private GameObject pressFText;

    //private Listbuttonl<WeaponBehaviour> cl = new List<WeaponBehaviour>();
    //private GridLayoutGroup _grid;
    private bool isfind = false;
    public GameObject testCube;
    //Image img = _grid.GetComponentInChildren<Image>();

    private void OnTriggerEnter(Collider other)
    {
        //Button button = GameObject.Find("ButtonTakeWeapon").GetComponent<Button>();
       // button.interactable = true;
       // button.image.enabled = true;
        if (other.tag == "Player")
        {

            // ButtonWeapons oclick = GameObject.Find("ButtonTakeWeapon").GetComponent<ButtonWeapons>();
            pressFText.GetComponent<TextMeshProUGUI>().enabled = true;

            Text text1 = GameObject.Find("infoAboutWeapons").GetComponent<Text>();
            if (this.tag.Equals("debuf") && clickF)
            {
                //Text text1 = GameObject.Find("infoAboutWeapons").GetComponent<Text>();
                for (int i = 0;i < _playerManager.InventoryForDeb.Count;i++)
                {
                    if (_playerManager.InventoryForDeb[i].weaponIcon == this.weaponIcon)
                    {
                        string debaf = "debaf_count" + i.ToString();
                        Text text = GameObject.Find(debaf).GetComponent<Text>();
                        int b = int.Parse(text.text);
                        text.text = (b + 1).ToString();
                        clickF = false;
                        //  button.interactable = false;
                        //  button.image.enabled = false;
                        pressFText.GetComponent<TextMeshProUGUI>().enabled = false;

                        Destroy(this.gameObject);
                        isfind = true;
                        break;
                    }
                }
                if (!isfind)
                {
                    if (_playerManager.InventoryForDeb.Count < 4)
                    {
                        //string grenade = "grenade_count";
                        //Text text = GameObject.Find(grenade).GetComponent<Text>();
                        //int b = int.Parse(text.text);
                        //text.text = (b + 1).ToString();
                        _playerManager.InventoryForDeb.Add(this);
                        //_playerManager.Inventory.Add(this);
                        int a = _playerManager.InventoryForDeb.Count - 1;
                        string debaf = "debaf_count" + a.ToString();
                        Text text = GameObject.Find(debaf).GetComponent<Text>();
                        int b = int.Parse(text.text);
                        text.text = (b + 1).ToString();
                        clickF = false;
                        //   button.interactable = false;
                        //  button.image.enabled = false;
                        pressFText.GetComponent<TextMeshProUGUI>().enabled = false;

                        Destroy(this.gameObject);
                    }
                    else
                    {
                        text1.text = "Inventory full";
                    }
                }
                //Text text1 = GameObject.Find("infoAboutWeapons").GetComponent<Text>();
                text1.text = null;
            }
            else if (_playerManager.Inventory.Count < 3 && clickF)
            {

                //Instantiate(testCube, this.gameObject.transform.position, this.gameObject.transform.rotation);
                _playerManager.Inventory.Add(this);
                clickF = false;
                // button.interactable = false;
                // button.image.enabled = false;
                pressFText.GetComponent<TextMeshProUGUI>().enabled = false;

                Destroy(this.gameObject);
                //Text text = GameObject.Find("infoAboutWeapons").GetComponent<Text>();
                text1.text = null;
            }
            else
            {
                if (_playerManager.Inventory.Count == 3 && clickF)
                {
                    //Text text = GameObject.Find("infoAboutWeapons").GetComponent<Text>();
                    text1.text = "Inventory full";
                }
                else
                {
                    //Text text = GameObject.Find("infoAboutWeapons").GetComponent<Text>();
                    text1.text = "Damage = " + damage.ToString() + "\n" + "Hits = " + how_hits.ToString();
                }
            }
          
            
            //Debug.Log("qqqqqq");
            
            //Debug.Log(_playerManager.Inventory[0]);
            //Debug.Log(_playerManager.Inventory.Count);
            Debug.Log(_playerManager.InventoryForDeb.Count);
            //img = _playerManager.Inventory[0].weaponIcon;
            for (int i=0;i<_playerManager.Inventory.Count;i++)
            {
                string str = "weaponIcon" + i.ToString();
                Image img = GameObject.Find(str).GetComponent<Image>();
                img.sprite = _playerManager.Inventory[i].weaponIcon;
                img.color = new Color(255, 255, 255, 1f);
                Debug.Log(_playerManager.Inventory[i].weaponIcon);
                Debug.Log(_playerManager.Inventory[i].damage);
                Debug.Log(_playerManager.Inventory[i]);
                Debug.Log(_playerManager.Inventory[0].damage);
            }
            for (int i = 0; i<_playerManager.InventoryForDeb.Count;i++)
            {
                Debug.Log(_playerManager.InventoryForDeb[i].weaponIcon);
                string str = "debaf" + i.ToString();
                Image img = GameObject.Find(str).GetComponent<Image>();
                img.sprite = _playerManager.InventoryForDeb[i].weaponIcon;
                img.color = new Color(255, 255, 255, 1f);
            }
        }

        

    }
    private void OnTriggerStay(Collider other)
    {
        //ButtonWeapons onclick = GameObject.Find("ButtonTakeWeapon").GetComponent<ButtonWeapons>();
        if (clickF)
        {
            OnTriggerEnter(other);
        }
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.F))
            {
                clickF = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Text text = GameObject.Find("infoAboutWeapons").GetComponent<Text>();
        text.text = null;
        //  ButtonWeapons oclick = GameObject.Find("ButtonTakeWeapon").GetComponent<ButtonWeapons>();
        //  oclick.a = false;
        //  Button but = oclick.GetComponent<Button>();
        //  but.interactable = false;
        //  but.image.enabled = false;
        pressFText.GetComponent<TextMeshProUGUI>().enabled = false;
    }


    private void Start()
    {
        _playerManager = GameObject.Find("Player Character").GetComponent<CustomCharacterController>();
      //  button = GameObject.Find("ButtonTakeWeapon").GetComponent<Button>();
      //  oclick = GameObject.Find("ButtonTakeWeapon").GetComponent<ButtonWeapons>();
        text1 = GameObject.Find("infoAboutWeapons").GetComponent<Text>();
        //  onclick = GameObject.Find("ButtonTakeWeapon").GetComponent<ButtonWeapons>();
        //_grid = _playerManager.canvas.GetComponentInChildren<GridLayoutGroup>();
        // testCube = GameObject.Find("Cube");
        pressFText = GameObject.FindGameObjectWithTag("PressFText");
        pressFText.GetComponent<TextMeshProUGUI>().enabled = false;
        
    }
}
