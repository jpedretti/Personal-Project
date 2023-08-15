using UnityEngine;

public class MoveWeapon : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    [SerializeField] private bool rotate = false;
    [SerializeField] private float rotationSpeed = 400;
    private Vector3 playerDirection;

    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            transform.Rotate(new(0, 0, rotationSpeed * Time.deltaTime));

        }

        transform.Translate(speed * Time.deltaTime * playerDirection, Space.World);
    }

    public void SetPlayerDirection(Vector3 playerDirection)
    {
        this.playerDirection = playerDirection;
    }
}
