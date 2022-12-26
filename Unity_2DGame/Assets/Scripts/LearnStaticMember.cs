using UnityEngine;

public class LearnStaticMember : MonoBehaviour
{
    private void Start()
    {
        // 存放(設定)靜態屬性
        Cursor.visible = false; // 指標.可視 = 否

        // 取得靜態屬性
        print(Mathf.PI); // 數學.圓周率
        print(Random.value); // 隨機.值(0~1之間)

        // 使用靜態方法
        print(Mathf.Abs(-50.45f)); // 數學.絕對值(數值)
        print(Random.Range(10,100)); // 隨機.範圍(最小值，最大值)
    }

    private void Update()
    {
        print(Input.GetKeyDown(KeyCode.Space)); // 輸入.按下案件(KeyCode.按鍵名稱)
    }
}
