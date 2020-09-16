using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossFight : MonoBehaviour
{
    public Slider health_bar;
    public GameObject end_blocker, boss, boss_health_holder;

    // Start is called before the first frame update
    void Start()
    {
        boss_health_holder.SetActive(false);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    private void Update()
    {
        health_bar.value = Boss.getHealth();

        if (Boss.getHealth() <= 0)
        {
            Destroy(end_blocker);
            Destroy(boss_health_holder);
            Destroy(boss);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            boss_health_holder.SetActive(true);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
