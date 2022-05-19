using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoryManager
{
    public static StateGraph<StoryState> StateGraph;
    //ͨ�����������ȡ�¼���
    public UnityEvent<StoryAction> ActionStart = new UnityEvent<StoryAction>();
    /// <summary>
    /// ��ǰ״̬
    /// </summary>
    public static StoryState curState;
    /// <summary>
    /// ״̬�б� ͼ�Ľڵ�
    /// </summary>
    private List<StoryState> activeStateList = new List<StoryState>();

    public StoryManager()
    {
        InitGraph();
        curState = StateGraph[0].Data.Data;
        curState.SetActive(true);
        activeStateList.Add(curState);
    }
    //��ʼ��ͼ�ṹ
    void InitGraph()
    {
        //----������Դ------
        StoryData storyData = new StoryData();
        //----��ʼ���ڵ�----
        List<StoryState> states = storyData.GetStatesList();
        int nodesNum = states.Count;
        Node<StoryState>[] nodes = new Node<StoryState>[nodesNum];
        for (int i = 0; i < nodesNum; i++)
        {
            nodes[i] = new Node<StoryState>(states[i]);
            Debug.Log(nodes[i].Data.state_id);
        }
        StateGraph = new StateGraph<StoryState>(nodes);
        //----��ʼ����----
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
    /// ��ȡ����id��ȷ����ǰ����
    /// </summary>
    /// <param name="trigger_id"></param>
    public void Process(string trigger_id)
    {
        for (int i = 0; i < activeStateList.Count; i++)
        {

            //���stoty�������������Ҵ��ڿ�ִ��״̬������ĵ�ǰ״̬
            if (activeStateList[i].trigger_id == trigger_id && activeStateList[i].isActive == true)
            {
                //Debug.Log("���ҵ���״̬" + curState.trigger_id);
                curState = activeStateList[i];
                NextAction();
                break;
            }
        }

    }
    //�޸ĳ���˽�з���
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
    //�޸ĳ���˽�з���

    private void NextState()
    {
        Debug.Log("nextState");
        //��ȡ
        adjListNode<StoryState> adjNode = StateGraph.GetNextNode(curState.index);
        while (adjNode != null)
        {
            StoryState state = StateGraph[adjNode.Adjvex].Data.Data;
            state.SetActive(true); //��ʵ��仰��������ģ��������ڶ����ȵ�StateҪ��������ȶ�����ſ��Խ�����
            activeStateList.Add(state);
            adjNode = adjNode.Next;
        }
    }

    public void EndAction()
    {
        NextAction();
    }
}
