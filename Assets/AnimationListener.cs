using UnityEngine;

public class AnimationListener : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject hunter1;
    [SerializeField] private GameObject hunter2;

    private PlayerController playerController;
    private HunterController hunterController;

    void Start()
    {
        if (player != null)
        {
            playerController = player.GetComponent<PlayerController>();
        }
        else if (hunter1 != null)
        {
            hunterController = hunter1.GetComponent<HunterController>();
        }
        else if (hunter2 != null)
        {
            hunterController = hunter2.GetComponent<HunterController>();
        }
    }

    public void FireAttackHalf() => playerController.InstantiateFireBall();

    public void FireAttackFinished() => playerController.FireFinished();

    public void HitFinished() => playerController.HitFinished();

    public void ThrowFinished() => hunterController.OnAnimationFinished();
}
