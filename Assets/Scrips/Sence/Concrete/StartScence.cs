using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ��ʼ����
/// </summary>
public class StartScene : SceneState
{
    /// <summary>
    /// �����������ڼ��س���
    /// </summary>
    readonly string sceneName = "StartScene";
    /// <summary>
    /// UI���������������UI����������
    /// </summary>
    PanelManager panelManager;
    /// <summary>
    /// ��д���뷽��
    /// </summary>
    public override void OnEnter()
    {
        panelManager = new PanelManager();
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            SceneManager.LoadScene(sceneName);
            SceneManager.sceneLoaded += SceneLoaded;
        }
        else
        {
            panelManager.Push(new StartPanel());
        }
    }

    public override void OnExit()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
        panelManager.PopAll();
    }
    /// <summary>
    /// ������Ϻ�ִ�еķ���
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="load"></param>
    private void SceneLoaded(Scene scene,LoadSceneMode load)
    {
        panelManager.Push(new StartPanel());
        Debug.Log($"{sceneName}�����������");
    }
}
