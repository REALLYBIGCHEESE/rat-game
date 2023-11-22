using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBounds = 30.0f;
    private float botBounds = -10.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBounds)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < botBounds)
        {
            Debug.Log("Game Over!!!");
            Destroy(gameObject);
        }
    }
}
