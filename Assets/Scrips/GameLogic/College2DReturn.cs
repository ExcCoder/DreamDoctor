using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class College2DReturn : MonoBehaviour
{
    /// <summary>
    /// 可交互的物品
    /// </summary>
    public static GameObject Interact;
    /// <summary>
    /// 是否可以交互
    /// </summary>
    public static bool isInteract = false;
    /// <summary>
    /// 是否能填装对话，不能时清空
    /// </summary>
    public static bool isPush = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //如果标签为可交互则触发
        if (collision.tag == "Insteract")
        {
            Interact = collision.gameObject;
            Interact.transform.GetChild(0).gameObject.SetActive(true);
            isPush = true;
            isInteract = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Interact != null)
        {

            Interact.transform.GetChild(0).gameObject.SetActive(false);
            isPush = false;
            isInteract = false;

        }
    }
}

