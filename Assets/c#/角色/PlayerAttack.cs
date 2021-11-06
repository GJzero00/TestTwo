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
    

    private Animator anim;
    private PolygonCollider2D collider2D;


    bool Animcheck;


    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        collider2D = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        attack();
    }


    void attack()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Animcheck = true;
            anim.SetTrigger("Attack");
            StartCoroutine(StarAttack());
        }
        else
        {
            Animcheck = false;
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
        StartCoroutine(attackcheck());
    }

    IEnumerator attackcheck()
    {
        yield return new WaitForSeconds(2);
        Animcheck = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemies"))
        {
            other.GetComponent<BossTrack>().TackDamage(damage);
        }
    }
}


