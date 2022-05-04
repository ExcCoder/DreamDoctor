using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 挂载到角色身上，用于识别标签
/// </summary>
public class Dialogue : MonoBehaviour
{
    public static Stack<string> Saycontent;
    int MusicCount = 0;
    /// <summary>
    /// 对话的文本框
    /// </summary>
    Text Say;
    /// <summary>
    /// 对话框的显示
    /// </summary>
    public GameObject fa;
    /// <summary>
    /// 可交互的物品
    /// </summary>
    private GameObject Interact;
    /// <summary>
    /// 打字时间间隔
    /// </summary>
    public float charsPerSecond = 0.2f;
    /// <summary>
    /// 保存需要显示的文字
    /// </summary>
    private string words;
    private string words2 = "";
    /// <summary>
    /// 开始打印文字
    /// </summary>
    private bool isActive = false;
    /// <summary>
    /// 是否可以交互
    /// </summary>
    private bool isInteract = false;
    private float timer;//计时器
    private int currentPos = 0;//当前打字位置
    private void Awake()
    {
        Saycontent = new Stack<string>();
    }
    void Start()
    {
        //fa = GameObject.Find("TalkBG");
        Say = fa.transform.GetChild(0).GetComponent<Text>();
        fa.SetActive(false);
        timer = 0;
        isActive = true;
        charsPerSecond = Mathf.Max(0.2f, charsPerSecond);

    }
    void Update()
    {
        //是否可以交互
        if (College2DReturn.Interact)
        {
            ShowDialogue();
        }

        OnStartWriter();

    }
    /// <summary>
    /// 显示对话
    /// </summary>
    public void ShowDialogue()
    {


        //按下E后开始对话
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (College2DReturn.isPush)
            {
                if (College2DReturn.Interact.name == "唱片机")
                {
                    MusicFrist1();
                    College2DReturn.isPush = false;

                }
                else if (College2DReturn.Interact.name == "放大镜")
                {
                    zoomEvent();
                    College2DReturn.isPush = false;
                }
                else if (College2DReturn.Interact.name == "电脑桌")
                {
                    SayPaper();
                    College2DReturn.isPush = false;
                }
                else if (College2DReturn.Interact.name =="手电筒" )
                {
                    HandLigh();
                    College2DReturn.isPush = false;
                }
                Debug.Log("填装完毕");
                College2DReturn.isPush = false;
            }
            Debug.Log("栈存储的数量" + Saycontent.Count);
            timer = 0;
            currentPos = 0;
            //栈为空时退出对话并且继续游戏
            if (Saycontent.Count == 0)
            {
                isActive = false;
                fa.SetActive(false);
                Time.timeScale = 1;


            }
            else
            {
                Time.timeScale = 0;
                words = Saycontent.Pop();
                words2 = words;
                isActive = true;

            }
        }
    }

    /// <summary>
    /// 为栈添加文本内容
    /// </summary>
    public void SayPaper()
    {
        Saycontent.Push("林夕：原来是废纸。");
        Saycontent.Push("林夕：……？");
        Saycontent.Push("林夕：“梦是一个人与自己内心的真实对话。”——弗洛伊德。请坠入梦境，以解心结。");
        Saycontent.Push("林夕：这桌上的字条，难道是留给我的吗？");
        Saycontent.Push("林夕：噢……？");

    }
    /// <summary>
    /// 执行打字任务
    /// </summary>
    void OnStartWriter()
    {

        if (isActive)
        {
            timer += Time.unscaledTime;
            if (timer >= charsPerSecond)
            {//判断计时器时间是否到达
                timer = 0;
                currentPos++;
                if (currentPos >= words2.Length)
                {
                    OnFinish();
                }
                else
                {

                    Say.text = words.Substring(0, currentPos);//刷新文本显示内容
                    fa.SetActive(true);
                }
            }

        }
    }
    /// <summary>
    /// 结束打字，初始化数据
    /// </summary>
    void OnFinish()
    {
        Debug.Log(123);
        isActive = false;
        timer = 0;
        currentPos = 0;
        Say.text = words;

    }
    void MusicFrist1()
    {
        Saycontent.Push("林夕：这老古董还能运作吗？");
        Saycontent.Push("林夕：仔细一看……这台唱片机也太旧了吧。");
        Saycontent.Push("林夕：嚯！竟然还有音乐！");
    }
    void MusicFrist2()
    {
        Saycontent.Push("△林夕给了唱片机一拳。");
        Saycontent.Push("林夕：但是东西坏了的时候，我一般这样做。");
        Saycontent.Push("林夕：虽然我不懂唱片机");
        Saycontent.Push("播放了5-6秒后，唱片机发出噪音，罢工了。");

    }

    void SayForClient1()
    {
        Saycontent.Push("林夕：不用担心，我来搞定它。");
        Saycontent.Push("侦探：您的唱片机怎么了。");
        Saycontent.Push("唱片机发出一阵噪音后，又停了。两人转头看向唱片机。");
        Saycontent.Push("侦探：是这样的…");
        Saycontent.Push("侦探：医生，我需要你的帮助。");
        Saycontent.Push("林夕：呃…啊，没错。");
        Saycontent.Push("侦探：这里是心理咨询诊所吗？");
        Saycontent.Push("侦探：您好。");
        Saycontent.Push("门口响起敲门声【敲门声】，侦探从门口出现。");
    }
    void SayForClient2()
    {
        //Saycontent.Push("△林夕走到沙发的一边。");
        Saycontent.Push("侦探：原来是这样吗。");
        Saycontent.Push("林夕：资深的心理医生，在你进门的那一刻，往往就立刻明白了你需要什么。");
        Saycontent.Push("林夕：……");
        Saycontent.Push("侦探：…您…不需要听我说我的情况吗？");
        Saycontent.Push("林夕：是这样的，我有一个百试百灵的方法。");
        Saycontent.Push("侦探：嗯…");
        Saycontent.Push("林夕：言归正传，这位病人，你状态很差啊。");
        Saycontent.Push("林夕：好了。");
    }
    void SayForClient3()
    {
        //Saycontent.Push("△林夕走到沙发前（沙发中间）。");
        Saycontent.Push("侦探：zzz");
        Saycontent.Push("侦探：zzz");
        Saycontent.Push("侦探：zzz");
        Saycontent.Push("林夕：啊哈。");

        Saycontent.Push("侦探：zzz");
        Saycontent.Push("林夕：吸气——呼——现在，你感觉如何？");
        Saycontent.Push("侦探：……");

        Saycontent.Push("林夕：跟着我，吸气——呼气——");
        Saycontent.Push("侦探：床……");
        Saycontent.Push("林夕：突然看到了一张柔软的床，你躺了上去……");
        Saycontent.Push("侦探：……");
        Saycontent.Push("林夕：三部催眠法…想象你疲惫不堪，走了三天三夜……");
        Saycontent.Push("△侦探来到沙发上躺下，闭眼。");
        Saycontent.Push("侦探：……");
        Saycontent.Push("林夕：来，躺下。");
    }
    void SayForClient4()
    {
        Saycontent.Push("林夕：！？");
        Saycontent.Push("△突然一阵光芒出现（或者关卡传送门出现），林夕惊恐。（美术爸爸）");
        Saycontent.Push("林夕：就这样耗到下班吧。");
        Saycontent.Push("林夕：这可是货真价实的催眠治疗大套餐。");
    }
    /// <summary>
    /// 第一次卷入梦境
    /// </summary>
    void SayPart1_1()
    {

        Saycontent.Push("林夕：\n这东西感觉比三头犬还要不妙，还是不要打扰它比较好。");

        Saycontent.Push("林夕：\n呃，这家伙都在梦些什么啊……");

        Saycontent.Push("林夕向前走动，关卡1怪物出现。");
        Saycontent.Push("林夕:\n这里是，刚才躺着那家伙的梦境？");
        Saycontent.Push("林夕:\n不过，开玩笑的吧…难道办公桌上的字条是真的。");
        Saycontent.Push("林夕:\n也是，完全没在工作的人怎么会加班猝死呢。");
        Saycontent.Push("林夕:\n三头犬都没有，不是地狱啊");
        Saycontent.Push("林夕左右看看。");
        Saycontent.Push("林夕:\n…林医生，终于加班过度以身殉职了吗。");
        Saycontent.Push("林夕:\n这是哪？地狱？");
        Saycontent.Push("林夕目瞪口呆。");
        Saycontent.Push("林夕:\n？？？欸？？");
        Saycontent.Push("林夕仓惶跌落至梦境中。（出现在关卡1入口处）");

    }
    void zoomEvent()
    {
        Saycontent.Push("镌了精致纹路的金色放大镜，柄上有些磨损的痕迹，看起来经常被使用。");
    }
    void HandLigh()
    {
        Saycontent.Push("一个手电筒。这不会也是怪物吧……");
    }
}
