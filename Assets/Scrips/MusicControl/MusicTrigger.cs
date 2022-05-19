using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
class MusicTrigger : MonoBehaviour
{
    public string selfName = "唱片机";
    public AudioSource source;
    public static bool isShow = false;
    public BasePanel MusicPanel = new BasePanel(new UIType("Prefabs/UI/Panel/MicItem"));
    public static PanelManager manage = new PanelManager();
    private void Start()
    {
        GameRoot.Instance.StoryManager.ActionStart.AddListener
        (action =>
        {
            //Debug.Log("唱片机状态" + action.actionName);
            if (action.targetName.Equals(selfName))
            {
                Debug.Log("触发了唱片机");
                ExecuteAction(action);

            }
        });
    }
    public void ExecuteAction(StoryAction action)
    {
        switch (action.actionName)
        {
            case "播放唱片":
                source.Play();
                College2DReturn.isPush = true;
                break;
            case "交互解锁":
                Debug.Log("交互解锁");
                isShow = true;
                break;
            case "发出噪音":
                source.Pause();
                College2DReturn.isPush = true;

                break;
        }
    }
    private void Update()
    {
        if (College2DReturn.Interact)
        {
            if (Input.GetKeyDown(KeyCode.E) && isShow == true && College2DReturn.Interact.name == "唱片机")
            {
                Debug.Log("唱片机检测");

                showMusicPanel();
                Time.timeScale = 0;
                isShow = false;
            }
        }
    }
    void showMusicPanel()
    {
        Debug.Log("执行了展示界面");

        manage.Push(MusicPanel);
    }

}

