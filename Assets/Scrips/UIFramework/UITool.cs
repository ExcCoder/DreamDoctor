using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UI管理工具，包括获取某个子对象组件的操作
/// </summary>
public class UITool
{
    //获取当前的活动面板
    GameObject activePanel;
    //初始化
    public UITool(GameObject panel)
    {
        activePanel = panel;
    }
    //给当前的活动面板获取或者添加一个组件
    public T GetOrAddComponent<T>() where T:Component
    {
        if (activePanel.GetComponent<T>() == null)
            activePanel.AddComponent<T>();
        return activePanel.GetComponent<T>();
    }
    //根据名称查找对象
    public GameObject FindChildGameObject(string name)
    {
        Transform[] trans = activePanel.GetComponentsInChildren<Transform>();
        foreach(Transform item in trans)
        {
            if (item.name==name)
            {
                return item.gameObject;
            }
        }
        Debug.LogWarning($"{ activePanel.name}里找不到名为{name}的对象");
        return null;
    }
    public GameObject FindChildssGameObject(Transform faTF,string ChilderName) 
    {
        Transform childTF = faTF.Find(ChilderName);
        if (childTF!=null) return childTF.gameObject;
        for (int i = 0; i < faTF.childCount; i++)
        {
            childTF = FindChildssGameObject(faTF.GetChild(i), ChilderName).transform;
            if (childTF != null) return childTF.gameObject;
        }
        Debug.LogWarning($"{ faTF.name}里找不到名为{ChilderName}的对象");
        return null;
    }
    //根据名称获取一个子对象的组件
    public T GetOrAddComponentInChild<T>(string name) where T : Component
    {
        GameObject child = FindChildGameObject(name);
        if (child)
        {
            if (child.GetComponent<T>()==null)
                child.AddComponent<T>();
            return child.GetComponent<T>();
        }
        return null;
    }
   
}
