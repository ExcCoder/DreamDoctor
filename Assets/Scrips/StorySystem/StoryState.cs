using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryState
{
    /// <summary>
    /// 状态下标
    /// </summary>
    public int index;
    /// <summary>
    /// 是否可活动
    /// </summary>
    public bool isActive;
    /// <summary>
    /// 状态id
    /// </summary>
    public string state_id;
    /// <summary>
    /// 触发器获取的状态
    /// </summary>
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

    public override bool Equals(object obj)
    {
        StoryState state = obj as StoryState;
        return state.state_id.Equals(this.state_id);
    }
}

