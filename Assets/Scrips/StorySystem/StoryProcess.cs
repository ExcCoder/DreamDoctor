using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ���ص���ɫ���ϣ�����ʶ���ǩ
/// </summary>
public class StoryProcess : MonoBehaviour
{
    void Update()
    {
        //�Ƿ���Խ���
        if (College2DReturn.Interact)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameRoot.Instance.StoryManager.Process(College2DReturn.Interact.name);
            }
        }
    }
}
