using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 所有面板的父类，包含UI面板的信息
/// </summary>
public class BasePanel
{
    /// <summary>
    /// UI信息
    /// </summary>
    public UIType UIType { get; private set; }
    /// <summary>
    /// UI管理器
    /// </summary>
    public UITool UITool { get; private set; }
    /// <summary>
    /// 面板管理器
    /// </summary>
    public PanelManager PanelManager { get; private set; }
    /// <summary>
    /// UI管理器
    /// </summary>
    public UIManager UIManager { get; private set; }
    public BasePanel(UIType uIType)
    {
        UIType = uIType;
    }
    /// <summary>
    /// 初始化UITool
    /// </summary>
    /// <param name="tool"></param>
    public void Intialize(UITool tool)
    {
        UITool = tool;
    }
    /// <summary>
    /// 初始化面板管理器
    /// </summary>
    /// <param name="panelManager"></param>
    public void Intialize(PanelManager panelManager)
    {
        PanelManager = panelManager;
    }
    /// <summary>
    /// 初始化UI管理器
    /// </summary>
    /// <param name="uIManager"></param>
    public void Intialize(UIManager uIManager)
    {
        UIManager = uIManager;
    }
    /// <summary>
    /// 进入UI时执行，只会执行一次
    /// </summary>
    public virtual void OnEnter() { }
    /// <summary>
    /// UI暂停时执行
    /// </summary>
    public virtual void OnPause()
    {
        UITool.GetOrAddComponent<CanvasGroup>().blocksRaycasts = false;
    }
    /// <summary>
    /// UI继续执行时
    /// </summary>
    public virtual void OnResume()
    {
        UITool.GetOrAddComponent<CanvasGroup>().blocksRaycasts = true;
    }
    /// <summary>
    /// UI退出时执行
    /// </summary>
    public virtual void OnExit()
    {
        UIManager.DestroyUI(UIType);
    }
    public void Push(BasePanel panel) => PanelManager?.Push(panel);
    public void Pop()
    {
        Debug.Log("pop");
        PanelManager?.Pop();
    }
    public void PopAll() => PanelManager?.PopAll();
}
