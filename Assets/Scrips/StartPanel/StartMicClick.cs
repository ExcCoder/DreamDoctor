using UnityEngine;
//控制开始场景的唱片机动画和音乐切换
public class StartMicClick : MonoBehaviour
{
    AudioSource audio;
    Animator anim;
    SpriteRenderer JukeBox;
    SpriteRenderer obj;
    private void Start()
    {
        audio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        anim = GameObject.Find("唱片机").GetComponent<Animator>();
        JukeBox = GameObject.Find("唱片机").GetComponent<SpriteRenderer>();


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
        if (name == "唱片机")
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

        
        Vector2 mousePositionOnScreen;//获取点击屏幕的坐标


        //获取鼠标在屏幕的二维坐标
        mousePositionOnScreen = Input.mousePosition;
        //在鼠标位置发射一条射线，存储在ray里
        Ray ray = Camera.main.ScreenPointToRay(mousePositionOnScreen);
        //从0点处发射一条2D射线，指向ray，存储在hit里
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(ray.origin.x, ray.origin.y), Vector2.zero, Mathf.Infinity);
        if (hit.collider)
        {
            Debug.Log("射中了" + hit.collider.gameObject.name);
            hit.collider.gameObject.GetComponent<SpriteRenderer>().color = new Color(200, 200, 200);
            return hit.collider.gameObject;

        }
        return null;
        //JukeBox.color = new Color(130, 130, 130);

    }
}
