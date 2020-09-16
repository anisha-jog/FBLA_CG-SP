using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    private string task;
    private bool completed;
    
    public Quest(string name)
    {
        task = name;
        completed = false;
    }

    public void markQuestCompleted()
    {
        completed = true;
    }

    public bool getCompletionStatus()
    {
        return completed;
    }

    public string getTask()
    {
        return task;
    }
}
