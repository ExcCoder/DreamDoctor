using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
     public static AudioSource audio;
    private void Start()
    {
        audio = this.GetComponent<AudioSource>();
    }

}
