using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 挂载到角色身上，用于识别标签
/// </summary>
public class Dialogue : MonoBehaviour
{
    Stack<string> Saycontent;
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
        fa.SetActive(false);
        timer = 0;
        isActive = false;
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
            //
            ShowDialogue();
            //是否填充
            if (College2DReturn.isPush)
            {
                if (College2DReturn.Interact != null)
                {
                    switch (College2DReturn.Interact.name)
                    {
                        case "唱片机":
                            SayBagin();
                            break;
                    }

                }
            }
        }
        else
        {

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
            
            Debug.Log(Saycontent.Count);
            timer = 0;
            currentPos = 0;
            if (Saycontent.Count == 0)
            {
                isActive = false;
                fa.SetActive(false);

            }
            else
            {
                words = Saycontent.Pop();
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
            timer += Time.deltaTime;
            if (timer >= charsPerSecond)
            {//判断计时器时间是否到达
                timer = 0;
                currentPos++;
                if (words != null)
                {
                    Say.text = words.Substring(0, currentPos);//刷新文本显示内容

                }
                if (currentPos >= words.Length)
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
        Debug.Log(123);
        isActive = false;
        timer = 0;
        currentPos = 0;
        Say.text = words;
    }
}
