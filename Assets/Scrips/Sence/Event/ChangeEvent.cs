using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeEvent : MonoBehaviour
{
    float change;
    public Image blackAndWrite;
    float write = 0;
    float black = 255;
    bool IsChange;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 进入场景，场景由黑变白
    /// </summary>
    public void Enter()
    {
        if (change - Time.deltaTime * 10 < 0)
        {
            IsChange = false;
        }
        change += Time.deltaTime;
        blackAndWrite.color = new Color(0, 0, 0, change);
    }
    /// <summary>
    /// 退出操作，场景由透明变黑
    /// </summary>
    public void Exit()
    {
        change = change - Time.deltaTime * 10;
        if (change < 0)
        {
            IsChange = false;
        }
        change += Time.deltaTime;
        blackAndWrite.color = new Color(0, 0, 0, change);
    }
}
