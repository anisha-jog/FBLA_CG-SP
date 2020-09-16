using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestList : MonoBehaviour
{
    private static List<Quest> required = new List<Quest>(), optional = new List<Quest>();

    // Start is called before the first frame update
    void Start()
    {
        required.Clear();
        optional.Clear();
    }

    public static void addRequiredQuest(string task)
    {
        required.Add(new Quest(task));
        MenuNav.addRequiredQuest(task);
    }

    public static void addOptionalQuest(string task)
    {
        optional.Add(new Quest(task));
    }

    public static void completeQuest(Quest x)
    {
        x.markQuestCompleted();
        MenuNav.complete(x.getTask());
    }

    public static void completeQuest(string task)
    {
        foreach (Quest x in required)
        {
            if (x.getTask().Equals(task))
            {
                x.markQuestCompleted();
                MenuNav.complete(task);
            }
        }
    }

    public static bool checkForExistingRequiredQuest(string task)
    {
        foreach (Quest x in required)
        {
            if (x.getTask().Equals(task))
            {
                return true;
            }
        }
        return false;
    }

    public static bool checkForExistingOptionalQuest(string task)
    {
        foreach (Quest x in optional)
        {
            if (x.getTask().Equals(task))
            {
                return true;
            }
        }
        return false;
    }
}