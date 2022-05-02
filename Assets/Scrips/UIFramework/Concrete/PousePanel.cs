using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PousePanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/PousePanel";
    public PousePanel() : base(new UIType(path)) { }
    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChild<Button>("ContinueBtn").onClick.AddListener(() =>
        {
            Pop();
            Time.timeScale = 1;
            Debug.Log("点击了继续游戏按钮");
        });
        UITool.GetOrAddComponentInChild<Button>("ComeBankBtn").onClick.AddListener(() =>
        {
            Debug.Log("返回标题界面的按钮被点了");
            Time.timeScale = 1;
            GameRoot.Instance.SceneSystem.SetScene(new StartScene());
        });
    }

}
