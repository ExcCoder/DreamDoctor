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
            Debug.Log("����˼�����Ϸ��ť");
        });
        UITool.GetOrAddComponentInChild<Button>("ComeBankBtn").onClick.AddListener(() =>
        {
            Debug.Log("���ر������İ�ť������");
            Time.timeScale = 1;
            GameRoot.Instance.SceneSystem.SetScene(new StartScene());
        });
    }

}
