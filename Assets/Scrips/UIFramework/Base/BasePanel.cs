using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������ĸ��࣬����UI������Ϣ
/// </summary>
public class BasePanel
{
    /// <summary>
    /// UI��Ϣ
    /// </summary>
    public UIType UIType { get; private set; }
    /// <summary>
    /// UI������
    /// </summary>
    public UITool UITool { get; private set; }
    /// <summary>
    /// ��������
    /// </summary>
    public PanelManager PanelManager { get; private set; }
    /// <summary>
    /// UI������
    /// </summary>
    public UIManager UIManager { get; private set; }
    public BasePanel(UIType uIType)
    {
        UIType = uIType;
    }
    /// <summary>
    /// ��ʼ��UITool
    /// </summary>
    /// <param name="tool"></param>
    public void Intialize(UITool tool)
    {
        UITool = tool;
    }
    /// <summary>
    /// ��ʼ����������
    /// </summary>
    /// <param name="panelManager"></param>
    public void Intialize(PanelManager panelManager)
    {
        PanelManager = panelManager;
    }
    /// <summary>
    /// ��ʼ��UI������
    /// </summary>
    /// <param name="uIManager"></param>
    public void Intialize(UIManager uIManager)
    {
        UIManager = uIManager;
    }
    /// <summary>
    /// ����UIʱִ�У�ֻ��ִ��һ��
    /// </summary>
    public virtual void OnEnter() { }
    /// <summary>
    /// UI��ͣʱִ��
    /// </summary>
    public virtual void OnPause()
    {
        UITool.GetOrAddComponent<CanvasGroup>().blocksRaycasts = false;
    }
    /// <summary>
    /// UI����ִ��ʱ
    /// </summary>
    public virtual void OnResume()
    {
        UITool.GetOrAddComponent<CanvasGroup>().blocksRaycasts = true;
    }
    /// <summary>
    /// UI�˳�ʱִ��
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
