using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMic : MonoBehaviour
{

    public void Open()
    {
        Audio.audio.Play();
        Debug.Log("≤•∑≈“Ù¿÷");
    }
    public void stop()
    {
        Audio.audio.Pause();
        Debug.Log("‘›Õ£“Ù¿÷");

    }
    public void Exit()
    {
        Destroy(this.gameObject);

    }
}
