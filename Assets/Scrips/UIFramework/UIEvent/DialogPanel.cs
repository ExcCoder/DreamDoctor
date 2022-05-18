using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogPanel : MonoBehaviour
{
    private static Queue<string> saycontent = new Queue<string>();
    public Text text;
    private GameObject BG;
    private float charsPerSecond = 0.2f;
    private float timer;//��ʱ��
    private bool isActive; //�Ƿ�������
    private int currentPos = 0;//��ǰ����λ��
    private string sentence;

    public static Queue<string> Saycontent { get => saycontent; set => saycontent = value; }

    void Start()
    {
        BG = GameObject.Find("TalkBG");
        BG.gameObject.SetActive(false);
        timer = 0;
        isActive = true;
        charsPerSecond = Mathf.Max(0.2f, charsPerSecond);
        //��unityEvent�����һ������ action
        GameRoot.Instance.StoryManager.ActionStart.AddListener
            (action => {
                ExecuteAction(action);
            });
    }
    public void ExecuteAction(StoryAction action)
    {
        switch (action.actionName)
        {
            case "��ʾ�Ի�":
                Debug.Log(action.actionName);
                ShowDialog(action.info as string[]);
                break;
        }
    }

    void ShowDialog(string[] msg)
    {
        timer = 0;
        currentPos = 0;

        Debug.Log(msg[0]);
        for (int i = 0; i < msg.Length; i++)
        {
            Saycontent.Enqueue(msg[i]);
        }
        

        Debug.Log("ջ�洢������" + Saycontent.Count);
        //ջΪ��ʱ�˳��Ի����Ҽ�����Ϸ
        if (Saycontent.Count == 0)
        {
            Debug.Log("��");
            isActive = false;
            BG.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            BG.gameObject.SetActive(true);
            Time.timeScale = 0;
            sentence = Saycontent.Dequeue();
            isActive = true;
        }
        OnStartWriter();
    }

    /// <summary>
    /// ִ�д�������
    /// </summary>
    void OnStartWriter()
    {
        if (isActive)
        {
            timer += Time.unscaledTime;
            if (timer >= charsPerSecond)
            {//�жϼ�ʱ��ʱ���Ƿ񵽴�
                timer = 0;
                currentPos++;
                if (currentPos >= sentence.Length)
                {
                    OnFinish();
                }
                else
                {

                    text.text = sentence.Substring(0, currentPos);//ˢ���ı���ʾ����
                    BG.gameObject.SetActive(true);
                }
            }
        }
    }
    /// <summary>
    /// �������֣���ʼ������
    /// </summary>
    void OnFinish()
    {
        Debug.Log("��������");
        isActive = false;
        text.text = sentence;
    }
}