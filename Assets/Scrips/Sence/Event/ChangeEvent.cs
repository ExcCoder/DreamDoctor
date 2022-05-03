using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeEvent : MonoBehaviour
{
    float changeTiem;
    public Image blackAndWrite;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void White()
    {
        changeTiem += Time.deltaTime;

        if (changeTiem > 2)
        {
            blackAndWrite.color = new Color(0,0,0, changeTiem);
        }
    }
}
