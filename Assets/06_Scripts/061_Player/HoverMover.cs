//============================================================
// あの移動処理
//======================================================================
// 開発履歴
// 20220729:可用性向上のため再構築
// 20220811:加減速追加、fRadiusと減速率が変更できるようにしたい
//======================================================================
using UnityEngine;

namespace VR.Players
{
    public class HoverMover 
    {
        // 必要なもの
        public float fRadius = 0.1f; // 加速開始距離
        public float fbrakepower = 2f;  // ブレーキ強度
        public float fstopmagnitude = 1f;

        float fnowspeed;

        // 未実装（安全装置兼加速域可視化クラス）
        //DrawCircle AccelCircle;

        public void HeadInclinationMove(GameObject _parent, CharacterController _character ,Vector3 _anchor, Vector3 _initirizepos, float _speed)
        {
            // 初期位置と移動位置の差をとる（インスタンス処理を毎回かけているので重くなっているかも）
            Vector3 setDirection = new Vector3(_anchor.x - _initirizepos.x, 0, 0); 
            float fsetSpeed = _speed - fRadius;

            // 停止範囲外に出たとき走り出す
            if (Calcurate(setDirection.x, setDirection.z) > fRadius)
            {               
                // 加速段階
                if(fsetSpeed >= fnowspeed)
                {
                    _character.Move(setDirection * Time.fixedDeltaTime * (fnowspeed += fsetSpeed / 20));
                }
                else
                {
                    _character.Move(setDirection * Time.fixedDeltaTime * fsetSpeed);
                }
            }
            else
            {
                fnowspeed = 0;
                if (_character.velocity.magnitude > fstopmagnitude)
                {
                    _character.Move(setDirection * Time.fixedDeltaTime * (fsetSpeed / (_speed / 20)));
                }
                
            }

            //// 円描画 getcomponent
            //if(AccelCircle == null)
            //{
            //    AccelCircle = _parent.AddComponent<DrawCircle>();
            //    Debug.Log(AccelCircle);
            //}

            
            //AccelCircle.Draw(_parent, fRadius * 10, _initirizepos, fnowspeed);
            
        }

        // 汎用性高いはずだから分けたい（そのうち）
        public float Calcurate(float _x, float _y)
        {
            float radius;

            radius = (_x * _x) + (_y * _y);

            return Mathf.Sqrt(radius);
        }
    }
}
