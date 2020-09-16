using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private static int health = 100;
    private int damage = 10;
    private Transform player_pos;
    private float speed;

    private void Start()
    {
        player_pos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        speed = 5f;
    }

    private void Update()
    {
        Vector2 tgt = new Vector2(player_pos.position.x, gameObject.transform.position.y);
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, tgt, speed * Time.deltaTime);
    }

    public static int getHealth()
    {
        return health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("attack"))
        {
            health -= damage;
        }
        if (collision.tag.Equals("wall"))
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = !gameObject.GetComponent<SpriteRenderer>().flipX;
        }
    }
}
