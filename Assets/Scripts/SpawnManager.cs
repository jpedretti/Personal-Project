using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject hunterGround;
    public GameObject hunterSky;
    public GameObject personGround;
    public GameObject personSky;

    private const float hunterSpawnInterval = 3;
    private const float personSpawnInterval = 2;
    private const float spawnPositionX = 26;
    private readonly Vector3 groundSpawnPosition = new(spawnPositionX, -12.1f, 0);
    private const float skySpawnPositionMaxY = 14.5f;
    private const float skySpawnPositionMinY = -11f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnHunter), 2, hunterSpawnInterval);
        InvokeRepeating(nameof(SpawnPerson), 2, personSpawnInterval);
    }

    private void SpawnHunter()
    {
        SpawnPrefab(hunterGround, hunterSky);
    }

    private void SpawnPerson()
    {
        SpawnPrefab(personGround, personSky);
    }

    private void SpawnPrefab(GameObject prefabGround, GameObject prefabSky)
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
