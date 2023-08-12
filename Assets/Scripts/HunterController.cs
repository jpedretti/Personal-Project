using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class HunterController : MonoBehaviour
{
    private GameObject player;

    public GameObject weapon1PreFab;
    public GameObject weapon2PreFab;
    public float speed = 20;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player);
        InvokeRepeating(nameof(SpawnWeapon), 1, 2);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnWeapon()
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

        RotateTowardPlayer(weaponInstance);
    }

    private void RotateTowardPlayer(GameObject weaponInstance)
    {
        float AngleRad = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x);
        // Get Angle in Degrees
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        // Rotate Object
        weaponInstance.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }
}
