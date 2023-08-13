using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject fireballPreFab;

    private const float xBound = 24.5f;
    private const float yBound = 14.5f;
    private const byte shotAddDelay = 10;
    private byte shotsAvailable = 3;
    private Coroutine shotTImerCoroutine;

    private void Start()
    {
        shotTImerCoroutine = StartCoroutine(ShotTimer());
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayerWithMouse();
    }

    private void OnMouseDown()
    {
        if (shotsAvailable > 0)
        {
            shotsAvailable--;
            Instantiate(fireballPreFab, transform.position, fireballPreFab.transform.rotation);
        }
    }

    private IEnumerator ShotTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(shotAddDelay);
            if (shotsAvailable < 3) 
            {
                shotsAvailable++;
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

        transform.position = new(positionX, positionY, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Tags.Hunter))
        {
            Debug.Log($"{gameObject.name} hit by Hunter: {other.name}, should decrease life");
            // decrease life
        }
        else if (other.CompareTag(Tags.Person))
        {
            Debug.Log($"{gameObject.name} hit by Person: {other.name}, should increase points");
            Destroy(other.gameObject);
            // increase points
        }
        else if (other.CompareTag(Tags.Weapon))
        {
            Debug.Log($"{gameObject.name} hit by Weapon: {other.name}, should decrease life");
            Destroy(other.gameObject);
            //decrease life
        }
    }
}
