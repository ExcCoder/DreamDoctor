using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �洢���е�UI��Ϣ�������Դ���������UI
/// </summary>
public class UIManager
{
    /// <summary>
    /// �洢����UI��Ϣ���ֵ䣬ÿһ��UI��Ϣ�����Ӧһ��GameObject
    /// </summary>
    public Dictionary<UIType, GameObject> dicUI;
   public UIManager()
    {
        //��ʼ���ֵ�
        dicUI = new Dictionary<UIType, GameObject>();
    }
    /// <summary>
    /// ���һ��������UI�������UI
    /// </summary>
    /// <param name="type">UI��Ϣ</param>
    /// <returns></returns>
    public GameObject GetSingleUI(UIType type)
    {
        GameObject parent = GameObject.Find("Canvas");
        if (!parent)
        {
            Debug.LogError("Canvas���󲻴��ڣ�����ϸ����");
            return null;
        }
        if (dicUI.ContainsKey(type))
        {
            return dicUI[type];
        }
        //����һ��UI����Path·��
        GameObject ui = GameObject.Instantiate(Resources.Load<GameObject>(type.Path),parent.transform);
        ui.name = type.Name;
        dicUI.Add(type,ui);
        return ui;

    }
    /// <summary>
    /// ɾ��һ��UI
    /// </summary>
    /// <param name="type"></param>
    public void DestroyUI(UIType type)
    {
        if (dicUI.ContainsKey(type))
        {
            GameObject.Destroy(dicUI[type]);
            dicUI.Remove(type);
        }
    }
}
