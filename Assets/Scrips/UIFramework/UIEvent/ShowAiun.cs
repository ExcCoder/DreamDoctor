using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAiun : MonoBehaviour
{
    public Animator Ani;
    public Text text;
    int count =0;
    public void Change()
    {
        count++;
       
        
        if (count >1)
        {
            text.text = "¡¶";

            count = 0;
        }
        else
        {
            text.text = "¡·";
        }
        Ani.SetInteger("change", count);
    }

}
