using UnityEngine;
//���ƿ�ʼ�����ĳ�Ƭ�������������л�
public class StartMicClick : MonoBehaviour
{
    AudioSource audio;
    Animator anim;
    SpriteRenderer JukeBox;
    SpriteRenderer obj;
    private void Start()
    {
        audio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        anim = GameObject.Find("��Ƭ��").GetComponent<Animator>();
        JukeBox = GameObject.Find("��Ƭ��").GetComponent<SpriteRenderer>();


        anim.SetBool("IsRed", true);
        anim.SetBool("IsBegin", true);

    }
    int count=0;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)&& GetObjOnRayClick())
        {
            clickJukeBox(GetObjOnRayClick().name);
            
        }


    }
    private void clickJukeBox(string name)
    {
        if (name == "��Ƭ��")
        {
            count++;
            if (count==1)
            {
                anim.SetBool("IsBegin", false);
                audio.Pause();
            }
            if (count >1)
            {
                anim.SetBool("IsBegin",true);
                audio.Play();
                count = 0;

            }
            
        }
    }
    public GameObject GetObjOnRayClick()
    {

        
        Vector2 mousePositionOnScreen;//��ȡ�����Ļ������


        //��ȡ�������Ļ�Ķ�ά����
        mousePositionOnScreen = Input.mousePosition;
        //�����λ�÷���һ�����ߣ��洢��ray��
        Ray ray = Camera.main.ScreenPointToRay(mousePositionOnScreen);
        //��0�㴦����һ��2D���ߣ�ָ��ray���洢��hit��
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(ray.origin.x, ray.origin.y), Vector2.zero, Mathf.Infinity);
        if (hit.collider)
        {
            Debug.Log("������" + hit.collider.gameObject.name);
            hit.collider.gameObject.GetComponent<SpriteRenderer>().color = new Color(200, 200, 200);
            return hit.collider.gameObject;

        }
        return null;
        //JukeBox.color = new Color(130, 130, 130);

    }
}
