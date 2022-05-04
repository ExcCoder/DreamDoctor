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
    /// <summary>
    /// 对话的文本框
    /// </summary>
    public Text Say;
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
    private string words2;
    /// <summary>
    /// 开始打印文字
    /// </summary>
    private bool isActive = false;
    /// <summary>
    /// 是否可以交互
    /// </summary>
    private bool isInteract = false;
    private bool isOver = true;
    private float timer;//计时器
    private int currentPos = 0;//当前打字位置
    private void Awake()
    {
        Saycontent = new Stack<string>();
    }
    void Start()
    {
        fa.SetActive(false);
        timer = 0;
        isActive = true;
        charsPerSecond = Mathf.Max(0.2f, charsPerSecond);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //如果标签为可交互则触发
        if (collision.tag == "Insteract")
        {
            Interact = collision.gameObject;
            Interact.transform.GetChild(0).gameObject.SetActive(true);

            isInteract = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Interact != null)
        {
            Interact.transform.GetChild(0).gameObject.SetActive(false);
            isInteract = false;

        }
    }
    // Update is called once per frame
    void Update()
    {
        //是否可以交互
        if (College2DReturn.isInteract)
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
            isOver = false;

            if (College2DReturn.isPush)
            {
                SayBagin();
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
            else if (!isOver)
            {
                words = Saycontent.Pop();
                words2 = words;
                isActive = true;

            }
        }
    }
    /// <summary>
    /// 为栈添加文本内容
    /// </summary>
    public void SayBagin()
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
                if (currentPos < words.Length)
                {
                    Say.text = words.Substring(0, currentPos);//刷新文本显示内容
                }
                else
                {
                    OnFinish();

                }
            }
            fa.SetActive(true);
        }
    }
    /// <summary>
    /// 结束打字，初始化数据
    /// </summary>
    void OnFinish()
    {
        isOver = true;
        Debug.Log(123);
        isActive = false;
        timer = 0;
        currentPos = 0;
        Say.text = words;

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
}
