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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count <= 0)
            gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (count <= 0)
            return;

        if(other.gameObject.tag == "Player")
        {
            count--;
            enemy.AddDmg(damage);
        }
    }
}
