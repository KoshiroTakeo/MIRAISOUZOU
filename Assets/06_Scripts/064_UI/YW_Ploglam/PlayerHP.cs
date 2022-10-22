using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHP : MonoBehaviour
{
    public GameObject life1, life2, life3, life4, life5;

    GameObject player;

    public int nPlayerHP;


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
            nPlayerHP--;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            nPlayerHP++;
        }

        if (nPlayerHP >= 5)
        {
            life5.SetActive(true);
            nPlayerHP = 5;
        }
        if (nPlayerHP==4)
        {
            life5.SetActive(false);
            life4.SetActive(true);
        }
        if (nPlayerHP == 3)
        {
            life4.SetActive(false);
            life3.SetActive(true);
        }
        if (nPlayerHP == 2)
        {
            life3.SetActive(false);
            life2.SetActive(true);
        }
        if (nPlayerHP == 1)
        {
            life2.SetActive(false);
            life1.SetActive(true);
        }
        if (nPlayerHP <= 0)
        {
            life1.SetActive(false);
            nPlayerHP = 0;
        }
    }
}
