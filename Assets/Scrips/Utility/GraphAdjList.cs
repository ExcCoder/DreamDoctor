using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public class GraphAdjList<T>
{
    //邻接表数组
    private VexNode<T>[] adjList;

    //索引器
    public VexNode<T> this[int index]
    {
        get
        {
            return adjList[index];
        }
        set
        {
            adjList[index] = value;
        }
    }

    //构造器
    public GraphAdjList(Node<T>[] nodes)
    {
        adjList = new VexNode<T>[nodes.Length];
        for (int i = 0; i < nodes.Length; ++i)
        {
            adjList[i] = new VexNode<T>(nodes[i]);
            adjList[i].Data = nodes[i];
            adjList[i].FirstAdj = null;
        }
    }


    //获取顶点的数目
    public int GetNumOfVertex()
    {
        return adjList.Length;
    }

    //获取边的数目
    public int GetNumOfEdge()
    {
        int i = 0;

        foreach (VexNode<T> nd in adjList)
        {
            adjListNode<T> p = nd.FirstAdj;
            while (p != null)
            {
                ++i;
                p = p.Next;
            }
        }

        return i / 2;//无向图
    }

    //判断v是否是图的顶点
    public bool IsNode(Node<T> v)
    {
        //遍历邻接表数组
        foreach (VexNode<T> nd in adjList)
        {
            //如果v等于nd的data，则v是图中的顶点，返回true
            if (v.Equals(nd.Data))
            {
                return true;
            }
        }
        return false;
    }

    //获取顶点v在邻接表数组中的索引
    public int GetIndex(Node<T> v)
    {
        int i = -1;
        //遍历邻接表数组
        for (i = 0; i < adjList.Length; ++i)
        {
            //邻接表数组第i项的data值等于v，则顶点v的索引为i
            if (adjList[i].Data.Equals(v))
            {
                return i;
            }
        }
        return i;
    }

    //判断v1和v2之间是否存在边
    public bool IsEdge(Node<T> v1, Node<T> v2)
    {
        //v1或v2不是图的顶点
        if (!IsNode(v1) || !IsNode(v2))
        {
            Debug.Log("Node is not belong to Graph!");
            return false;
        }
        adjListNode<T> p = adjList[GetIndex(v1)].FirstAdj;
        while (p != null)
        {
            if (p.Adjvex == GetIndex(v2))
            {
                return true;
            }

            p = p.Next;
        }

        return false;
    }

    //在顶点v1和v2之间添加权值为v的边
    public void SetEdge(Node<T> v1, Node<T> v2, int v)
    {
        //v1或v2不是图的顶点或者v1和v2之间存在边
        if (!IsNode(v1) || !IsNode(v2) || IsEdge(v1, v2))
        {
            Debug.Log("Node is not belong to Graph!");
            return;
        }

        //权值不对
        if (v != 1)
        {
            Debug.Log("Weight is not right!");
            return;
        }

        //处理顶点v1的邻接表
        adjListNode<T> p = new adjListNode<T>(GetIndex(v2));

        if (adjList[GetIndex(v1)].FirstAdj == null)
        {
            adjList[GetIndex(v1)].FirstAdj = p;
        }
        //顶点v1有邻接顶点
        else
        {
            p.Next = adjList[GetIndex(v1)].FirstAdj;
            adjList[GetIndex(v1)].FirstAdj = p;
        }

        //处理顶点v2的邻接表
        p = new adjListNode<T>(GetIndex(v1));

        //顶点v2没有邻接顶点
        if (adjList[GetIndex(v2)].FirstAdj == null)
        {
            adjList[GetIndex(v2)].FirstAdj = p;
        }

        //顶点v2有邻接顶点
        else
        {
            p.Next = adjList[GetIndex(v2)].FirstAdj;
            adjList[GetIndex(v2)].FirstAdj = p;
        }
    }

    //删除顶点v1和v2之间的边
    public void DelEdge(Node<T> v1, Node<T> v2)
    {
        //v1或v2不是图的顶点
        if (!IsNode(v1) || !IsNode(v2))
        {
            Debug.Log("Node is not belong to Graph!");
            return;
        }

        //顶点v1与v2之间有边
        if (IsEdge(v1, v2))
        {
            //处理顶点v1的邻接表中的顶点v2的邻接表结点
            adjListNode<T> p = adjList[GetIndex(v1)].FirstAdj;
            adjListNode<T> pre = null;

            while (p != null)
            {
                if (p.Adjvex != GetIndex(v2))
                {
                    pre = p;
                    p = p.Next;
                }
            }
            pre.Next = p.Next;

            //处理顶点v2的邻接表中的顶点v1的邻接表结点
            p = adjList[GetIndex(v2)].FirstAdj;
            pre = null;

            while (p != null)
            {
                if (p.Adjvex != GetIndex(v1))
                {
                    pre = p;
                    p = p.Next;
                }
            }
            pre.Next = p.Next;
        }
    }

    public adjListNode<T> GetAdjacentNode(int index)
    {
        return adjList[index].FirstAdj;
    }
}
