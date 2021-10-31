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
    public Transform groundCheck;
    public LayerMask ground;
    public int Coin, Key,Q;

    

    public Text CoinNum;
  

    public bool isGround, isJump;
    
    bool jumpPressed;
    int jumpCount;

    public GameObject BossTrigger;
    public GameObject Panel;




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
    }
    private void FixedUpdate()
    {

        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);

        GroundMovement();

        Jump();

        SwitchAnim();

        take();
    }
    void GroundMovement()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
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

    public void OnTriggerEnter2D(Collider2D collision)
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
        if(collision.tag == "NPC")
        {
            Q = 1;
            CoinNum.text = Coin.ToString();         
        }
        
    }
   public void take()
    {
        if (Q == 1 )
        {
            BossTrigger.SetActive(true);
        }
        else
            BossTrigger.SetActive(false);
    }





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
}
