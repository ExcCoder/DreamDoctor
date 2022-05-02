using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 界面管理器，用栈管理UI
/// </summary>
public class PanelManager
{
    /// <summary>
    /// 存储UI面板的栈
    /// </summary>
    Stack<BasePanel> stackPanel;
    BasePanel panel;
    /// <summary>
    /// UI管理器
    /// </summary>
    UIManager uIManger;
    public PanelManager()
    {
        stackPanel = new Stack<BasePanel>();
        uIManger = new UIManager();
    }
    /// <summary>
    /// UI的入栈操作，显示一个面板
    /// </summary>
    /// <param name="nextPanel">要显示的面板</param>
    public void Push(BasePanel nextPanel)
    {
        if (stackPanel.Count > 0)
        {
            //从栈顶获取面板
            panel = stackPanel.Peek();
            panel.OnPause();
        }
        stackPanel.Push(nextPanel);
        //PanelGo
        GameObject PanelGo = uIManger.GetSingleUI(nextPanel.UIType);
        nextPanel.Intialize(new UITool(PanelGo));
        nextPanel.Intialize(this);
        nextPanel.Intialize(uIManger);
        nextPanel.OnEnter();
    }
    /// <summary>
    /// 执行面板的出栈操作，此操作会执行面板的OnExit方法
    /// </summary>
    public void Pop()
    {
        if (stackPanel.Count > 0)
        {
            stackPanel.Peek().OnExit();
            stackPanel.Pop();

        }
        if (stackPanel.Count > 0)
        {
            stackPanel.Peek().OnResume();
        }
    }
    /// <summary>
    /// 执行所有面板的OnExit
    /// </summary>
    public void PopAll()
    {
        while (stackPanel.Count>0)
        {
            stackPanel.Pop().OnExit();
        }
    }


}
