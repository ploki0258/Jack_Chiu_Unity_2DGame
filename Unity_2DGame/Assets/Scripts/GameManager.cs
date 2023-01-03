using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 遊戲管理器：管理生命、時間
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("生命物件陣列")]
    [SerializeField] GameObject[] lifes;
    [Header("時間文字介面")]
    [SerializeField] Text textTime;
    [Header("結束畫面")]
    [SerializeField] GameObject final;
    
    public static int life = 3;
    public static int time;
    public static int score = 0;

    private void Awake()
    {
        SetLife();
    }

    private void Start()
    {
       textTime = GameObject.Find("時間").GetComponent<Text>(); // 將遊戲場景上名為時間的物件及其Text存放至textTime欄位內
    }

    public void Update()
    {
        Update();
    }

    /// <summary>
    /// 更新時間介面
    /// </summary>
    private void Updatetime()
    {
        textTime.text = "時間：" + Time.timeSinceLevelLoad.ToString("F2"); // 時間文字介面 = 時間： + 載入場景時間(當下載入場景經過多少時間)
    }

    /// <summary>
    /// 角色死亡
    /// </summary>
    public void PlayerDead()
    {
        life--;

        SetLife();

        if (life == 0)
            final.SetActive(true);
    }

    /// <summary>
    /// 更新生命介面
    /// </summary>
    private void SetLife()
    {
        for (int i = 0; i < lifes.Length; i++)
        {
            if (i >= life)
            {
                lifes[i].SetActive(false);
            }
        }
    }

}
