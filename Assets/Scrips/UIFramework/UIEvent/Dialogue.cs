using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ���ص���ɫ���ϣ�����ʶ���ǩ
/// </summary>
public class Dialogue : MonoBehaviour
{
    Stack<string> Saycontent;
    /// <summary>
    /// �Ի����ı���
    /// </summary>
    public Text Say;
    /// <summary>
    /// �Ի������ʾ
    /// </summary>
    public GameObject fa;
    /// <summary>
    /// �ɽ�������Ʒ
    /// </summary>
    private GameObject Interact;
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
    /// <summary>
    /// �Ƿ���Խ���
    /// </summary>
    private bool isInteract = false;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //�����ǩΪ�ɽ����򴥷�
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
        //�Ƿ���Խ���
        if (College2DReturn.isInteract)
        {
            //
            ShowDialogue();
            //�Ƿ����
            if (College2DReturn.isPush)
            {
                if (College2DReturn.Interact != null)
                {
                    switch (College2DReturn.Interact.name)
                    {
                        case "��Ƭ��":
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
    public void SayBagin()
    {
        Saycontent.Push("��Ϧ��\n�ⶫ���о�����ͷȮ��Ҫ������ǲ�Ҫ�������ȽϺá�");

        Saycontent.Push("��Ϧ��\n������һﶼ����Щʲô������");

        Saycontent.Push("��Ϧ��ǰ�߶����ؿ�1������֡�");
        Saycontent.Push("��Ϧ:\n�����ǣ��ղ������Ǽһ���ξ���");
        Saycontent.Push("��Ϧ:\n����������Ц�İɡ��ѵ��칫���ϵ���������ġ�");
        Saycontent.Push("��Ϧ:\nҲ�ǣ���ȫû�ڹ���������ô��Ӱ�����ء�");
        Saycontent.Push("��Ϧ:\n��ͷȮ��û�У����ǵ�����");
        Saycontent.Push("��Ϧ���ҿ�����");
        Saycontent.Push("��Ϧ:\n����ҽ�������ڼӰ��������ѳְ����");
        Saycontent.Push("��Ϧ:\n�����ģ�������");
        Saycontent.Push("��ϦĿ�ɿڴ���");
        Saycontent.Push("��Ϧ:\n�������G����");
        Saycontent.Push("��Ϧ�̵ֻ������ξ��С��������ڹؿ�1��ڴ���");

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
                if (words != null)
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
