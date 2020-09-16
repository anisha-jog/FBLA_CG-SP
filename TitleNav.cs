using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleNav : MonoBehaviour
{
    public GameObject instructions_panel, achievements_panel;
    public GameObject[] play_buttons, other_buttons;

    public void Start()
    {
        foreach (GameObject b in play_buttons)
        {
            b.SetActive(false);
        }
    }

    public void openInstructions()
    {
        instructions_panel.SetActive(true);
    }

    public void closeInstructions()
    {
        instructions_panel.SetActive(false);
    }

    public void openAchievements()
    {
        achievements_panel.SetActive(true);
    }

    public void closeAchievements()
    {
        achievements_panel.SetActive(false);
    }

    public void loadPlayButtons()
    {
        foreach (GameObject b in other_buttons)
        {
            b.SetActive(false);
        }
        foreach (GameObject b in play_buttons)
        {
            b.SetActive(true);
        }
    }

    public void unloadPlayButtons()
    {
        foreach (GameObject b in other_buttons)
        {
            b.SetActive(true);
        }
        foreach (GameObject b in play_buttons)
        {
            b.SetActive(false);
        }
    }

    public void quit()
    {
        Application.Quit();
    }

    public void setSinglePlayer()
    {
        MenuNav.singleplayer();
    }

    public void setMultiPlayer()
    {
        MenuNav.multiplayer();
    }
}