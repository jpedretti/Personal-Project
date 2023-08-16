using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject hunterGround;
    [SerializeField] private GameObject hunterSky;
    [SerializeField] private GameObject personGround;
    [SerializeField] private GameObject personSky;
    [SerializeField] private List<GameObject> clouds;
    [SerializeField] private List<GameObject> groundBackgrounds;

    private const float hunterSpawnInterval = 3;
    private const float personSpawnInterval = 2;
    private readonly List<float> groundBackgroundSpawnInterval = new() { 1.3f, 1.9f };
    private readonly List<float> cloudSpawnInterval = new() { 0.8f, 1.5f };
    private const float spawnPositionX = 26;
    private readonly Vector3 hunterGroundSpawnPosition = new(spawnPositionX, -12.1f, 0);
    private readonly Vector3 personGroundSpawnPosition = new(spawnPositionX, -13.0f, 0);
    private readonly Vector3 groundBackgroundSpawnPosition = new(spawnPositionX, -14.3f, 0);
    private const float skySpawnPositionMaxY = 10.5f;
    private const float skySpawnPositionMinY = -8f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnHunter), 2, hunterSpawnInterval);
        InvokeRepeating(nameof(SpawnPerson), 2, personSpawnInterval);
        StartCoroutine(SpawnCloud());
        StartCoroutine(SpawnGroundBackground());

    }

    private IEnumerator SpawnGroundBackground()
    {
        var groundBackgroundPrefab = groundBackgrounds[Random.Range(0, groundBackgrounds.Count)];
        Instantiate(groundBackgroundPrefab, groundBackgroundSpawnPosition, groundBackgroundPrefab.transform.rotation);
        yield return new WaitForSeconds(cloudSpawnInterval[Random.Range(0, groundBackgroundSpawnInterval.Count)]);
        StartCoroutine(SpawnGroundBackground());
    }

    private IEnumerator SpawnCloud()
    {
        var cloudPrefab = clouds[Random.Range(0, clouds.Count)];
        Instantiate(cloudPrefab, GetRandomSkySpawnPosition(z: 2), cloudPrefab.transform.rotation);
        yield return new WaitForSeconds(cloudSpawnInterval[Random.Range(0, cloudSpawnInterval.Count)]);
        StartCoroutine(SpawnCloud());
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

    private Vector3 GetRandomSkySpawnPosition(float z = 0)
    {
        return new Vector3(spawnPositionX, Random.Range(skySpawnPositionMaxY, skySpawnPositionMinY), z);
    }
}
