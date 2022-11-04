using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonManager : MonoBehaviour
{
    [System.Serializable]
    public class ButtonPressedEvent : UnityEvent { }
    public ButtonPressedEvent OnButtonPressed;

    public Vector3 Axis;
    public float MaxDistance;
    public float ReturnSpeed = 10.0f;

    Vector3 m_StartPosition;
    Rigidbody m_Rigidbody;
    Collider m_Collider;

    bool m_Pressed = false;

    void Start()
    {
        Axis = new Vector3(0, -1, 0);
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Collider = GetComponentInChildren<Collider>();
        m_StartPosition = transform.position;
    }

    void FixedUpdate()
    {
        // 押し込む方向の指定（自身の方向をワールド空間内での方向へ変換する）
        Vector3 worldAxis = transform.TransformDirection(Axis);
        // MAxDistanceを利用して最大移動地点を指定する
        Vector3 end = transform.position + worldAxis * MaxDistance;

        // スタート時点の位置からの現在までの移動量を測定（平方根）
        float m_CurrentDistance = (transform.position - m_StartPosition).magnitude;
        RaycastHit info;

        float move = 0.0f;

        // 戻る方向に物体がなければ元の位置に戻る処理。あったら逆方向（押し込まれる方向）へ移動する。
        if (m_Rigidbody.SweepTest(-worldAxis, out info, ReturnSpeed * Time.deltaTime + 0.005f))
        {//hitting something, if the contact is < mean we are pressed, move downward
            move = (ReturnSpeed * Time.deltaTime) - info.distance;
        }
        else
        {
            move -= ReturnSpeed * Time.deltaTime;
        }

        // 初期地点から最大移動距離の間に収まる値に位置が変換される
        float newDistance = Mathf.Clamp(m_CurrentDistance + move, 0, MaxDistance);

        // 新しい位置を設定する
        m_Rigidbody.position = m_StartPosition + worldAxis * newDistance;

        // ボタンが押されていない状態 & 新しく移動する予定の場所までの距離と最大移動距離が近侍であるならIF内処理
        // ボタンが押されている状態 & しく移動する予定の場所までの距離と最大移動距離が近侍でないならELSEIF内処理
        if (!m_Pressed && Mathf.Approximately(newDistance, MaxDistance))
        {//was just pressed
            m_Pressed = true;
            OnButtonPressed.Invoke();
        }
        else if (m_Pressed && !Mathf.Approximately(newDistance, MaxDistance))
        {//was just released
            m_Pressed = false;
        }
    }
}
