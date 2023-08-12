using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class HunterController : MonoBehaviour
{
    private GameObject player;

    //public GameObject weaponPreFab;
    public float speed = 20;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player);
        //InvokeRepeating(nameof(SpawnWeapon), 1, 1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void SpawnWeapon()
    //{
    //    var weaponInstance = Instantiate(weaponPreFab, transform.position, weaponPreFab.transform.rotation);


    //    float AngleRad = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x);
    //    // Get Angle in Degrees
    //    float AngleDeg = (180 / Mathf.PI) * AngleRad;
    //    // Rotate Object
    //    weaponInstance.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    //}
}
