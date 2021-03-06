using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Enemy
{
    public float speed;
    public float starWaitTime;
    private float waitTime;

    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;


    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        waitTime = starWaitTime;
        movePos.position = GetRandomPos();

    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();

        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);
    
       if(Vector2.Distance(transform.position,movePos.position)<= 2f)
        {
            if (waitTime <= 0)
            {
                movePos.position = GetRandomPos();
                waitTime = starWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x), Random.Range(leftDownPos.position.y, rightUpPos.position.y));
        return rndPos;
    }
}
