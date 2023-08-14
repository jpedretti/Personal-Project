using UnityEngine;

public class AnimationListener : MonoBehaviour
{

    public GameObject player;

    private PlayerController playerController;

    void Start() => playerController = player.GetComponent<PlayerController>();

    public void FireAttackHalf() => playerController.InstantiateFireBall();

    public void FireAttackFinished() => playerController.FireFinished();

    public void HitFinished() => playerController.HitFinished();
}
