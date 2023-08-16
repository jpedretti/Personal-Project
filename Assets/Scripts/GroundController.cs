using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{

    private float repeatWidth;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
