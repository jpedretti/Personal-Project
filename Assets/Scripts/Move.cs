using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField] private float speedX = -10;

    // Update is called once per frame
    void Update() => transform.Translate(x: speedX * Time.deltaTime, y: 0, z: 0, Space.World);
}
