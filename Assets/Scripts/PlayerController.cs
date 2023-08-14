using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject fireballPreFab;

    private const float xBound = 24.5f;
    private const float yBound = 14.5f;
    private const int shotAddDelay = 5;
    private const int maxShots = 3;
    private const int maxLives = 5;
    private int shotsAvailable;
    private Coroutine shotTimerCoroutine;
    private Animator dragonAnimator;
    private Rigidbody playerRb;
    private bool canShoot = true;
    private int lives;
    private readonly Vector3 fireballOffset = new(2.2f, 3.6f, 0);
    private const float playerYOffset = -4;
    private CapsuleCollider dragonCollider;
    private readonly Vector3 deadColliderPosition = new(0, 1, 0);
    private readonly Vector3 FlyingColliderPosition = new(0, 4, 0);
    private readonly Vector3 HitColliderPosition = new(0, 0, 0);

    private bool isAlive { get { return lives > 0; } }

    private void Start()
    {
        shotsAvailable = maxShots;
        lives = maxLives;
        shotTimerCoroutine = StartCoroutine(ShotTimer());
        dragonAnimator = GetComponentInChildren<Animator>();
        playerRb = GetComponent<Rigidbody>();
        dragonCollider = GetComponent<CapsuleCollider>();
        dragonCollider.center = FlyingColliderPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            MovePlayerWithMouse();
        }
        else
        {
            playerRb.useGravity = true;
        }
    }

    private void OnMouseDown()
    {
        if (canShoot && shotsAvailable > 0)
        {
            canShoot = false;
            dragonAnimator.SetTrigger(AnimatorsParameters.fireTrigger);
        }
    }

    public void InstantiateFireBall()
    {
        shotsAvailable--;
        Instantiate(fireballPreFab, transform.position += fireballOffset, fireballPreFab.transform.rotation);
        Debug.Log($"shots available: {shotsAvailable}");
    }

    public void FireFinished() => canShoot = true;

    public void HitFinished()
    {
        if (isAlive)
        {
            canShoot = true;
            dragonCollider.center = FlyingColliderPosition;
        }
    }

    private IEnumerator ShotTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(shotAddDelay);
            if (shotsAvailable < maxShots)
            {
                shotsAvailable++;
                Debug.Log($"shots available: {shotsAvailable}");
            }
        }
    }

    private void MovePlayerWithMouse()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var positionX = mousePosition.x;
        var positionY = mousePosition.y;

        if (mousePosition.x < -xBound) { positionX = -xBound; }
        else if (mousePosition.x > xBound) { positionX = xBound; }

        if (mousePosition.y < -yBound + 1) { positionY = -yBound + 1; }
        else if (mousePosition.y > yBound) { positionY = yBound; }

        transform.position = new(positionX, positionY + playerYOffset, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Hunter))
        {
            OnHitEnemy(other);
        }
        else if (other.CompareTag(Tags.Person))
        {
            Destroy(other.gameObject);
            // increase points
        }
        else if (other.CompareTag(Tags.Weapon))
        {
            OnHitEnemy(other);
            Destroy(other.gameObject);
        }
    }

    private void OnHitEnemy(Collider other)
    {
        DecreaseLife(1);
        if (isAlive)
        {
            dragonAnimator.SetTrigger(AnimatorsParameters.hitTrigger);
            dragonCollider.center = HitColliderPosition;
        }
        else
        {
            dragonAnimator.SetBool(AnimatorsParameters.deadBool, true);
            dragonCollider.center = deadColliderPosition;
        }
    }

    private void DecreaseLife(int livesToDecrease) => lives -= livesToDecrease;
}
