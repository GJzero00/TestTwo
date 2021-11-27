using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playercontroller : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public Collider2D coll;
    
    public float speed, jumpForce;
    private float horizontalMove;
    public Transform groundCheck;
    public LayerMask ground;
    // public int Coin, Key;


    public Text CoinNum;

    [Header("CD的UI組件")]
    public Image cdImage;

    [Header("Dash參數")]
    public float dashTime; //dash時長
    private float dashTimeLeft; //衝鋒剩餘時間
    private float lastDash = -10f;//上一次dash時間點
    public float dashCoolDown;
    public float dashSpeed;

    public bool isGround, isJump,isDashing;
    
    bool jumpPressed;
    int jumpCount;
     




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if(Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpPressed = true;
        }

        //attack();

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(Time.time >= (lastDash + dashCoolDown))
            {
                //可以執行dash
                ReadyToDash();
            }
        }

        cdImage.fillAmount -= 1.0f / dashCoolDown * Time.deltaTime;

    }
    public void FixedUpdate()
    {

        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
        Dash();
        if (isDashing)
            return;

        GroundMovement();

        Jump();

        SwitchAnim();
        
        

    }
    void GroundMovement()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);

        if (horizontalMove != 0)
        {
            transform.localScale = new Vector3(horizontalMove, 1, 1);
        }
    }
    void Jump()
    {
        if (isGround)
        {
            jumpCount = 1;
            isJump = false;
        }
        if (jumpPressed && isGround)
        {
            isJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
        }
        else if (jumpPressed && jumpCount > 0 && isJump) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
        }
    }

    void SwitchAnim()
    {
        anim.SetFloat("running", Mathf.Abs(rb.velocity.x));

        if (isGround)
        {
            anim.SetBool("falling", false);
        }
        else if (!isGround && rb.velocity.y > 0)
        {
            anim.SetBool("jumping", true);
        }
        else if (rb.velocity.y < 0)
        {
            anim.SetBool("jumping", false);
            anim.SetBool("falling", true);
        }
    }



    /* private void OnTriggerEnter2D(Collider2D other)
    {
       
       if (collision.tag == "coin")
        {
            Destroy(collision.gameObject);
            Coin += 1;
            CoinNum.text = Coin.ToString();
        }
        if (collision.tag == "key")
        {
            Destroy(collision.gameObject);
            Key += 1;
            CoinNum.text = Coin.ToString();
        }


}*/




    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemies") 
        {
            Destroy(collision.gameObject);
        }
    }*/

    /*void attack()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetTrigger("Attack");
        }
        else
        {
            anim.SetTrigger("idle");
        }


    }*/

   void ReadyToDash()
    {
        isDashing = true;

        dashTimeLeft = dashTime;

        lastDash = Time.time;

        cdImage.fillAmount = 1;
    }

    void Dash()
    {
        if (isDashing)
        {
            if(dashTimeLeft > 0)
            {
                rb.velocity = new Vector2(dashSpeed * horizontalMove, rb.velocity.y);

                dashTimeLeft -= Time.deltaTime;

                ShadowPool.instance.GetFormPool();
            }
        }
        if(dashTimeLeft <= 0)
        {
            isDashing = false;
        }

    }
}
