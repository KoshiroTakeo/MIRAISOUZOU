using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogGenerator : MonoBehaviour
{
    public GameObject fogPrefab;

    [SerializeField] float point;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnFront()
    {
        Vector3 Pos2 = new Vector3(0, 0, - point);
        GameObject ball2 = (GameObject)Instantiate(fogPrefab, Pos2, Quaternion.identity);
    }

    public void SpawnDepth()
    {
        Vector3 Pos = new Vector3(0, 0, point);
        GameObject ball = (GameObject)Instantiate(fogPrefab, Pos, Quaternion.identity);
    }
}
