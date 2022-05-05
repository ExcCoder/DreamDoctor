using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMic : MonoBehaviour
{
    public Transform UIItem;
    public Animator Ani;
    public AudioSource audi;
    public void PlayMic()
    {
        if (UIItem.GetChild(0).name=="redRecode")
        {
            Ani.SetBool("IsRed",true);

        }
    }
    public void PouseMic()
    {

    }

}
