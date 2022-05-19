using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTalkTrigger : MonoBehaviour
{
    string selfName = "侦探";
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
            case "侦探进门":
                Debug.Log("侦探出现了");
                this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255,255,255,255);
                //anim.SetBool("isWait",true);
                GameRoot.Instance.StoryManager.EndAction();
                GameRoot.Instance.StoryManager.Process("侦探");
                College2DReturn.isPush = true;
                break;
            case "走到唱片机旁":
                Debug.Log("侦探走到唱片机旁");
                anim.SetBool("isWalk",true);
                isWalk = true;
                break;
            case "坐在沙发上":
                anim.SetBool("isWalk", true);
                isWalk = true;
                break;
            case "穿越梦境":
                Debug.Log("穿越梦境");
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
        if (collision.gameObject.name == "唱片机"&& music)
        {
            isWalk = false;
            anim.SetBool("isWalk",false);
            College2DReturn.isPush = true;

            music = false;
            //DialogPanel.dialog.ShowDialog();
           // GameRoot.Instance.StoryManager.Process("侦探");

        }
        if (collision.gameObject.name == "患者沙发")
        {
            anim.SetBool("isWalk",false);
            anim.SetBool("isSit",true);
            College2DReturn.isPush = true;

            isWalk = false;

        }
    }
}
