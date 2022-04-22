using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolGround : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startwaitTime;
    public Transform[] movespots;
    private int randomSpot;
    void Start()
    {
        waitTime = startwaitTime;
        randomSpot = Random.Range(0, movespots.Length);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movespots[randomSpot].position, speed * Time.deltaTime);
   
        if (Vector2.Distance(transform.position, movespots[randomSpot].position) < 0.2f)
        {
            if (waitTime<=0f)
            {
                randomSpot = Random.Range(0, movespots.Length);
                waitTime = startwaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    public int dmg = 1;
    private Player player;
    private void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        player.TakeDamage(dmg);
        StartCoroutine(player.knockback(0.02f, 300, player.transform.position));
    }
}