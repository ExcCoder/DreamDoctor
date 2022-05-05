using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryState
{
    public int index;
    public bool isActive;
    public string state_id;
    public string trigger_id;
    public Queue<StoryAction> actionContent;

    public StoryState(int index, string state_id, string trigger_id, Queue<StoryAction> actionContent)
    {
        this.index = index;
        this.isActive = false;
        this.state_id = state_id;
        this.trigger_id = trigger_id;
        this.actionContent = actionContent;
    }

    public void SetActive(bool flag)
    {
        isActive = flag;
    }
}

public class StoryAction
{
    public string targetName;
    public string actionName;
    public object info;

    public StoryAction(string targetName, string actionName, object info)
    {
        this.targetName = targetName;
        this.actionName = actionName;
        this.info = info;
    }
}