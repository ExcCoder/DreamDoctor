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
            if (Input.GetKeyDown(KeyCode.E)&&College2DReturn.isPush)
            {
                GameRoot.Instance.StoryManager.Process(College2DReturn.Interact.name);
               // GameRoot.Instance.StoryManager.Process("��̽");
                College2DReturn.isPush = false;
            }
        }
    }
}
