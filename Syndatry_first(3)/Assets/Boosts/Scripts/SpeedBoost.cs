using UnityEngine;

public class SpeedBoost : BaseBoost
{
    protected override void OnPicked(CustomCharacterController playerController)
    {
        SpeedBoostManager speedBoostManager = playerController.GetComponent<SpeedBoostManager>();
        speedBoostManager.hasBoost = true;
        
        base.OnPicked(playerController);
    }
}
