using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FightBehaviour : MonoBehaviour
{
    
    private CustomCharacterController _controllerManager;
    private HealthManager _healManager;


    [SerializeField] private GameObject player;

    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private GameObject fightCanvas;
    [SerializeField] private GameObject deathCanvas;
    [SerializeField] private GameObject enemyHealthBar;
    private Animator anim;


    public int countOfRound = 0;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && (_controllerManager.Inventory.Count > 0))
        {
            //��������� ���������� � ������� ��������
            anim.SetFloat("x", 0);
            anim.SetFloat("y", 0);
            _controllerManager.canGo = false;
            //�������� ������ ����
            countOfRound = 1;

            //������ ������ � Canvas
            mainCanvas.SetActive(false);
            fightCanvas.SetActive(true);
            enemyHealthBar.SetActive(true);

        }
    }

    private void Start()
    {
        anim = player.GetComponent<Animator>();
        _controllerManager = player.GetComponent<CustomCharacterController>();
    }

    public void DeathEvent()
    {
        Destroy(player);

        deathCanvas.SetActive(true);
        fightCanvas.SetActive(false);
        mainCanvas.SetActive(false);

       
    }

    public void KillEvent()
    {
        mainCanvas.SetActive(true);
        enemyHealthBar.SetActive(false);
        _controllerManager.canGo = true;


        Destroy(this.gameObject);
    }

    public void AdminDie()
    {
        DeathEvent();
    }

    public void AdminKill()
    {
        KillEvent();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(2);
    }
}
