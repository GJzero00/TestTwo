using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class PlayerAttack : MonoBehaviour
{
    public int damage;
    public float time;//時長
    public float starTime;//開始顯示時間
    private float lastAttack = -10f;
    public float attackCoolDown;

    public int playerproperty;//black=0 white=1;
    public int enemyproperty;

    private Animator anim;
    private PolygonCollider2D collider2D;

    public bool SwitchS;
    public bool isattackCD;





    void OnEnable()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        collider2D = GetComponent<PolygonCollider2D>();

        starTime = Time.time;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (Time.time >= (lastAttack + attackCoolDown))
            {
                attack();
            }
            NOattack();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {

            if (SwitchS)
            {
                Black();

            }
            else
            {
                White();
            }
        }

    }

    void White()
    {

        playerproperty = 1;
        SwitchS = true;
        anim.SetTrigger("S");
        anim.SetBool("W", true);
        anim.SetBool("B", false);
    }

    void Black()
    {
        playerproperty = 0;
        SwitchS = false;
        anim.SetTrigger("S");
        anim.SetBool("B", true);
        anim.SetBool("W", false);
    }

    void attack()
    {
        isattackCD = true;
        starTime = time;
        lastAttack = Time.time;
        anim.SetTrigger("Attack");
        anim.SetBool("attack", true);
        anim.SetBool("idle", false);
        StartCoroutine(StarAttack());
    }
    void NOattack()
    {
        anim.SetBool("idle", true);
        anim.SetTrigger("idle");
    }

    IEnumerator StarAttack()
    {
        yield return new WaitForSeconds(starTime);
        collider2D.enabled = true;
        StartCoroutine(disableHitBox());
    }


    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        collider2D.enabled = false;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemies"))
        {
            other.GetComponent<BossTrack>().TackDamage(damage, playerproperty, enemyproperty);
        }
    }
}