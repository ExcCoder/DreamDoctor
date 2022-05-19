using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ��ʼ�����
/// </summary>
public class StartPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/StartPanel";
    public StartPanel():base(new UIType(path)) { }
    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChild<Button>("NewGame").onClick.AddListener(() => {
            //����¼�����д��������
            Debug.Log("����Ϸ��ť������");
            GameRoot.Instance.SceneSystem.SetScene(new Level0());
        });
    }
}
