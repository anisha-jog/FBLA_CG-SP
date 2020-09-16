using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl2D : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float speed = 7f;
    private bool isGrounded, fireActive;
    private int player_health;

    public int damage;
    public GameObject menu;
    public GameObject bullet_right, bullet_left;
    private Vector2 bullet_pos, mouse_pos;
    private float fire_rate = 0.5f, next_fire = 0f;
    private Camera cam;

    public Image heart1, heart2, heart3;

    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        isGrounded = true;

        player_health = 3;
        
        fireActive = true;
        cam = Camera.main;
    }

    void Update()
    {
        mouse_pos = cam.ScreenToWorldPoint(Input.mousePosition);
        if ((Input.GetKeyDown("up") || Input.GetKeyDown("w") || Input.GetKeyDown("space")) && isGrounded)
            rb2d.AddForce(new Vector2(0, 9), ForceMode2D.Impulse);
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += move * speed * Time.deltaTime;
        if (Input.GetKeyDown("left") || Input.GetKeyDown("a"))
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        } if (Input.GetKeyDown("right") || Input.GetKeyDown("d"))
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Input.GetMouseButtonDown(0) && !menu.activeInHierarchy)
        {
            if (mouse_pos.x > transform.position.x)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            } else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        if (player_health <= 0)
        {
            Restart();
        }

        if (Input.GetMouseButtonDown(0) && !menu.activeInHierarchy && Time.time > next_fire && fireActive)
        {
            next_fire = Time.time + fire_rate;
            fire();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
            isGrounded = false;
    }

    private void Restart()
    {
        SceneManager.LoadScene("Game Over");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("boss"))
        {
            player_health -= 1;
            if (heart1.enabled)
            {
                heart1.enabled = false;
            } else if (heart2.enabled)
            {
                heart2.enabled = false;
            } else
            {
                heart3.enabled = false;
            }
        }
    }

    private void fire()
    {
        bullet_pos = transform.position;
        if (mouse_pos.x > transform.position.x)
        {
            bullet_pos += new Vector2(+1f, 0f);
            Instantiate(bullet_right, bullet_pos, Quaternion.identity);
        }
        else
        {
            bullet_pos += new Vector2(-1f, 0f);
            Instantiate(bullet_left, bullet_pos, Quaternion.identity);
        }
    }
}