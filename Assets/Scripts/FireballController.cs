using UnityEngine;

public class FireballController : MonoBehaviour
{

    [SerializeField] private GameObject explosionPreFab;
    private const float speedX = 15;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(x: speedX * Time.deltaTime, y: 0, z: 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Hunter))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            InstantiateExplosion();
        }
        else if (other.CompareTag(Tags.Weapon))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            InstantiateExplosion();
        }
    }

    private void InstantiateExplosion()
    {
        Instantiate(explosionPreFab, transform.position, explosionPreFab.transform.rotation);
    }
}
