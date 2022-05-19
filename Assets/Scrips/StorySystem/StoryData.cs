using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryData
{
    private List<StoryState> states = new List<StoryState>();        //状态
    private List<(StoryState, StoryState)> transitions = new List<(StoryState, StoryState)>();

    public List<StoryState> GetStatesList()
    {
        StoryState state;
        Queue<StoryAction> actionContent;
        //------------------------------------------
        //0
        actionContent = new Queue<StoryAction>();
        string[] TalkContent = new string[7];
        TalkContent[0] = "呼~";
        TalkContent[1] = "虽然好不容易弄到这个心理咨询师的职位~";
        TalkContent[2] = "不过心理咨询……到底是做什么的来着？";
        TalkContent[3] = "……";
        TalkContent[4] = "不管了，要是真的有倒霉蛋不幸跨入了这个诊所，就让他们睡一觉好了";
        TalkContent[5] = "世上没有睡一觉解决不了的事情。";
        TalkContent[6] = "让我看看办公室里都有些什么。";
        actionContent.Enqueue(new StoryAction("对话框", "显示对话", TalkContent));
        actionContent.Enqueue(new StoryAction("对话框", "显示提示", "在屋里到处走走"));
        state = new StoryState(0, "林夕进门", "门", actionContent);
        states.Add(state);

        //1
        TalkContent = new string[4];

        actionContent = new Queue<StoryAction>();
        TalkContent[0] = "嚯！竟然还有音乐！";
        TalkContent[1] = "仔细一看……这台唱片机也太旧了吧。";
        TalkContent[2] = "这老古董还能运作吗？";
        //actionContent.Enqueue(new StoryAction("唱片机", "播放唱片", "歌曲1"));
        TalkContent[3] = "……";
        actionContent.Enqueue(new StoryAction("对话框", "显示对话", TalkContent));
        //actionContent.Enqueue(new StoryAction("林夕", "抽烟", null));
        TalkContent = new string[2];
        TalkContent[0] = "虽然我不懂唱片机，";
        TalkContent[1] = "但是东西坏了的时候，我一般这样做。";
        actionContent.Enqueue(new StoryAction("对话框", "显示对话", TalkContent));
        TalkContent = new string[1];
        TalkContent[0] = "抖动";
        actionContent.Enqueue(new StoryAction("对话框", "显示对话", TalkContent));
        TalkContent = new string[1];
        actionContent.Enqueue(new StoryAction("唱片机", "播放唱片", null));

        TalkContent[0] = "很好";
        actionContent.Enqueue(new StoryAction("对话框", "显示对话", TalkContent));
        actionContent.Enqueue(new StoryAction("对话框", "显示提示", "按E打开唱片机"));

        actionContent.Enqueue(new StoryAction("唱片机", "交互解锁", null));
        actionContent.Enqueue(new StoryAction("对话框", "显示提示", ""));

        state = new StoryState(1, "查看唱片机-1", "唱片机", actionContent);
        states.Add(state);
        //2
        TalkContent = new string[5];
        actionContent = new Queue<StoryAction>();
        TalkContent[0] = "噢……？";
        TalkContent[1] = "这桌上的字条，难道是留给我的吗？";
        TalkContent[2] = "“梦是一个人与自己内心的真实对话。”——弗洛伊德。请坠入梦境，以解心结。";
        TalkContent[3] = "……？";
        TalkContent[4] = "原来是废纸。";
        actionContent.Enqueue(new StoryAction("对话框", "显示对话", TalkContent));
        TalkContent = new string[] { "叮 咚~" };
        actionContent.Enqueue(new StoryAction("对话框", "显示对话框", TalkContent));
        actionContent.Enqueue(new StoryAction("侦探", "侦探进门", null));

        state = new StoryState(2, "查看纸条", "纸条", actionContent);
        states.Add(state);
        //3

        actionContent = new Queue<StoryAction>();
        // actionContent.Enqueue(new StoryAction("侦探", "侦探出现", null));
        TalkContent = new string[]
        { "侦探：\n您好",
            "侦探：\n这里是心理咨询诊所吗？",
            "林夕：\n呃…啊，没错" ,
            "林夕：\n医生，我需要你的帮助。",
            "侦探：\n是这样的…",
        };
        actionContent.Enqueue(new StoryAction("对话框", "显示对话", TalkContent));

        actionContent.Enqueue(new StoryAction("侦探", "走到唱片机旁", null));
        TalkContent = new string[] { "唱片机发出噪音" };
        actionContent.Enqueue(new StoryAction("对话框", "显示对话", TalkContent));
        TalkContent = new string[]
        {
            "侦探：您的唱片机怎么了。",
            "林夕：不用担心，我来搞定它。"
        };
        actionContent.Enqueue(new StoryAction("对话框", "显示对话", TalkContent));
        TalkContent = new string[]
        {
            ".... ...",
            "唱片机发出一阵噪音后，继续运转。",
            "林夕：不用担心，我来搞定它。"
        };
        actionContent.Enqueue(new StoryAction("对话框", "显示对话框", TalkContent));
        TalkContent = new string[] { "...." };
        actionContent.Enqueue(new StoryAction("对话框", "显示对话", TalkContent));
        actionContent.Enqueue(new StoryAction("唱片机", "播放唱片", null));
        TalkContent = new string[] { "好了" };
        actionContent.Enqueue(new StoryAction("对话框", "显示对话", TalkContent));
        TalkContent = new string[]
        {
        "林夕：言归正传，这位病人，你状态很差啊。",
        "侦探：嗯…",
        "林夕：是这样的，我有一个百试百灵的方法。",
        "侦探：…您…不需要听我说我的情况吗？",
        "林夕：……",
        "林夕：资深的心理医生，在你进门的那一刻，往往就立刻明白了你需要什么。",
        "侦探：原来是这样吗",
        "林夕：来，躺下"
        };
        actionContent.Enqueue(new StoryAction("对话框", "显示对话", TalkContent));
        actionContent.Enqueue(new StoryAction("侦探", "坐在沙发上", null));
        TalkContent = new string[]
        {
        "林夕：三部催眠法…想象你疲惫不堪，走了三天三夜……",
        "侦探：……",
        "林夕：突然看到了一张柔软的床，你躺了上去…",
        "侦探：床…",
        "林夕：跟着我，吸气——呼气—",
        "侦探：…",
        "林夕：吸气——呼——现在，你感觉如何？",
        "侦探：zzz",
        "林夕：啊哈",
        "林夕：就这样耗到下班吧"
        };
        actionContent.Enqueue(new StoryAction("对话框", "显示对话", TalkContent));
        actionContent.Enqueue(new StoryAction("场景","梦境",null));
        state = new StoryState(3, "侦探入门", "侦探", actionContent);
        states.Add(state);
        //4
        actionContent = new Queue<StoryAction>();
        actionContent.Enqueue(new StoryAction("侦探", "穿越梦境", null));
        state = new StoryState(4, "梦境Level1", "侦探", actionContent);
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
