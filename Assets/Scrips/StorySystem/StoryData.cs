using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryData
{
    private List<StoryState> states = new List<StoryState>();        //״̬
    private List<(StoryState, StoryState)> transitions = new List<(StoryState, StoryState)>();

    public List<StoryState> GetStatesList()
    {
        StoryState state;
        Queue<StoryAction> actionContent;
        //------------------------------------------
        //0
        actionContent = new Queue<StoryAction>();
        string[] content = new string[7];
        content[0] = "��~";
        content[1] = "��Ȼ�ò�����Ū�����������ѯʦ��ְλ~";
        content[2] = "����������ѯ������������ʲô�����ţ�";
        content[3] = "����";
        content[4] = "�����ˣ�Ҫ������е�ù�����ҿ����������������������˯һ������";
        content[5] = "����û��˯һ��������˵����顣";
        content[6] = "���ҿ����칫���ﶼ��Щʲô��";
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", content));
        state = new StoryState(0,"��Ϧ����","��",actionContent);
        states.Add(state);
        
        //1
        actionContent = new Queue<StoryAction>();
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", "�ޡ�����"));
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", "�����ϵ��������ѵ��������ҵ���"));
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", "������һ�������Լ����ĵ���ʵ�Ի����������������¡���׹���ξ����Խ��Ľᡣ"));
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", "������"));
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", "ԭ���Ƿ�ֽ��"));
        state = new StoryState(1,"�鿴�칫��", "�칫��", actionContent);
        states.Add(state);
        //2
        actionContent = new Queue<StoryAction>();
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", "�룡��Ȼ�������֣�"));
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", "��ϸһ��������̨��Ƭ��Ҳ̫���˰ɡ�"));
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", "���ϹŶ�����������"));
        actionContent.Enqueue(new StoryAction("��Ƭ��", "���ų�Ƭ", "����1"));
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", "����"));
        actionContent.Enqueue(new StoryAction("��Ϧ", "����",null));
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", "��Ȼ�Ҳ�����Ƭ����"));
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", "���Ƕ������˵�ʱ����һ����������"));
        actionContent.Enqueue(new StoryAction("��Ƭ��", "���ų�Ƭ", "����"));
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", "�ܺ�"));
        state = new StoryState(2,"�鿴��Ƭ��-1", "��Ƭ��", actionContent);
        states.Add(state);

        actionContent = new Queue<StoryAction>();
        actionContent.Enqueue(new StoryAction("�Ի���","��ʾ�Ի�", "��Ϧ���ޡ�����"));
        actionContent.Enqueue(new StoryAction("�Ի���","��ʾ�Ի�", "��Ϧ�������ϵ��������ѵ��������ҵ���"));
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", "��Ϧ��������һ�������Լ����ĵ���ʵ�Ի����������������¡���׹���ξ����Խ��Ľᡣ"));
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", "��Ϧ������Ϧ��������"));
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", "��Ϧ������Ϧ��ԭ���Ƿ�ֽ��"));
        state = new StoryState(3,"�鿴ֽ��","ֽ��",actionContent);
        states.Add(state);

        return states;
    }

    public List<(StoryState,StoryState)> GetEdgesList()
    {
        transitions = new List<(StoryState, StoryState)>();
        transitions.Add((states[0], states[1]));
        transitions.Add((states[0], states[2]));
        return transitions;
    }
}
