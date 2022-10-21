using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weakness : MonoBehaviour
{
    [SerializeField] private EnemyCommon enemy;
    [SerializeField] private int count;
    [SerializeField] private int damage;
    [SerializeField] private Transform[] point;

    private void OnEnable()
    {
        SetPos();
    }

    private void Start()
    {
        
    }

    
    private void Update()
    {
        if (count <= 0)
        {
            enemy.HitWP = false;
            gameObject.SetActive(false);
        }
    }

    private void SetPos()
    {
        int num = Random.Range(0, point.Length);
        Debug.Log("ƒ‰ƒ“ƒ_ƒ€‚Í"+num);
        gameObject.transform.position = point[num].position;
    }



    // ---------------“–‚½‚è”»’è---------------------

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
