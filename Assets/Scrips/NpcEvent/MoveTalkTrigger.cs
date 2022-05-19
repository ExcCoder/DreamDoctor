using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTalkTrigger : MonoBehaviour
{
    string selfName = "��̽";
    public Animator anim;
    bool music = true;
    bool isWalk = false;
    private void Start()
    {
        GameRoot.Instance.StoryManager.ActionStart.AddListener(action => 
        {
            if (action.targetName.Equals(selfName))
            {
                ExecuteAction(action);
            }
        });
    }
    private void FixedUpdate()
    {
        if (isWalk)
        {
            ExecuteMove();
        }
    }
    public void ExecuteAction(StoryAction action)
    {
        switch (action.actionName)
        {
            case "��̽����":
                Debug.Log("��̽������");
                this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255,255,255,255);
                //anim.SetBool("isWait",true);
                GameRoot.Instance.StoryManager.EndAction();
                GameRoot.Instance.StoryManager.Process("��̽");
                College2DReturn.isPush = true;
                break;
            case "�ߵ���Ƭ����":
                Debug.Log("��̽�ߵ���Ƭ����");
                anim.SetBool("isWalk",true);
                isWalk = true;
                break;
            case "����ɳ����":
                anim.SetBool("isWalk", true);
                isWalk = true;
                break;
            case "��Խ�ξ�":
                Debug.Log("��Խ�ξ�");
                GameRoot.Instance.SceneSystem.SetScene(new Level1());
                break;
        }
    }
    public void ExecuteMove()
    {
        this.transform.Translate(Vector3.left * 3*Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "��Ƭ��"&& music)
        {
            isWalk = false;
            anim.SetBool("isWalk",false);
            College2DReturn.isPush = true;

            music = false;
            //DialogPanel.dialog.ShowDialog();
           // GameRoot.Instance.StoryManager.Process("��̽");

        }
        if (collision.gameObject.name == "����ɳ��")
        {
            anim.SetBool("isWalk",false);
            anim.SetBool("isSit",true);
            College2DReturn.isPush = true;

            isWalk = false;

        }
    }
}
