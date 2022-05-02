using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    Stack<string> Saycontent;
    public Text Say;
    public GameObject fa;
    public float charsPerSecond = 0.2f;//����ʱ����
    private string words;//������Ҫ��ʾ������

    private bool isActive = false;
    private float timer;//��ʱ��
    private int currentPos = 0;//��ǰ����λ��
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
    /// ��ʾ�Ի�
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
                Say.text = words.Substring(0, currentPos);//ˢ���ı���ʾ����

                if (currentPos >= words.Length)
                {
                    OnFinish();
                }
            }

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
