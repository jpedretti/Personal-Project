using UnityEngine;

public class AnimationListener : MonoBehaviour
{

    private PlayerController playerController;
    private HunterController hunterController;

    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        hunterController = GetComponentInParent<HunterController>();
    }

    public void FireAttackHalf() => playerController.InstantiateFireBall();

    public void FireAttackFinished() => playerController.FireFinished();

    public void HitFinished() => playerController.HitFinished();

    public void ThrowFinished() => hunterController.OnAnimationFinished();
}
