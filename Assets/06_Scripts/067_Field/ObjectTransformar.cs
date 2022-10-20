using UnityEngine;

public class ObjectTransformar : MonoBehaviour
{
    public Vector3 translate;

    void Update()
    {
        if (translate != Vector3.zero)
        {
            transform.Translate(translate, Space.World);
        }
    }
}