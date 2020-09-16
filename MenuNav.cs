using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuNav : MonoBehaviour
{
    public static GameObject[] quests, menus;
    private static int quest_cnt = 0;
    public static GameObject player2;
    [HideInInspector] public static bool multi = true, awoken = true;
    private static GameObject i;

    public void Awake()
    {
        if (awoken)
        {

            menus = GameObject.FindGameObjectsWithTag("menu");

            quests = GameObject.FindGameObjectsWithTag("menu_quest");

            i = GameObject.FindGameObjectWithTag("item");

            foreach (GameObject g in quests)
            {
                g.SetActive(false);
            }
            foreach (GameObject g in menus)
            {
                g.SetActive(false);
            }

            awoken = false;

            i.SetActive(false);
        }
    }

    public void Start()
    {
        player2 = GameObject.FindGameObjectWithTag("Player2");
        if (!multi)
            Destroy(player2);
    }

    public void openMenu()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void openSubMenu()
    {
        GameObject sub = GameObject.FindGameObjectWithTag("subwindows");
        sub.SetActive(true);
        gameObject.SetActive(true);
    }

    public void closeMenu()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void closeSubMenu()
    {
        gameObject.SetActive(false);
    }

    // If the quest is not already in the list (using checkQuestRepeat),
    // create a quest object to display in the menu using the boxes defined
    // on the canvas. Set the box's text to the quest tag and move to the next box.
    public static void addRequiredQuest(string tag)
    {
        if (!checkQuestRepeat(tag))
        {
            GameObject q = quests[quest_cnt];
            q.SetActive(true);
            q.GetComponentInChildren<Text>().text = tag;
            quest_cnt++;
        }
    }

    public static void complete(string tag)
    {
        foreach (GameObject g in quests)
        {
            if (g.GetComponent<Text>().text.Equals(tag))
            {
                g.SetActive(false);
                quest_cnt--;
            }
        }
    }

    public static bool checkQuestRepeat(string tag)
    {
        foreach (GameObject q in quests)
        {
            if (q.GetComponentInChildren<Text>().text.Equals(tag)) {
                return true;
            }
        }
        return false;
    }

    public static void singleplayer()
    {
        multi = false;
        awoken = true;
        SceneManager.LoadScene("Future");
    }

    public static void multiplayer()
    {
        SceneManager.LoadScene("Future");
    }

    public static void quitToMenu()
    {
        SceneManager.LoadScene("Title Screen");
    }

    public static void quitGame()
    {
        Application.Quit();
    }

    public static void addItemToInventory()
    {
        i.SetActive(true);
    }

    public static void removeItemFromInventory()
    {
        i.SetActive(false);
    }
}