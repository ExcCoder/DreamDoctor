using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/MainPanel";
    public MainPanel() : base(new UIType(path)) { }
    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChild<Button>("PouseBtn").onClick.AddListener(() =>
        {
            //点击事件可以写在这里面
            Debug.Log("暂停按钮被点了");
            Push(new PousePanel());
            Time.timeScale = 0;
        });
    }
}
