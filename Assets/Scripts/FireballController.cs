using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{

    private float speedX = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(x: speedX * Time.deltaTime, y: 0, z: 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Tags.Hunter))
        {
            Debug.Log($"Hunter {other.name} hit by fireball: {gameObject.name}, should run fireball destroied animation");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.CompareTag(Tags.Weapon))
        {
            Debug.Log($"Weapon {other.name} hit by fireball: {gameObject.name}, should run fireball destroied animation");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
