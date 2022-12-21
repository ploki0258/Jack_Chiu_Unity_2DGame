using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float jumpPower = 5.5f;
    [SerializeField] public float jumpHeight = 5.5f;
    [SerializeField] float runSpeed = 5f;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        jump(jumpHeight, "跳躍");
        print(isGrounded);
    }

    /// <summary>
    /// 移動方法
    /// </summary>
    private void Move()
    {
        float ad = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(ad * runSpeed, rig.velocity.y);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }

    /// <summary>
    /// 跳躍方法
    /// </summary>
    /// <param name="height">跳躍高度</param>
    /// <param name="aniName">動畫名稱</param>
    public void jump(float height, string aniName)
    {
        bool isJump = Input.GetKeyDown(KeyCode.Space);

        if (isJump && isGrounded)
        {
            rig.velocity = new Vector2(rig.velocity.x, jumpHeight);
        }
    }
    private void FixedUpdate()
    {
        isGrounded = Physics.Raycast(this.transform.position, Vector2.down, 99.0f);
    }




}
