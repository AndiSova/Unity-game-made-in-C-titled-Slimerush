using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public int dmg=1;
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
