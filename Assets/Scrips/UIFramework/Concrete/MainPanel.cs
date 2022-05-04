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
            //����¼�����д��������
            Debug.Log("��ͣ��ť������");
            Push(new PousePanel());
            Time.timeScale = 0;
        });
        UITool.GetOrAddComponentInChild<Button>("MicClick").onClick.AddListener(() =>
        {
            //����¼�����д��������
            Debug.Log("��Ƭ�����Ĵ���");
            Push(new PousePanel());
            Time.timeScale = 0;
        });
        UITool.GetOrAddComponentInChild<Button>("MicChange").onClick.AddListener(() =>
        {
            //����¼�����д��������
            Debug.Log("��Ƭ����");
            Push(new PousePanel());
            Time.timeScale = 0;
        });
        UITool.GetOrAddComponentInChild<Transform>("TalkBG").gameObject.SetActive(false);
        UITool.FindChildGameObject("MicClick").SetActive(false);
        UITool.FindChildGameObject("MicChange").SetActive(false);

    }

}
