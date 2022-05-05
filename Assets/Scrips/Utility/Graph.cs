using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node<T>
{
    private T data; //������
                    //������
    public Node(T v)
    {
        data = v;
    }
    //����������
    public T Data
    {
        get
        {
            return data;
        }
        set
        {
            data = value;
        }
    }
}
/// <summary>
/// ����ͼ�ڽӱ����ʵ��
/// </summary>
/// <typeparam name="T"></typeparam>
public class adjListNode<T>
{
    private int adjvex;//�ڽӶ���
    private adjListNode<T> next;//��һ���ڽӱ���

    //�ڽӶ�������
    public int Adjvex
    {
        get { return adjvex; }
        set { adjvex = value; }
    }

    //��һ���ڽӱ�������
    public adjListNode<T> Next
    {
        get { return next; }
        set { next = value; }
    }

    public adjListNode(int vex)
    {
        adjvex = vex;
        next = null;
    }
}

/// <summary>
/// ����ͼ�ڽӱ�Ķ�������
/// </summary>
/// <typeparam name="T"></typeparam>
public class VexNode<T>
{
    private Node<T> data; //ͼ�Ķ���
    private adjListNode<T> firstAdj; //�ڽӱ�ĵ�1�����

    public Node<T> Data
    {
        get { return data; }
        set { data = value; }
    }

    //�ڽӱ�ĵ�1���������
    public adjListNode<T> FirstAdj
    {
        get { return firstAdj; }
        set { firstAdj = value; }
    }

    //������
    public VexNode()
    {
        data = null;
        firstAdj = null;
    }

    //������
    public VexNode(Node<T> nd)
    {
        data = nd;
        firstAdj = null;
    }

    //������
    public VexNode(Node<T> nd, adjListNode<T> alNode)
    {
        data = nd;
        firstAdj = alNode;
    }
}

public interface IGraph<T>
{
    //��ȡ������
    int GetNumOfVertex();
    //��ȡ�߻򻡵���Ŀ
    int GetNumOfEdge();
    //����������֮�����ȨΪv�ı߻�
    void SetEdge(Node<T> v1, Node<T> v2, int v);
    //ɾ����������֮��ı߻�
    void DelEdge(Node<T> v1, Node<T> v2);
    //�ж���������֮���Ƿ��б߻�
    bool IsEdge(Node<T> v1, Node<T> v2);
}

/// <summary>
/// ����ͼ�ڽӱ���
/// </summary>
/// <typeparam name="T"></typeparam>
public class GraphAdjList<T> : IGraph<T>
{
    //�ڽӱ�����
    private VexNode<T>[] adjList;

    //������
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

    //������
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


    //��ȡ�������Ŀ
    public int GetNumOfVertex()
    {
        return adjList.Length;
    }

    //��ȡ�ߵ���Ŀ
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

        return i / 2;//����ͼ
    }

    //�ж�v�Ƿ���ͼ�Ķ���
    public bool IsNode(Node<T> v)
    {
        //�����ڽӱ�����
        foreach (VexNode<T> nd in adjList)
        {
            //���v����nd��data����v��ͼ�еĶ��㣬����true
            if (v.Equals(nd.Data))
            {
                return true;
            }
        }
        return false;
    }

    //��ȡ����v���ڽӱ������е�����
    public int GetIndex(Node<T> v)
    {
        int i = -1;
        //�����ڽӱ�����
        for (i = 0; i < adjList.Length; ++i)
        {
            //�ڽӱ������i���dataֵ����v���򶥵�v������Ϊi
            if (adjList[i].Data.Equals(v))
            {
                return i;
            }
        }
        return i;
    }

    //�ж�v1��v2֮���Ƿ���ڱ�
    public bool IsEdge(Node<T> v1, Node<T> v2)
    {
        //v1��v2����ͼ�Ķ���
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

    //�ڶ���v1��v2֮�����ȨֵΪv�ı�
    public void SetEdge(Node<T> v1, Node<T> v2, int v)
    {
        //v1��v2����ͼ�Ķ������v1��v2֮����ڱ�
        if (!IsNode(v1) || !IsNode(v2) || IsEdge(v1, v2))
        {
            Debug.Log("Node is not belong to Graph!");
            return;
        }

        //Ȩֵ����
        if (v != 1)
        {
            Debug.Log("Weight is not right!");
            return;
        }

        //������v1���ڽӱ�
        adjListNode<T> p = new adjListNode<T>(GetIndex(v2));

        if (adjList[GetIndex(v1)].FirstAdj == null)
        {
            adjList[GetIndex(v1)].FirstAdj = p;
        }
        //����v1���ڽӶ���
        else
        {
            p.Next = adjList[GetIndex(v1)].FirstAdj;
            adjList[GetIndex(v1)].FirstAdj = p;
        }

        //������v2���ڽӱ�
        p = new adjListNode<T>(GetIndex(v1));

        //����v2û���ڽӶ���
        if (adjList[GetIndex(v2)].FirstAdj == null)
        {
            adjList[GetIndex(v2)].FirstAdj = p;
        }

        //����v2���ڽӶ���
        else
        {
            p.Next = adjList[GetIndex(v2)].FirstAdj;
            adjList[GetIndex(v2)].FirstAdj = p;
        }
    }

    //ɾ������v1��v2֮��ı�
    public void DelEdge(Node<T> v1, Node<T> v2)
    {
        //v1��v2����ͼ�Ķ���
        if (!IsNode(v1) || !IsNode(v2))
        {
            Debug.Log("Node is not belong to Graph!");
            return;
        }

        //����v1��v2֮���б�
        if (IsEdge(v1, v2))
        {
            //������v1���ڽӱ��еĶ���v2���ڽӱ���
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

            //������v2���ڽӱ��еĶ���v1���ڽӱ���
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