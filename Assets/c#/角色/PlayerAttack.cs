using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class PlayerAttack : MonoBehaviour
{
    public int damage;
    public int damagelight;
    public float starTime;
    public float time;
    public int playerproperty;//black=0 white=1;
    public int enemyproperty;


    private Animator anim;
    private PolygonCollider2D collider2D;

    bool SwitchS;
    bool isAnim;





    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        collider2D = GetComponent<PolygonCollider2D>();

    }

    void Update()
    {
       
            attack();

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
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("Attack");
            anim.SetBool("idle", false);
            StartCoroutine(StarAttack());
        }
        else
        {
            anim.SetBool("idle", true);
            anim.SetTrigger("idle");
        }
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
