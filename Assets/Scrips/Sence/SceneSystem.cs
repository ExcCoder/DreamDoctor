using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 场景的状态管理系统
/// </summary>
public class SceneSystem
{
    SceneState sceneState;
    /// <summary>
    /// 设置当前场景并进入当前场景
    /// </summary>
    /// <param name="state"></param>
    public void SetScene(SceneState state)
    {
        sceneState?.OnExit();
        sceneState = state;
        sceneState?.OnEnter();

    }

}
