using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ����״̬
/// </summary>
public abstract class SceneState
{
    /// <summary>
    /// ��������ʱִ�еĲ���
    /// </summary>
    public abstract void OnEnter();
    /// <summary>
    /// �����˳�ʱִ�еĲ���
    /// </summary>
    public abstract void OnExit();

}
