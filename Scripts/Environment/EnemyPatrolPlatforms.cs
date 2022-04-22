using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolPlatforms : MonoBehaviour
{
    public int dmg = 1;
    private Player player;
    public float speed;
    public float distance;
    private bool movingRight = true;
    public Transform groundDetection;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position,Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, -0, 0);
                movingRight = true;
            }
        }
    }

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