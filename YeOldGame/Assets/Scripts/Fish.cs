using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    float rotationSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (gameObject.name == "FishObstacle1")
        {
            transform.Rotate(new Vector3(-1f, 0f, -1f) * rotationSpeed * Time.fixedDeltaTime);
        }
        else
        {
            transform.Rotate(new Vector3(1f, 0f, 1f) * rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
