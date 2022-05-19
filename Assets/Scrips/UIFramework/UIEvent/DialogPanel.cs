using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogPanel : MonoBehaviour
{
    public static DialogPanel dialog;
    private static Queue<string> saycontent = new Queue<string>();
    public Text text;
    public GameObject BG;
    public Text  Hint;
    private string[] GetContent = null;
    private float charsPerSecond = 0.2f;
    private float timer;//��ʱ��
    private bool isActive; //�Ƿ�������
    private bool isPush; //�Ƿ�������ֽ���
    private int currentPos = 0;//��ǰ����λ��
    private string sentence;
    private string selfName = "�Ի���";
    bool isAuto = false;
    bool isAuto2 = false;

    private void Awake()
    {
        dialog = this;
    }

    public static Queue<string> Saycontent { get => saycontent; set => saycontent = value; }

    void Start()
    {
        BG.gameObject.SetActive(false);
        timer = 0;
        isActive = false;
        isPush = false;
        charsPerSecond = Mathf.Max(0.2f, charsPerSecond);
        //��unityEvent�����һ������ action
        GameRoot.Instance.StoryManager.ActionStart.AddListener
            (action =>
            {
                if (action.targetName.Equals(selfName))
                {
                    ExecuteAction(action);

                }
            });
    }
    public void ExecuteAction(StoryAction action)
    {
        switch (action.actionName)
        {
            case "��ʾ�Ի�":
                //Debug.Log(action.actionName);
                GetContent = action.info as string[];
                for (int i = 0; i < GetContent.Length; i++)
                {
                    Saycontent.Enqueue(GetContent[i]);
                }
                isPush = true;
                break;
            case "��ʾ��ʾ":
                Hint.gameObject.SetActive(true);
                Hint.text = action.info as string;
                College2DReturn.isPush = true;
                GameRoot.Instance.StoryManager.Process(StoryManager.curState.trigger_id);
                break;

        }
    }
   public void ShowDialog()
    {
        timer = 0;
        currentPos = 0;
       // Debug.Log("ջ�洢������" + Saycontent.Count);
        //ջΪ��ʱ�˳��Ի����Ҽ�����Ϸ
        if (Saycontent.Count == 0)
        {
            College2DReturn.isPush = true;
            Debug.Log("��");
            Time.timeScale = 1;
            BG.gameObject.SetActive(false);
            isPush = false;
            
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
    private void Update()
    {

        if (isPush == true && Input.GetKeyDown(KeyCode.E))
        {
            ShowDialog();
        }
        OnStartWriter();
    }

    /// <summary>
    /// �������֣���ʼ������
    /// </summary>
    void OnFinish()
    {
        //Debug.Log("��������");
        isActive = false;
        text.text = sentence;
    }
}