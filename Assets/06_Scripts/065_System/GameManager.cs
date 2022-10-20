//============================================================
// ゲームの進行
//======================================================================
// 開発履歴
// 20221018:生成
//======================================================================
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject PlayerObj;

    public float WorldTime = 1.0f; // ゲーム時間
    public float AccelSpeed = 1.0f; // プレイヤーの加速
    float fMaxSpeed = 5.0f;

    public bool GameOver = false;

    private void Awake()
    {
        GameOver = false;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if(fMaxSpeed > AccelSpeed) AccelSpeed *= 1.0001f;
    }

    
    public void CheckDamage()
    {
        Debug.Log("速度低下");
        AccelSpeed *= 0.9f;
    }

    public void OnSkill()
    {
        Debug.Log("スキル発動");
        WorldTime = 0.8f;
    }

    // ステージ開始処理
    void OnGameStart()
    {

    }

    // ゲームオーバー処理
    public void OnGameOver()
    {
        Debug.Log("ゲーム終了");
        GameOver = true;
    }
}
