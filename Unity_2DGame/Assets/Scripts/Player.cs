using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("跳躍力道"), Range(1f, 10f)]
    [SerializeField] float jumpPower = 5.5f;
    public Transform traPlayer;
    [Header("移動速度"), Range(0f, 100f)]
    [SerializeField] float runSpeed = 10f;
    [Header("是否在地面上")]
    private bool isGrounded = false;
    [Header("生命數量"), Range(0, 10)]
    [SerializeField] int life = 3;
    [Header("檢查地面位移")]
    [SerializeField] Vector2 offset;
    [Header("檢查地面半徑")]
    [SerializeField] float radius = 0.3f;
    [Header("地板")]
    [SerializeField] GameObject floor;
    [Header("分數文字介面")]
    [SerializeField] Text textScore;

    private Rigidbody2D rig;
    private Animator ani;
    private SpriteRenderer spr;
    private bool dead;
    private GameManager gm;
    // private float hp = 100;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        gm = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        // hpMax = hp;
    }

    private void Update()
    {
        Move();
        jump();
        AddScore(0);
    }

    /// <summary>
    /// 移動方法：角色移動、動畫與翻面
    /// </summary>
    private void Move()
    {
        float ad = Input.GetAxis("Horizontal"); // 取得水平值

        rig.velocity = new Vector2(ad * runSpeed, rig.velocity.y);

        ani.SetBool("跑步開關", ad != 0);

        // 如果 按下D或右鍵
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // X軸翻轉 = 否
            spr.flipX = false;
            //this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        // 如果 按下A或左鍵
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // X軸翻轉 = 是
            spr.flipX = true;
            //this.transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        // 如果 (按下D或右鍵) 及 按下Shift鍵時
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && Input.GetKey(KeyCode.LeftShift))
        {
            spr.flipX = false;
            rig.velocity = new Vector2(ad * runSpeed * 2.0f, rig.velocity.y); // 加速
        }
        // 如果(按下A或左鍵) 及 按下Shift鍵時
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && Input.GetKey(KeyCode.LeftShift))
        {
            spr.flipX = true;
            rig.velocity = new Vector2(ad * runSpeed * 2.0f, rig.velocity.y); // 加速
        }
    }

    /// <summary>
    /// 跳躍方法
    /// </summary>
    public void jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded == true)
        {
            rig.velocity = new Vector2(rig.velocity.x, jumpPower);
        }
        else if (Physics2D.OverlapCircle(new Vector2(this.transform.position.x, this.transform.position.y) + offset, radius, 1 << 8))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        ani.SetBool("跳躍開關", isGrounded == false);
    }

    /// <summary>
    /// 死亡方法：死亡動畫、關閉腳本
    /// </summary>
    public void Dead()
    {
        // 動畫.設定觸發("參數名稱")
        ani.SetTrigger("死亡觸發");
        // 關閉腳本
        this.enabled = false;
        dead = true;
        gm.GameOver(); // 當玩家死亡時呼叫gm的GameOver方法
    }

    /// <summary>
    /// 道具機制：碰到特定tag物件時觸發
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 如果碰到tag = "trap"的物件
        if (collision.tag == "trap")
        {
            // 如果 life >= 0，就執行gm裡的PlayerDead方法
            if (GameManager.life >= 0)
            {
                gm.PlayerDead();
            }

            // 如果 life 為 0，就執行Dead方法
            if (GameManager.life == 0)
            {
                Dead();
            }
        }

        // 如果碰到tag = "gem"的物件
        if (collision.tag == "gem")
        {
            score += 10;
            textScore.text = "× " + score;
        }

        // 刪除(碰到物件.遊戲物件)
        Destroy(collision.gameObject);
    }

    /// <summary>
    /// 添加分數與更新分數介面
    /// </summary>
    /// <param name="add">要添加多少分數</param>
    public void AddScore(int add)
    {
        score += add;
        textScore.text = "× " + score;
    }

    int score
    {
        get { return _score; } // 讀取
        set { _score = value; } // 寫入
    }
    int _score = 0;

    // 繪製圖示
    private void OnDrawGizmos()
    {
        // 圖示顏色
        Gizmos.color = new Color(1f, 0.6f, 1.0f, 0.5f);
        // 繪製圓形(中心點，半徑)
        Gizmos.DrawSphere(new Vector2(this.transform.position.x, this.transform.position.y) + offset, radius);
    }

    /*
    private void FixedUpdate()
    {
        isGrounded = Physics2D.Raycast(this.transform.position, Vector2.down, 99.0f);
    }
    */
}
