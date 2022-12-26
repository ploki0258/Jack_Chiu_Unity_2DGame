using UnityEngine;

public class CreateProp : MonoBehaviour
{
    [Header("要生成的道具")]
    [SerializeField] GameObject prop;
    [Header("X軸最小值")]
    [SerializeField] float xMin;
    [Header("X軸最大值")]
    [SerializeField] float xMax;
    [Header("生成頻率"), Range(0.1f, 3f)]
    public float interval = 1.0f;

    /// <summary>
    /// 建立道具物件
    /// </summary>
    private void CreatePropObject()
    {
        float x = Random.Range(xMin, xMax);         // 取得隨機X值
        Vector3 pos = new Vector3(x, 7f, 0f);       // 三維向量(隨機X，高度，0)

        Instantiate(prop, pos, Quaternion.identity);  // 實例化(物件，座標位置，角度.零角度)
    }

    private void Start()
    {
        float r = Random.Range(3f,6f);

        // 延遲重複呼叫(方法名稱，延遲時間，頻率)
        InvokeRepeating("CreatePropObject", r, interval);
    }
}
