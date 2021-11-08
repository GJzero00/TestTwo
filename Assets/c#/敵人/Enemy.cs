using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    public int damage;

    private PlayerHealth playerHealth;

    public void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }


    public void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

    public void TackDamage(int damage, int playerproperty, int enemyproperty)//
    {
        if (playerproperty == enemyproperty)
        {
            health -= 0;
        }
        else
        {
            health -= damage;
        }


    }
    public void NotTackDamage(int damage)
    {
        health -= 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            if (playerHealth != null)
            {
                playerHealth.DamegePlayer(damage);
            }
        }
    }

}


