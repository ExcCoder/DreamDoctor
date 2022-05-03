using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    Stack<string> Saycontent;
    public Text Say;
    /// <summary>
    /// �Ի������ʾ
    /// </summary>
    public GameObject fa;
    /// <summary>
    /// ����ʱ����
    /// </summary>
    public float charsPerSecond = 0.2f;
    /// <summary>
    /// ������Ҫ��ʾ������
    /// </summary>
    private string words;
    /// <summary>
    /// ��ʼ��ӡ����
    /// </summary>
    private bool isActive = false;
    private float timer;//��ʱ��
    private int currentPos = 0;//��ǰ����λ��
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

    // Update is called once per frame
    void Update()
    {
        ShowDialogue();
        OnStartWriter();
    }
    /// <summary>
    /// ��ʾ�Ի�
    /// </summary>
    public void ShowDialogue()
    {
        //����E��ʼ�Ի�
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
    /// Ϊջ����ı�����
    /// </summary>
    public void sayHello()
    {
        Saycontent.Push("B:\n���daslkdhnashdlahd");
        Saycontent.Push("A:\n��ð�");
        Saycontent.Push("C:\n��ӭ����");

    }
    /// <summary>
    /// ִ�д�������
    /// </summary>
    void OnStartWriter()
    {

        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer >= charsPerSecond)
            {//�жϼ�ʱ��ʱ���Ƿ񵽴�
                timer = 0;
                currentPos++;
                if (words !=null)
                {
                    Say.text = words.Substring(0, currentPos);//ˢ���ı���ʾ����

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
    /// �������֣���ʼ������
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
