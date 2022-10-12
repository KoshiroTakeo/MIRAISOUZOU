using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHP : MonoBehaviour
{
    public GameObject life1, life2, life3, life4, life5;

    GameObject player;

    int nPlayerHP;


    // Start is called before the first frame update
    void Start()
    {
        nPlayerHP = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {

        }
    }
}
