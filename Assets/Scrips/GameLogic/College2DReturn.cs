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
    /// 是否能填装对话，不能时清空
    /// </summary>
    public static bool isPush = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Insteract")
        {
            Interact = collision.gameObject;
            Interact.transform.GetChild(0).gameObject.SetActive(true);
            isPush = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Interact != null)
        {

            Interact.transform.GetChild(0).gameObject.SetActive(false);
            isPush = false;
            Dialogue.Saycontent.Clear();

        }
    }
}

