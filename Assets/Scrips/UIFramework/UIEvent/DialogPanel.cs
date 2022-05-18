using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogPanel : MonoBehaviour
{
    private static Queue<string> saycontent = new Queue<string>();
    public Text text;
    private GameObject BG;
    private string[] GetContent;
    private float charsPerSecond = 0.2f;
    private float timer;//计时器
    private bool isActive; //是否开启打字
    private bool isPush; //是否可以文字交互
    private int currentPos = 0;//当前打字位置
    private string sentence;
    private string selfName = "对话框";


    public static Queue<string> Saycontent { get => saycontent; set => saycontent = value; }

    void Start()
    {
        BG = GameObject.Find("TalkBG");
        BG.gameObject.SetActive(false);
        timer = 0;
        isActive = false;
        isPush = false;
        charsPerSecond = Mathf.Max(0.2f, charsPerSecond);
        //给unityEvent添加了一个方法 action
        GameRoot.Instance.StoryManager.ActionStart.AddListener
            (action =>
            {
                if(action.targetName.Equals(selfName))
                    ExecuteAction(action);
            });
    }
    public void ExecuteAction(StoryAction action)
    {
        switch (action.actionName)
        {
            case "显示对话":
                Debug.Log(action.actionName);
                GetContent = action.info as string[];
                for (int i = 0; i < GetContent.Length; i++)
                {
                    Saycontent.Enqueue(GetContent[i]);
                }
                isPush = true;
                break;
        }
    }
    void ShowDialog()
    {
        timer = 0;
        currentPos = 0;
        Debug.Log("栈存储的数量" + Saycontent.Count);
        //栈为空时退出对话并且继续游戏
        if (Saycontent.Count == 0)
        {
            Debug.Log("空");
            BG.gameObject.SetActive(false);
            Time.timeScale = 1;
            isPush = false;
            GameRoot.Instance.StoryManager.EndAction();
        }
        else
        {
            BG.gameObject.SetActive(true);
            Time.timeScale = 0;
            sentence = Saycontent.Dequeue();
            isActive = true;
        }
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
                if (currentPos >= sentence.Length)
                {
                    OnFinish();
                }
                else
                {

                    text.text = sentence.Substring(0, currentPos);//刷新文本显示内容
                    BG.gameObject.SetActive(true);
                }
            }
        }
    }
    private void FixedUpdate()
    {
        
    }
    private void Update()
    {

        if (isPush == true&&Input.GetKeyDown(KeyCode.E))
        {
            ShowDialog();
        }
        OnStartWriter();
    }

    /// <summary>
    /// 结束打字，初始化数据
    /// </summary>
    void OnFinish()
    {
        Debug.Log("结束打字");
        isActive = false;
        text.text = sentence;
    }
}