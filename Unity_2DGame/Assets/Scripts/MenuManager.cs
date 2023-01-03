using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Awake()
    {
        GameManager.life = 3; // 恢復生命數量
    }

    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }

    /// <summary>
    /// 開始遊戲
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene("遊戲場景");
    }
}
