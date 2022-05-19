using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 开始主面板
/// </summary>
public class StartPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/StartPanel";
    public StartPanel():base(new UIType(path)) { }
    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChild<Button>("NewGame").onClick.AddListener(() => {
            //点击事件可以写在这里面
            Debug.Log("新游戏按钮被点了");
            GameRoot.Instance.SceneSystem.SetScene(new Level0());
        });
    }
}
