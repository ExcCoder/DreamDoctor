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
        actionContent.Enqueue(new StoryAction("林夕", "抽烟", null));
        TalkContent = new string[2];
        TalkContent[0] = "虽然我不懂唱片机，";
        TalkContent[1] = "但是东西坏了的时候，我一般这样做。";
        actionContent.Enqueue(new StoryAction("对话框", "显示对话", TalkContent));
        actionContent.Enqueue(new StoryAction("唱片机", "播放唱片", "抖动"));
        TalkContent = new string[1];
        TalkContent[0] = "很好";
        actionContent.Enqueue(new StoryAction("对话框", "显示对话", TalkContent));

        state = new StoryState(2, "查看唱片机-1", "唱片机", actionContent);
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
        state = new StoryState(3, "查看纸条", "纸条", actionContent);
        states.Add(state);
        return states;
    }

    public List<(StoryState, StoryState)> GetEdgesList()
    {
        transitions = new List<(StoryState, StoryState)>();
        transitions.Add((states[0], states[1]));
        transitions.Add((states[0], states[2]));
        return transitions;
    }
}
