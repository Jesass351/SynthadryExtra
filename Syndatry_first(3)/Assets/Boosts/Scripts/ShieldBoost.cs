using UnityEngine;

public class ShieldBoost : BaseBoost
{
    [SerializeField]
    private int _shieldAmount = 25;
    protected override void OnPicked(CustomCharacterController playerController)
    {
        HealthManager healthManager = playerController.gameObject.GetComponent<HealthManager>();
        if (healthManager != null)
        {
            healthManager.TakeShield(_shieldAmount);
        }

        base.OnPicked(playerController);
    }
}
