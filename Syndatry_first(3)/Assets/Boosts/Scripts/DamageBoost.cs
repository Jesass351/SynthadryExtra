using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageBoost : BaseBoost
{
    public int damage;
    private CustomCharacterController _playerManager;

    protected override void Start()
    {
        _playerManager = GameObject.Find("Player Character").GetComponent<CustomCharacterController>();
        base.Start();
    }


    protected override void OnPicked(CustomCharacterController playerController)
    {
        foreach (WeaponBehaviour weapon in _playerManager.Inventory)
            weapon.damage += damage;

        base.OnPicked(playerController);
    }
}
