using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IGraph<T>
{
    //获取顶点数
    int GetNumOfVertex();
    //获取边或弧的数目
    int GetNumOfEdge();
    //在两个顶点之间添加权为v的边或弧
    void SetEdge(Node<T> v1, Node<T> v2, int v);
    //删除两个顶点之间的边或弧
    void DelEdge(Node<T> v1, Node<T> v2);
    //判断两个顶点之间是否有边或弧
    bool IsEdge(Node<T> v1, Node<T> v2);
}
