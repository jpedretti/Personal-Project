using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject hunterGround;
    [SerializeField] private GameObject hunterSky;
    [SerializeField] private GameObject personGround;
    [SerializeField] private GameObject personSky;
    [SerializeField] private List<GameObject> clouds;

    private const float hunterSpawnInterval = 3;
    private const float personSpawnInterval = 2;
    private const float cloudSpawnInterval = 1;
    private const float spawnPositionX = 26;
    private readonly Vector3 hunterGroundSpawnPosition = new(spawnPositionX, -12.1f, 0);
    private readonly Vector3 personGroundSpawnPosition = new(spawnPositionX, -13.0f, 0);
    private const float skySpawnPositionMaxY = 10.5f;
    private const float skySpawnPositionMinY = -8f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnHunter), 2, hunterSpawnInterval);
        InvokeRepeating(nameof(SpawnPerson), 2, personSpawnInterval);
        InvokeRepeating(nameof(SpawnCloud), 0, cloudSpawnInterval);

    }

    private void SpawnCloud()
    {
        var cloudPrefab = clouds[Random.Range(0, clouds.Count)];
        Instantiate(cloudPrefab, GetRandomSkySpawnPosition(), cloudPrefab.transform.rotation);
    }

    private void SpawnHunter()
    {
        SpawnPrefab(hunterGround, hunterSky, hunterGroundSpawnPosition);
    }

    private void SpawnPerson()
    {
        SpawnPrefab(personGround, personSky, personGroundSpawnPosition);
    }

    private void SpawnPrefab(GameObject prefabGround, GameObject prefabSky, Vector3 groundSpawnPosition)
    {
        if (Random.Range(0, 2) == 0)
        {
            Instantiate(prefabGround, groundSpawnPosition, prefabGround.transform.rotation);
        }
        else
        {
            Instantiate(prefabSky, GetRandomSkySpawnPosition(), prefabSky.transform.rotation);
        }
    }

    private Vector3 GetRandomSkySpawnPosition()
    {
        return new Vector3(spawnPositionX, Random.Range(skySpawnPositionMaxY, skySpawnPositionMinY), 0);
    }
}
