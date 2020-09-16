using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2JoystickControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float speed = 7f;
    private bool isGrounded;

    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        isGrounded = true;
    }

    // If joystick pushed vertically, add an upwards force.
    // Horizontal motions already set in Unity Editor; flip side to side.
    void Update()
    {
        if (Input.GetAxis("Vertical_Joystick") > 0 && isGrounded)
            rb2d.AddForce(new Vector2(0, 4), ForceMode2D.Impulse);
        Vector3 move = new Vector3(Input.GetAxis("Horizontal_Joystick"), 0, 0);
        transform.position += move * speed * Time.deltaTime;
        if (Input.GetAxis("Horizontal_Joystick") < 0)
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        if (Input.GetAxis("Horizontal_Joystick") > 0)
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
    }
}