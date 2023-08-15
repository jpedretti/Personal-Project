using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HunterController : MonoBehaviour
{
    private GameObject player;

    [SerializeField] private GameObject weapon1PreFab;
    [SerializeField] private GameObject weapon2PreFab;
    [SerializeField] private float throwSpeed = 3;
    [SerializeField] private float meleeSpeed = 1.5f;
    private Animator animator;
    private readonly List<bool> bools = new() { true, false };
    private Transform hunterAssetTransform;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player);
        animator = GetComponentInChildren<Animator>();
        animator.SetFloat(AnimatorsParameters.throwSpeedFloat, throwSpeed);
        animator.SetFloat(AnimatorsParameters.meleeSpeedFloat, meleeSpeed);
        animator.SetBool(AnimatorsParameters.ThrowBool, bools[Random.Range(0, bools.Count)]);
        hunterAssetTransform = gameObject.GetComponentsInChildren<Transform>()[1];
    }

    private void Update()
    {
        RotateHunterTowardPlayer();
    }

    private void SpawnWeapon()
    {
        if (!gameObject.IsDestroyed())
        {
            GameObject weaponInstance;
            if (Random.Range(0, 2) == 0)
            {
                weaponInstance = Instantiate(weapon1PreFab, transform.position, weapon1PreFab.transform.rotation);
            }
            else
            {
                weaponInstance = Instantiate(weapon2PreFab, transform.position, weapon2PreFab.transform.rotation);
            }

            var playerDirection = (player.transform.position - transform.position).normalized;
            weaponInstance.GetComponent<MoveWeapon>().SetPlayerDirection(playerDirection);
            RotateTowardPlayer(weaponInstance);
        }
    }

    public void OnAnimationFinished() => SpawnWeapon();

    private void RotateTowardPlayer(GameObject weaponInstance)
    {
        float AngleRad = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x);
        // Get Angle in Degrees
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        // Rotate Object
        weaponInstance.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }

    private void RotateHunterTowardPlayer()
    {
        if (player.transform.position.x > transform.position.x)
        {
            hunterAssetTransform.rotation = Quaternion.AngleAxis(90, Vector3.up);
        }
        else
        {
            hunterAssetTransform.rotation = Quaternion.AngleAxis(-90, Vector3.up);
        }
    }

}
