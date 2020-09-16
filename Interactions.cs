using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactions : MonoBehaviour {

    public GameObject enter_text_img;
    public GameObject lock_img;
    public GameObject destination;

    private void Start()
    {
        enter_text_img.SetActive(false);

        if (gameObject.tag.Equals("locked"))
        {
            lock_img.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!gameObject.tag.Equals("locked"))
        {
            enter_text_img.SetActive(true);
        } else
        {
            lock_img.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gameObject.tag != "locked")                     // or key is found
        {
            if (Input.GetKeyDown("x"))
            {
                collision.transform.position = destination.transform.position;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enter_text_img.SetActive(false);
        if (gameObject.tag == "locked")
        {
            lock_img.SetActive(false);
        }
    }
}
