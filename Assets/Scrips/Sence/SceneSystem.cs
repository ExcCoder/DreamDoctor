using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ������״̬����ϵͳ
/// </summary>
public class SceneSystem
{
    SceneState sceneState;
    /// <summary>
    /// ���õ�ǰ���������뵱ǰ����
    /// </summary>
    /// <param name="state"></param>
    public void SetScene(SceneState state)
    {
        sceneState?.OnExit();
        sceneState = state;
        sceneState?.OnEnter();

    }

}
