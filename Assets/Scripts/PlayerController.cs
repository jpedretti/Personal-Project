using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera mainCamera;

    private const float xBound = 24.5f;
    private const float yBound = 14.5f;

    // Update is called once per frame
    void Update()
    {
        MovePlayerWithMouse();
    }

    private void MovePlayerWithMouse()
    {
        var mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var positionX = mousePosition.x;
        var positionY = mousePosition.y;

        if (mousePosition.x < -xBound) { positionX = -xBound; }
        else if (mousePosition.x > xBound) { positionX = xBound; }

        if (mousePosition.y < -yBound + 1) { positionY = -yBound + 1; }
        else if (mousePosition.y > yBound) { positionY = yBound; }

        transform.position = new(positionX, positionY, 0);
    }
}
