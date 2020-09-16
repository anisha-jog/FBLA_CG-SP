using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scoreboard : MonoBehaviour
{
    public GameObject scoreboard;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreboard.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        scoreboard.SetActive(true);
    }

    public void close()
    {
        gameObject.SetActive(false);
        scoreboard.SetActive(false);
        SceneManager.LoadScene("Business");
    }
}