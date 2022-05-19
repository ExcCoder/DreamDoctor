using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 挂载到角色身上，用于识别标签
/// </summary>
public class StoryProcess : MonoBehaviour
{
    void Update()
    {
        //是否可以交互
        if (College2DReturn.Interact)
        {
            if (Input.GetKeyDown(KeyCode.E)&&College2DReturn.isPush)
            {
                GameRoot.Instance.StoryManager.Process(College2DReturn.Interact.name);
               // GameRoot.Instance.StoryManager.Process("侦探");
                College2DReturn.isPush = false;
            }
        }
    }
}
