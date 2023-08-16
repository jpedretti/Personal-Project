using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField] private float speedX = -10;
    [SerializeField] private bool useRandomSpeed = false;

    private void Start()
    {
        if (useRandomSpeed) { speedX = Random.Range(speedX / 1.5f, speedX * 1.5f); }
    }

    // Update is called once per frame
    void Update() => transform.Translate(x: speedX * Time.deltaTime, y: 0, z: 0, Space.World);
}
