using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ���ص���ɫ���ϣ�����ʶ���ǩ
/// </summary>
public class Dialogue : MonoBehaviour
{
    public static Stack<string> Saycontent;
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
    private string words2;
    /// <summary>
    /// ��ʼ��ӡ����
    /// </summary>
    private bool isActive = false;
    /// <summary>
    /// �Ƿ���Խ���
    /// </summary>
    private bool isInteract = false;
    private bool isOver = true;
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
        isActive = true;
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
            ShowDialogue();
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
            isOver = false;

            if (College2DReturn.isPush)
            {
                SayBagin();
                Debug.Log("��װ���");
                College2DReturn.isPush = false;
            }
            Debug.Log("ջ�洢������" + Saycontent.Count);
            timer = 0;
            currentPos = 0;
            //ջΪ��ʱ�˳��Ի����Ҽ�����Ϸ
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
            timer += Time.unscaledTime;
            if (timer >= charsPerSecond)
            {//�жϼ�ʱ��ʱ���Ƿ񵽴�
                timer = 0;
                currentPos++;
                if (currentPos < words.Length)
                {
                    Say.text = words.Substring(0, currentPos);//ˢ���ı���ʾ����
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
    /// �������֣���ʼ������
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
        Saycontent.Push("��Ϧ�����õ��ģ������㶨����");
        Saycontent.Push("��̽�����ĳ�Ƭ����ô�ˡ�");
        Saycontent.Push("��Ƭ������һ����������ͣ�ˡ�����תͷ����Ƭ����");
        Saycontent.Push("��̽���������ġ�");
        Saycontent.Push("��̽��ҽ��������Ҫ��İ�����");
        Saycontent.Push("��Ϧ����������û��");
        Saycontent.Push("��̽��������������ѯ������");
        Saycontent.Push("��̽�����á�");
        Saycontent.Push("�ſ�������������������������̽���ſڳ��֡�");
    }
    void SayForClient2()
    {
        //Saycontent.Push("����Ϧ�ߵ�ɳ����һ�ߡ�");
        Saycontent.Push("��̽��ԭ����������");
        Saycontent.Push("��Ϧ�����������ҽ����������ŵ���һ�̣���������������������Ҫʲô��");
        Saycontent.Push("��Ϧ������");
        Saycontent.Push("��̽������������Ҫ����˵�ҵ������");
        Saycontent.Push("��Ϧ���������ģ�����һ�����԰���ķ�����");
        Saycontent.Push("��̽���š�");
        Saycontent.Push("��Ϧ���Թ���������λ���ˣ���״̬�ܲ��");
        Saycontent.Push("��Ϧ�����ˡ�");
    }
    void SayForClient3()
    {
        //Saycontent.Push("����Ϧ�ߵ�ɳ��ǰ��ɳ���м䣩��");
        Saycontent.Push("��̽��zzz");
        Saycontent.Push("��̽��zzz");
        Saycontent.Push("��̽��zzz");
        Saycontent.Push("��Ϧ��������");

        Saycontent.Push("��̽��zzz");
        Saycontent.Push("��Ϧ�������������������ڣ���о���Σ�");
        Saycontent.Push("��̽������");

        Saycontent.Push("��Ϧ�������ң�����������������");
        Saycontent.Push("��̽��������");
        Saycontent.Push("��Ϧ��ͻȻ������һ������Ĵ�����������ȥ����");
        Saycontent.Push("��̽������");
        Saycontent.Push("��Ϧ���������߷���������ƣ������������������ҹ����");
        Saycontent.Push("����̽����ɳ�������£����ۡ�");
        Saycontent.Push("��̽������");
        Saycontent.Push("��Ϧ���������¡�");
    }
    void SayForClient4()
    {
        Saycontent.Push("��Ϧ������");
        Saycontent.Push("��ͻȻһ���â���֣����߹ؿ������ų��֣�����Ϧ���֡��������ְ֣�");
        Saycontent.Push("��Ϧ���������ĵ��°�ɡ�");
        Saycontent.Push("��Ϧ������ǻ����ʵ�Ĵ������ƴ��ײ͡�");
    }
}
