using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRAnimatorController : MonoBehaviour
{
    float speedTreshold = 0.1f; // 歩行速度の最低判断値
    [Range(0, 1)]
    public float smoothing = 1;
    private Animator animator;
    private Vector3 previewsPos;
    private VRRig vrRig;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        vrRig = GetComponent<VRRig>();
        previewsPos = vrRig.head.vrTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 過去座標と移動後の座標を取る
        Vector3 headsetSpeed = (vrRig.head.vrTarget.position - previewsPos) / Time.deltaTime;
        headsetSpeed.y = 0; // 飛ばないため
        Vector3 headsetLocalSpeed = transform.InverseTransformDirection(headsetSpeed);
        previewsPos = vrRig.head.vrTarget.position;


        // Animatorに設定された値を受け取る
        float previousDirectionX = animator.GetFloat("DirectionX");
        float previousDirectionY = animator.GetFloat("DirectionY");


        animator.SetBool("isMoving", headsetLocalSpeed.magnitude > speedTreshold); // 歩行しているならアニメーションさせる

        // 過去座標と移動した座標（-1～1の間）のsmmothing分取る
        animator.SetFloat("DirectionX", Mathf.Lerp(previousDirectionX, Mathf.Clamp(headsetLocalSpeed.x, -1, 1), smoothing)); 
        animator.SetFloat("DirectionY", Mathf.Lerp(previousDirectionY, Mathf.Clamp(headsetLocalSpeed.z, -1, 1), smoothing));
    }
}
