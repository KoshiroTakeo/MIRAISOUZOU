using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weakness : MonoBehaviour
{
    [SerializeField] private EnemyCommon enemy;
    [SerializeField] private int count;
    [SerializeField] private int damage;


    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (count <= 0)
        {
            enemy.HitWP = false;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (count <= 0)
            return;

        if (other.gameObject.tag == "Player")
        {
            count--;
            enemy.HitWP = true;
            enemy.AddDmg(damage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            enemy.HitWP = false;
    }

}
