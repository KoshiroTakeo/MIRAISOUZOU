using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMove : MonoBehaviour
{
    public float dir = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0.005f * dir, 0f, 0f);
        if(transform.position.x > 10)
        {
            dir = -1;
        }
        if (transform.position.x < -10)
        {
            dir = 1;
        }
    }
}
