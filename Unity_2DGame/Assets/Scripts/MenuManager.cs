using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("遊戲場景");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
