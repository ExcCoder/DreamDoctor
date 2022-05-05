using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoryManager
{
    public static GraphAdjList<StoryState> StateGraph;
    public UnityEvent<StoryAction> ActionStart = new UnityEvent<StoryAction>();

    private StoryState curState;
    private List<StoryState> activeStateList = new List<StoryState>();

    public StoryManager()
    {
        InitGraph();
        curState = StateGraph[0].Data.Data;
        curState.SetActive(true);
        activeStateList.Add(curState);
    }

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
        }
        StateGraph = new GraphAdjList<StoryState>(nodes);
        //----初始化边----
        List<(StoryState, StoryState)> edges = storyData.GetEdgesList();
        for (int i = 0; i < edges.Count; i++)
        {
            Node<StoryState> v1 = new Node<StoryState>(edges[i].Item1);
            Node<StoryState> v2 = new Node<StoryState>(edges[i].Item2);
            StateGraph.SetEdge(v1, v2, 1);
        } 
    }

    public void Process(string trigger_id)
    {
        foreach (var item in activeStateList)
        {
            Debug.Log(item.trigger_id);
            if (item.trigger_id == trigger_id && item.isActive == true)
            {
                curState = item;
                NextAction();
            }
        }
    }

    public void NextAction()
    {
        //StoryAction action = curState.actionContent.Dequeue();

        if (curState.actionContent.Count > 0)
        {
            StoryAction action = curState.actionContent.Dequeue();
            ActionStart.Invoke(action);
        }
        else
            NextState();
    }

    public void NextState()
    {
        adjListNode<StoryState> adjNode = StateGraph.GetAdjacentNode(curState.index);
        while (adjNode!= null)
        {
            StoryState state = StateGraph[adjNode.Adjvex].Data.Data;
            state.SetActive(true); //其实这句话是有问题的，问题在于多个入度的State要让所有入度都满足才可以解锁。
        }
    }
}
