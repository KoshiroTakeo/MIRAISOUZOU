using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogDistance : MonoBehaviour
{
    public GameObject playerObj;
    public GameObject fogPoint;

    void Update()
    {
        Vector3 player = playerObj.transform.position;
        Vector3 fog = fogPoint.transform.position;
        float dis = Vector3.Distance(player, fog);

        if (dis > 10.0f)
        {
            fogPoint.GetComponent<FogGenerator>().SpawnFront();
            fogPoint.GetComponent<FogGenerator>().SpawnDepth();
        }
    }
}
