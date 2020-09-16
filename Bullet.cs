using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velx = 100f, vely = 0f;
    private Rigidbody2D rb2d;
    private Vector2 mouse_pos;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(velx, vely);
        Destroy(gameObject, 2f);
    }
}
