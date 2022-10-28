using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition02 : MonoBehaviour
{
    [SerializeField]
    private Material _transitionIn;

    void Start()
    {
        // フェードイン
        StartCoroutine(BeginTransition());
    }

    IEnumerator BeginTransition()
    {
        yield return Animate(_transitionIn, 1.5f);
    }

    public void FadeStart()
    {
        StartCoroutine(BeginTransition());
    }

    /// <summary>
    /// time秒かけてトランジションを行う
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>


    IEnumerator Animate(Material material, float time)
    {
        GetComponent<Image>().material = material;
        float current = 0;
        while (current < time)
        {
            material.SetFloat("_Alpha", 1 - current / time);
            yield return new WaitForEndOfFrame();
            current += Time.deltaTime;
        }
        material.SetFloat("_Alpha", 0);
    }
}
