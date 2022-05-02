using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    Stack<string> Saycontent;
    public Text Say;
    public GameObject fa;
    public float charsPerSecond = 0.2f;//打字时间间隔
    private string words;//保存需要显示的文字

    private bool isActive = false;
    private float timer;//计时器
    private int currentPos = 0;//当前打字位置
    private void Awake()
    {
        Saycontent = new Stack<string>();
    }
    void Start()
    {
        timer = 0;
        isActive = true;
        charsPerSecond = Mathf.Max(0.2f, charsPerSecond);

    }

    // Update is called once per frame
    void Update()
    {
        ShowDialogue();
        if (isActive && Saycontent.Count!=0)
        {
            OnStartWriter();
        }
    }
    /// <summary>
    /// 显示对话
    /// </summary>
    public void ShowDialogue()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(Saycontent.Count);
            if (Saycontent.Count == 0)
            {

                fa.SetActive(false);
                isActive = false;
            }
            else
            {
                words = Saycontent.Pop();
                isActive = true;
                fa.SetActive(true);
            }
        }
    }
    /// <summary>
    /// 为栈添加文本内容
    /// </summary>
    public void sayHello()
    {
        Saycontent.Push("B:\n你好daslkdhnashdlahd");
        Saycontent.Push("A:\n你好啊");
        Saycontent.Push("C:\n欢迎回来");

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
                Say.text = words.Substring(0, currentPos);//刷新文本显示内容

                if (currentPos >= words.Length)
                {
                    OnFinish();
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
}
