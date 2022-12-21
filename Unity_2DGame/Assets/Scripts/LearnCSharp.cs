
using UnityEngine;

public class LearnCSharp : MonoBehaviour
{
    public int hp = 100;
    public string skill = "星爆氣流斬";
    public Color skin = Color.black;
    public GameObject trap;
    private float speed = 1.5f;
    private bool mission = false;
    private Vector3 posStart = new Vector3(30, 1, 50);

    /// <summary>
    /// 移動方法
    /// </summary>
    public void Move()
    {

    }

    /// <summary>
    /// 受傷方法
    /// </summary>
    /// <param name="getDamage">接受的傷害值</param>
    private void Hit(float getDamage)
    {

    }

    /// <summary>
    /// 跳躍方法
    /// </summary>
    /// <param name="height">跳躍高度</param>
    /// <param name="aniName">動畫名稱</param>
    public void jump(float height,string aniName)
    {

    }
}
