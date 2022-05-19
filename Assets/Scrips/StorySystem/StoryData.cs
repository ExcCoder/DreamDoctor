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
        string[] TalkContent = new string[7];
        TalkContent[0] = "��~";
        TalkContent[1] = "��Ȼ�ò�����Ū�����������ѯʦ��ְλ~";
        TalkContent[2] = "����������ѯ������������ʲô�����ţ�";
        TalkContent[3] = "����";
        TalkContent[4] = "�����ˣ�Ҫ������е�ù�����ҿ����������������������˯һ������";
        TalkContent[5] = "����û��˯һ��������˵����顣";
        TalkContent[6] = "���ҿ����칫���ﶼ��Щʲô��";
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", TalkContent));
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ��ʾ", "�����ﵽ������"));
        state = new StoryState(0, "��Ϧ����", "��", actionContent);
        states.Add(state);

        //1
        TalkContent = new string[4];

        actionContent = new Queue<StoryAction>();
        TalkContent[0] = "�룡��Ȼ�������֣�";
        TalkContent[1] = "��ϸһ��������̨��Ƭ��Ҳ̫���˰ɡ�";
        TalkContent[2] = "���ϹŶ�����������";
        //actionContent.Enqueue(new StoryAction("��Ƭ��", "���ų�Ƭ", "����1"));
        TalkContent[3] = "����";
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", TalkContent));
        //actionContent.Enqueue(new StoryAction("��Ϧ", "����", null));
        TalkContent = new string[2];
        TalkContent[0] = "��Ȼ�Ҳ�����Ƭ����";
        TalkContent[1] = "���Ƕ������˵�ʱ����һ����������";
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", TalkContent));
        TalkContent = new string[1];
        TalkContent[0] = "����";
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", TalkContent));
        TalkContent = new string[1];
        actionContent.Enqueue(new StoryAction("��Ƭ��", "���ų�Ƭ", null));

        TalkContent[0] = "�ܺ�";
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", TalkContent));
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ��ʾ", "��E�򿪳�Ƭ��"));

        actionContent.Enqueue(new StoryAction("��Ƭ��", "��������", null));
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ��ʾ", ""));

        state = new StoryState(1, "�鿴��Ƭ��-1", "��Ƭ��", actionContent);
        states.Add(state);
        //2
        TalkContent = new string[5];
        actionContent = new Queue<StoryAction>();
        TalkContent[0] = "�ޡ�����";
        TalkContent[1] = "�����ϵ��������ѵ��������ҵ���";
        TalkContent[2] = "������һ�������Լ����ĵ���ʵ�Ի����������������¡���׹���ξ����Խ��Ľᡣ";
        TalkContent[3] = "������";
        TalkContent[4] = "ԭ���Ƿ�ֽ��";
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", TalkContent));
        TalkContent = new string[] { "�� ��~" };
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի���", TalkContent));
        actionContent.Enqueue(new StoryAction("��̽", "��̽����", null));

        state = new StoryState(2, "�鿴ֽ��", "ֽ��", actionContent);
        states.Add(state);
        //3

        actionContent = new Queue<StoryAction>();
        // actionContent.Enqueue(new StoryAction("��̽", "��̽����", null));
        TalkContent = new string[]
        { "��̽��\n����",
            "��̽��\n������������ѯ������",
            "��Ϧ��\n��������û��" ,
            "��Ϧ��\nҽ��������Ҫ��İ�����",
            "��̽��\n�������ġ�",
        };
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", TalkContent));

        actionContent.Enqueue(new StoryAction("��̽", "�ߵ���Ƭ����", null));
        TalkContent = new string[] { "��Ƭ����������" };
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", TalkContent));
        TalkContent = new string[]
        {
            "��̽�����ĳ�Ƭ����ô�ˡ�",
            "��Ϧ�����õ��ģ������㶨����"
        };
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", TalkContent));
        TalkContent = new string[]
        {
            ".... ...",
            "��Ƭ������һ�������󣬼�����ת��",
            "��Ϧ�����õ��ģ������㶨����"
        };
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի���", TalkContent));
        TalkContent = new string[] { "...." };
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", TalkContent));
        actionContent.Enqueue(new StoryAction("��Ƭ��", "���ų�Ƭ", null));
        TalkContent = new string[] { "����" };
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", TalkContent));
        TalkContent = new string[]
        {
        "��Ϧ���Թ���������λ���ˣ���״̬�ܲ��",
        "��̽���š�",
        "��Ϧ���������ģ�����һ�����԰���ķ�����",
        "��̽������������Ҫ����˵�ҵ������",
        "��Ϧ������",
        "��Ϧ�����������ҽ����������ŵ���һ�̣���������������������Ҫʲô��",
        "��̽��ԭ����������",
        "��Ϧ����������"
        };
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", TalkContent));
        actionContent.Enqueue(new StoryAction("��̽", "����ɳ����", null));
        TalkContent = new string[]
        {
        "��Ϧ���������߷���������ƣ������������������ҹ����",
        "��̽������",
        "��Ϧ��ͻȻ������һ������Ĵ�����������ȥ��",
        "��̽������",
        "��Ϧ�������ң���������������",
        "��̽����",
        "��Ϧ�������������������ڣ���о���Σ�",
        "��̽��zzz",
        "��Ϧ������",
        "��Ϧ���������ĵ��°��"
        };
        actionContent.Enqueue(new StoryAction("�Ի���", "��ʾ�Ի�", TalkContent));
        actionContent.Enqueue(new StoryAction("����","�ξ�",null));
        state = new StoryState(3, "��̽����", "��̽", actionContent);
        states.Add(state);
        //4
        actionContent = new Queue<StoryAction>();
        actionContent.Enqueue(new StoryAction("��̽", "��Խ�ξ�", null));
        state = new StoryState(4, "�ξ�Level1", "��̽", actionContent);
        states.Add(state);
        return states;
    }

    public List<(StoryState, StoryState)> GetEdgesList()
    {
        transitions = new List<(StoryState, StoryState)>();
        transitions.Add((states[0], states[1]));
        transitions.Add((states[0], states[2]));
        transitions.Add((states[2], states[3]));
        transitions.Add((states[3], states[4]));
        return transitions;
    }
}
