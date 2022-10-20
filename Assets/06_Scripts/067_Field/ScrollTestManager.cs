using UnityEngine;

public class ScrollTestManager : MonoBehaviour
{
    /// <summary>
    /// スクロール時の1ブロックとなるプレハブ
    /// </summary>
    [SerializeField]
    protected GameObject scrollBlockObject;

    /// <summary>
    /// ブロックの生成開始位置
    /// </summary>
    [SerializeField]
    protected Transform blockPopPoint;

    /// <summary>
    /// ブロックの移動方向
    /// </summary>
    [SerializeField]
    protected Vector3 blockMoveForward;

    /// <summary>
    /// あらかじめブロックを生成しておく数
    /// </summary>
    [SerializeField]
    protected int before_block_create_count = 0;

    /// <summary>
    /// 最後の生成したブロックのRendererコンポーネント(処理用)
    /// </summary>
    private Renderer beforeBlockRenderer;

    void Start()
    {
        // 初期化時に指定数分ブロックを生成する
        if (0 < before_block_create_count)
        {
            // 生成対象ブロックのBounds
            Bounds blockRendererBounds = scrollBlockObject.GetComponent<Renderer>().bounds;
            blockRendererBounds.center = blockPopPoint.position;

            for (int i = 0; i < before_block_create_count; i++)
            {
                // 移動方向が指定されている軸のみをBounds.size分ずらした位置に生成する
                Vector3 createPosition = blockPopPoint.position + new Vector3(
                    GetBinarizationFloat(blockMoveForward.x) * (blockRendererBounds.size.x * i),
                    GetBinarizationFloat(blockMoveForward.y) * (blockRendererBounds.size.y * i),
                    GetBinarizationFloat(blockMoveForward.z) * (blockRendererBounds.size.z * i)
                );
                CreateBlock(createPosition);
            }
        }
    }

    private void FixedUpdate()
    {
        // 次のブロックの生成判定用のBoundsインスタンス作成
        Bounds beforeBounds = beforeBlockRenderer.bounds;
        beforeBounds.size = beforeBlockRenderer.bounds.size * 2;
        beforeBounds.center += blockMoveForward;

        // 生成位置から判定用のBounds内から出ているか判定
        if (!beforeBounds.Contains(blockPopPoint.position))
        {
            CreateBlock(blockPopPoint.position);
        }
    }

    private void CreateBlock(Vector3 createPosition)
    {
        GameObject blockObject = Instantiate(scrollBlockObject, createPosition, scrollBlockObject.transform.rotation);

        // 移動と削除を行うコンポーネントを設定
        blockObject.AddComponent<AutoDestroy>().time = 0.5f;
        blockObject.AddComponent<ObjectTransformar>().translate = blockMoveForward;

        beforeBlockRenderer = blockObject.GetComponent<Renderer>();
    }

    private float GetBinarizationFloat(float value)
    {
        if (0 < value)
        {
            return 1;
        }
        else if (value < 0)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}