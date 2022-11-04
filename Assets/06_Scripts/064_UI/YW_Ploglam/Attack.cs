using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField]
    private int attackPower = 500;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 1000f, LayerMask.GetMask("Boss")))
            {
                hit.transform.GetComponent<EnemyHPManager>().TakeDamage(attackPower);
            }
        }
    }
}
