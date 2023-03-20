using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private HealthManager enemyHealthManager;
    [SerializeField] private HealthManager heroHealthManager;

    [SerializeField] private FightBehaviour _fightManager;
    [SerializeField] private SelectSlot _selectManager;

    
    private int shotgunDamage = 10;
    private int katanaDamage = 15;


    private void OnMouseDown()
    {
        if (_fightManager.countOfRound % 2 == 1)
        {
            enemyHealthManager.TakeDamage(WeaponInd(_selectManager.weaponChild));

            
            if (enemyHealthManager.CurrentHealth <= 0)
            {
                _fightManager.KillEvent();
            }
            _fightManager.countOfRound++;
        }
    }

    private void Update()
    {
        if (_fightManager.countOfRound % 2 == 0 && _fightManager.countOfRound > 0)
        {
            heroHealthManager.TakeDamage(Random.Range(10, 20));

            if (heroHealthManager.CurrentHealth <= 0)
            {
                _fightManager.DeathEvent();
            }
            _fightManager.countOfRound++;
        }
    }

    private int WeaponInd(WeaponInfo slot)
    {
        switch (slot.img.sprite.name)
        {
            case "shotgun":
                return shotgunDamage;
            case "e76e3f57012b83b3":
                return katanaDamage;
            default:
                return 5;
        }
    }
}
