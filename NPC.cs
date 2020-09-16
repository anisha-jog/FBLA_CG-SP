using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour {

    public string location;
    public string quest_tag;
    private Queue<string> log;
    public GameObject box, txt_holder, store_inventory_page;
    public Text txt;
    public bool needsItem;

    public void Start()
    {
        log = ReadLog(location);
        if (gameObject.tag.Equals("store"))
            store_inventory_page.SetActive(false);
    }

    // Reads log from predetermined file path
    // Enqueues line by line in the txt file
    Queue<string> ReadLog(string path)
    {
        StreamReader reader = new StreamReader(path);
        Queue<string> dialoglog = new Queue<string>();

        string line = reader.ReadLine();
        while (line != null)
        {
            dialoglog.Enqueue(line);
            line = reader.ReadLine();
        }

        reader.Close();
        return dialoglog;
    }

    public void PlayLog()
    {
        if (log.Count == 0)
        {
            box.SetActive(false);
            txt_holder.SetActive(false);
            Start();

            if (gameObject.tag.Equals("questr"))
            {
                QuestList.addRequiredQuest(quest_tag);
            }
            if (gameObject.tag.Equals("store"))
            {
                store_inventory_page.SetActive(true);
            }

            return;
        }
        box.SetActive(true);
        txt_holder.SetActive(true);
        string s = log.Dequeue();
        txt.text = s;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown("x"))
        {
            if (gameObject.tag.Equals("questr") && needsItem)
            {
                if (ItemCollect.getCollected())
                {
                    QuestList.completeQuest(quest_tag);
                    MenuNav.removeItemFromInventory();
                }
                else
                {
                    PlayLog();
                }
            }
            else
            {
                PlayLog();
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Player") || other.tag.Equals("Player2"))
        {
            box.SetActive(false);
            txt_holder.SetActive(false);
            Start();
        }
    }
}