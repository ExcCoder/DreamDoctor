using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �������������ջ����UI
/// </summary>
public class PanelManager
{
    /// <summary>
    /// �洢UI����ջ
    /// </summary>
    Stack<BasePanel> stackPanel;
    BasePanel panel;
    /// <summary>
    /// UI������
    /// </summary>
    UIManager uIManger;
    public PanelManager()
    {
        stackPanel = new Stack<BasePanel>();
        uIManger = new UIManager();
    }
    /// <summary>
    /// UI����ջ��������ʾһ�����
    /// </summary>
    /// <param name="nextPanel">Ҫ��ʾ�����</param>
    public void Push(BasePanel nextPanel)
    {
        if (stackPanel.Count > 0)
        {
            //��ջ����ȡ���
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
    /// ִ�����ĳ�ջ�������˲�����ִ������OnExit����
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
    /// ִ����������OnExit
    /// </summary>
    public void PopAll()
    {
        while (stackPanel.Count>0)
        {
            stackPanel.Pop().OnExit();
        }
    }


}
