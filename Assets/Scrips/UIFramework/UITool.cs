using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UI�����ߣ�������ȡĳ���Ӷ�������Ĳ���
/// </summary>
public class UITool
{
    //��ȡ��ǰ�Ļ���
    GameObject activePanel;
    //��ʼ��
    public UITool(GameObject panel)
    {
        activePanel = panel;
    }
    //����ǰ�Ļ����ȡ�������һ�����
    public T GetOrAddComponent<T>() where T:Component
    {
        if (activePanel.GetComponent<T>() == null)
            activePanel.AddComponent<T>();
        return activePanel.GetComponent<T>();
    }
    //�������Ʋ��Ҷ���
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
        Debug.LogWarning($"{ activePanel.name}���Ҳ�����Ϊ{name}�Ķ���");
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
        Debug.LogWarning($"{ faTF.name}���Ҳ�����Ϊ{ChilderName}�Ķ���");
        return null;
    }
    //�������ƻ�ȡһ���Ӷ�������
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
