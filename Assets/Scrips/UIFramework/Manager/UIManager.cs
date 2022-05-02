using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 存储所有的UI信息，并可以创建或销毁UI
/// </summary>
public class UIManager
{
    /// <summary>
    /// 存储所有UI信息的字典，每一个UI信息都会对应一个GameObject
    /// </summary>
    public Dictionary<UIType, GameObject> dicUI;
   public UIManager()
    {
        //初始化字典
        dicUI = new Dictionary<UIType, GameObject>();
    }
    /// <summary>
    /// 获得一个单独的UI返回这个UI
    /// </summary>
    /// <param name="type">UI信息</param>
    /// <returns></returns>
    public GameObject GetSingleUI(UIType type)
    {
        GameObject parent = GameObject.Find("Canvas");
        if (!parent)
        {
            Debug.LogError("Canvas对象不存在，请仔细查找");
            return null;
        }
        if (dicUI.ContainsKey(type))
        {
            return dicUI[type];
        }
        //创建一个UI来自Path路径
        GameObject ui = GameObject.Instantiate(Resources.Load<GameObject>(type.Path),parent.transform);
        ui.name = type.Name;
        dicUI.Add(type,ui);
        return ui;

    }
    /// <summary>
    /// 删除一个UI
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
