using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  public  class Node<T>
    {
    private T data; //数据域
                    //构造器
    public Node(T v)
    {
        data = v;
    }
    //数据域属性
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

    public override bool Equals(object obj)
    {
        Node<T> node = obj as Node<T>;
        return node.data.Equals(this.data);        
    }

}
