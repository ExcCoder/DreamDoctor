using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoryManager
{
    public static StateGraph<StoryState> StateGraph;
    //通过活动内容来获取事件，
    public UnityEvent<StoryAction> ActionStart = new UnityEvent<StoryAction>();
    /// <summary>
    /// 当前状态
    /// </summary>
    public static StoryState curState;
    /// <summary>
    /// 状态列表 图的节点
    /// </summary>
    private List<StoryState> activeStateList = new List<StoryState>();

    public StoryManager()
    {
        InitGraph();
        curState = StateGraph[0].Data.Data;
        curState.SetActive(true);
        activeStateList.Add(curState);
    }
    //初始化图结构
    void InitGraph()
    {
        //----数据来源------
        StoryData storyData = new StoryData();
        //----初始化节点----
        List<StoryState> states = storyData.GetStatesList();
        int nodesNum = states.Count;
        Node<StoryState>[] nodes = new Node<StoryState>[nodesNum];
        for (int i = 0; i < nodesNum; i++)
        {
            nodes[i] = new Node<StoryState>(states[i]);
            Debug.Log(nodes[i].Data.state_id);
        }
        StateGraph = new StateGraph<StoryState>(nodes);
        //----初始化边----
        List<(StoryState, StoryState)> edges = storyData.GetEdgesList();
        for (int i = 0; i < edges.Count; i++)
        {
            Debug.Log(edges[i].Item1.state_id + "--" + edges[i].Item2.state_id);
            Node<StoryState> v1 = new Node<StoryState>(edges[i].Item1);
            Node<StoryState> v2 = new Node<StoryState>(edges[i].Item2);
            StateGraph.SetEdge(v1, v2, 1);
        }
    }
    /// <summary>
    /// 获取触发id来确定当前流程
    /// </summary>
    /// <param name="trigger_id"></param>
    public void Process(string trigger_id)
    {
        for (int i = 0; i < activeStateList.Count; i++)
        {

            //如果stoty里有这个活动，并且处于可执行状态，则更改当前状态
            if (activeStateList[i].trigger_id == trigger_id && activeStateList[i].isActive == true)
            {
                //Debug.Log("查找到的状态" + curState.trigger_id);
                curState = activeStateList[i];
                NextAction();
                break;
            }
        }

    }
    //修改成了私有方法
    private void NextAction()
    {
        //StoryAction action = curState.actionContent.Dequeue();

        if (curState.actionContent.Count > 0)
        {
            //Debug.Log("Process NextActive"); 
            StoryAction action = curState.actionContent.Dequeue();
            ActionStart.Invoke(action);
        }
        else
        {
            activeStateList.Remove(curState);
            NextState();
        }

    }
    //修改成了私有方法

    private void NextState()
    {
        Debug.Log("nextState");
        //获取
        adjListNode<StoryState> adjNode = StateGraph.GetNextNode(curState.index);
        while (adjNode != null)
        {
            StoryState state = StateGraph[adjNode.Adjvex].Data.Data;
            state.SetActive(true); //其实这句话是有问题的，问题在于多个入度的State要让所有入度都满足才可以解锁。
            activeStateList.Add(state);
            adjNode = adjNode.Next;
        }
    }

    public void EndAction()
    {
        NextAction();
    }
}
